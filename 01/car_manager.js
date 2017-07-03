var user = { usr: "", pwd: "" };
$(function () {
    //全局变量
    var taskId = "";                        //任务编号
    var orderId = "";                       //订单号
    var clientId = "";                      //客户编号
    var editIndex = undefined;              //编辑的行
    var url = "";                           //ajax请求后台地址，根据保存或修改改变
    var count = 0;                          //保存任务点击客户名称第一次回出现问题
    var beginTime = "";                     //第一次查询请求的开始时间
    var endTime = "";                       //第一次查询请求的结束时间
    var approve = $.cookie("approve");      //权限

    //初始化
    function init() {
        $.loginInfo(user);
        pageLoad();
        timeInit();
    }

    //时间初始化
    function timeInit() {
        var now = new Date();
        var yes = new Date(now.getTime() - 86400000);
        $("#beginTime").datetimebox({ value: yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00" });
        $("#endTime").datetimebox({ value: now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59" });
    }

    //获取车台长报单
    function pageLoad() {
        //表格初始化
        $("#listCarManager").datagrid({
            striped: true,
            singleSelect: true,
            border: true,
            collapsible: false,
            autoRowHeight: true,
            remoteSort: false,
            pagination: true,
            pageSize: 10,
            pageList: [10, 15, 20, 25, 50],
            columns: [[
                { field: "Id", title: "编号" },
                { field: 'VehicleId', title: '车牌号' },
                { field: "ReportTime", title: "开单日期" },
                { field: "Quantity", title: "施工量" },
                { field: "Oil", title: "加油量" }
            ]],
            toolbar: [
                {
                    id: "add",
                    text: "新增",
                    iconCls: "icon-add",
                    handler: function () {
                        add();
                    }
                }, "-", {
                    id: "update",
                    text: "修改",
                    iconCls: "icon-edit",
                    handler: function () {
                        update();
                    }
                }, "-", {
                    id: "delete",
                    text: "删除",
                    iconCls: "icon-cancel",
                    handler: function () {
                        remove();
                    }
                }, "-", {
                    id: "redo",
                    text: "撤销",
                    iconCls: "icon-redo",
                    handler: function () {
                        redo();
                    }
                }
            ],
            onDblClickRow: function (rowIndex, rowData) {
                update();
            }
        });
        var pager = $("#listCarManager").datagrid("getPager");
        $(pager).pagination({
            onSelectPage: function (pageNumber,pageSize) {
                $(this).pagination("loading");
                getListDatas();
                $(this).pagination("loaded");
            }
        });
    }

    //确定结束编辑,未使用
    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#listTasks').datagrid('validateRow', editIndex)) {
            $('#listTasks').datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }
    //数据获取
    function getListDatas() {
        taskId = $("#managerId").combobox("getValue");
        orderId = $("#order").textbox("getValue");
        clientId = $("#customer").textbox("getValue");
        beginTime = $("#beginTime").textbox("getValue");
        endTime = $("#endTime").textbox("getValue");
        var pager = $("#listCarManager").datagrid("getPager");
        var pageSize = pager.pagination("options").pageSize;
        var pageNumber = pager.pagination("options").pageNumber;
        $.post("api.ashx", {
            api: "SYZG_Report", usr: user.usr, pwd: user.pwd, TaskId: taskId, Client: clientId,beginTime:beginTime,endTime:endTime,
            OrderId: orderId, page: pageNumber, rows: pageSize
        }, function (Result) {
            var result = JSON.parse(Result);
            if (result.success) {
                $("#listCarManager").datagrid("loadData", result.data);
            } else {
                alert(result.message);
            }
        });
    }
    //添加车台长报单
    function add() {
        $.mobile.go("#p3");
        $("#look").hide();
        $('#carManagerForm').form('reset');
        $("#InsertId").textbox("setValue", user.usr);
        $("#ModiId").textbox("setValue", user.usr);
        url = 'api.ashx?api=SYZG_InsertReport&usr=' + user.usr + '&pwd=' + user.pwd;
        //司机才有权限新增报单
        if (approve === 'ct') {
            $("#save").show();
        } else {
            $("#save").hide();
        }
        //联动填写任务单号
        $("#ShipId").combobox({
            onSelect: function (record) {
                $("#TaskId").textbox("setValue", record.TaskId);
            }
        });
    }
    //修改车台长报单
    function update() {
        var row = $("#listCarManager").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        $("#look").show();
        $('#carManagerForm').form('load', row);
        url = 'api.ashx?api=SYZG_UpdateReport&usr=' + user.usr + '&pwd=' + user.pwd;
        //司机才有权限新增报单
        if (approve === 'ct') {
            $("#save").show();
        } else {
            $("#save").hide();
        }
        lookPicture(row.Id);
        $.mobile.go("#p3");
    }
    //修改时查看图片
    function lookPicture(id) {
        var imgUrl = "/api.ashx?api=getAttachbyId&Id=" + id + "&" + new Date().getTime();
        var img = document.getElementsByTagName('img')[0];
        img.src = imgUrl;
        $(document).on("click", "#look", function () {
            $.mobile.go("#p4");
        });
    }
    //删除报单
    function remove() {
        var row = $("#listCarManager").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        if (confirm("是否确认删除?")) {
            $.post("api.ashx", { api: 'SYZG_DeleteReport', usr: user.usr, pwd: user.pwd, Id: row.Id, TaskId: row.TaskId, ShipId: row.ShipId }, function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    alert("删除成功!");
                    getListDatas();
                } else {
                    alert(result.message);
                }
            });
        }
    }
    //保存报单
    function save() {
        $("#carManagerForm").form("submit", {
            url: url,
            success: function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    alert(result.message);
                    $.mobile.go("#p2");
                    getListDatas();
                } else {
                    alert(result.message);
                }
            }
        });
    }
    //撤销操作
    function redo() {
        $('#listCarManager').datagrid('rejectChanges');
    }

    //事件绑定
    function bindEvent() {
        //查询按钮
        $("#queryTasks").click(function () {
            $.mobile.go("#p2");
            getListDatas();
        });
        //新增按钮
        $(document).on("click", "#addTask", function () {
            add();
        });
        //保存按钮
        $(document).on("click", "#save", function () {
            save();
        });
    }

    //初始化
    init();
    //事件绑定
    bindEvent();
})