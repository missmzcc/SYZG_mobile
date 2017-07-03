var user = { usr: "", pwd: "", nickName: "" };
$(function () {
    //全局变量 start
    var shipId = "";                        //运输单号
    var siteName = "";                      //施工地
    var editIndex = undefined;              //编辑的行
    var url = "";                           //ajax请求后台地址，根据保存或修改改变
    var approve = $.cookie("approve");      //权限
    //全局变量 end

    //初始化
    function init() {
        $.loginInfo(user);
        timeInit();
        timeInit1();
        pageLoad();
    }

    //查询页面时间初始化
    function timeInit() {
        var now = new Date();
        var yes = new Date(now.getTime() - 86400000);
        $("#beginTime").datetimebox({ value: yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00" });
        $("#endTime").datetimebox({ value: now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59" });
    }
    //修改页面时间初始化
    function timeInit1() {
        var now = new Date();
        var yes = new Date(now.getTime() - 86400000);
        $("#beginTime").datetimebox({ value: yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00" });
        $("#endTime").datetimebox({ value: now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59" });
    }

    //表格初始化加载数据
    function pageLoad() {
        //初始化表格
        $("#listDatas").datagrid({
            striped: true,
            singleSelect: true,
            fitColumns: true,
            border: true,
            collapsible: false,
            autoRowHeight: false,
            remoteSort: false,
            pagination: true,
            pageSize: 10,
            pageList: [10, 15, 20, 25, 50],
            rownumbers: false,
            columns: [[
                { field: 'Id', title: '运输单号' },
                { field: "SiteName", title: "工地" },
                { field: "Driver", title: "司机" },
                { field: "VehicleId", title: "车牌号" },
                {
                    field: "State", title: "状态", formatter: function (value, row, index) {
                        if (value == 0) {
                            return "待审核";
                        } else if (value == 1) {
                            return "已派车";
                        } else if (value == 2) {
                            return "结束";
                        } else if (value == 6) {
                            return "待派车";
                        }
                    }
                }
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
                }
                //"-", {
                //    id: "delete",
                //    text: "删除",
                //    iconCls: "icon-cancel",
                //    handler: function () {
                //        remove();
                //    }
                //}, "-", {
                //    id: "redo",
                //    text: "撤销",
                //    iconCls: "icon-redo",
                //    handler: function () {
                //        redo();
                //    }
                //}
            ],
            onDblClickRow: function (rowIndex, rowData) {
                update();
            }
        });
        $('#listDatas').datagrid('sort', {	        // 指定了排序顺序的列
            sortName: 'Id',
            sortOrder: 'desc'
        });
        //分页
        var pager = $("#listDatas").datagrid("getPager");
        $(pager).pagination({
            onSelectPage: function (pageNumber, pageSize) {
                $(this).pagination("loading");
                getShips();
                $(this).pagination("loaded");
            }
        });
    }

    //查询任务
    function getShips() {
        //若不是调度,只能查看不能新增
        if (approve !== "ch") {
            $("#add").hide();
        }
        shipId = $("#shipId").combobox("getValue");
        taskId = $("#siteName").combobox("getValue");
        var beginTime = $("#beginTime").datetimebox("getValue");
        var endTime = $("#endTime").datetimebox("getValue");
        var pager = $("#listDatas").datagrid("getPager");
        var pageSize = pager.pagination('options').pageSize;
        var pageNumber = pager.pagination('options').pageNumber;
        $.post("api.ashx", { api: "SYZG_Ship", usr: user.usr, pwd: user.pwd, Id: shipId, TaskId: taskId, beginTime: beginTime, endTime: endTime, page: pageNumber, rows: pageSize }, function (Result) {
            var result = JSON.parse(Result);
            if (result.success) {
                $("#listDatas").datagrid("loadData", result.data);
            } else {
                alert(result.message);
            }
        });
    }
    //新增任务
    function add() {
        $.mobile.go("#p3");
        $('#dataForm').form('reset');
        $('#InsertId').textbox('setValue', user.usr);
        $('#ModiId').textbox('setValue', user.usr);
        $('#InsertId').textbox('setText', user.nickName);
        $("#save").show();
        url = 'api.ashx?api=SYZG_InsertShip&usr=' + user.usr + '&pwd=' + user.pwd;
    }
    //修改任务
    function update() {
        var row = $("#listDatas").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        $('#dataForm').form('load', row);
        $('#InsertId').textbox('setText', user.nickName);
        //若是审核员，则审核否和关闭否之外的元素全部该为只读
        if (approve === "ch") {
            $("#save").show();
        } else {
            $("#save").hide();
        }
        url = 'api.ashx?api=SYZG_UpdateShip&usr=' + user.usr + '&pwd=' + user.pwd;
        $.mobile.go("#p3");
    }

    //删除任务
    function remove() {
        var row = $("#listDatas").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        if (confirm("是否确认删除?")) {
            $.post("api.ashx", { api: 'SYZG_DeleteShip', usr: user.usr, pwd: user.pwd, Id: row.Id }, function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    getShips();
                }
                alert(result.message);
            });
        }
    }
    //保存任务或修改任务
    function save() {
        $("#dataForm").form("submit", {
            url: url,
            success: function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    alert(result.message);
                    $.mobile.go("#p2");
                    getShips();
                } else {
                    alert(result.message);
                }
            }
        });
    }
    //撤销操作
    function redo() {
        $('#listDatas').datagrid('rejectChanges');
    }

    //事件绑定
    function bindEvent() {
        //查询按钮
        $("#queryTasks").click(function () {
            $.mobile.go("#p2");
            getShips();
        });
        //新增按钮
        $(document).on("click", "#addTask", function () {
            add();
        });
        //保存按钮
        $(document).on("click", "#save", function () {
            save();
        });
        //选择任务单时自动填充内部编号以及车台长
        $("#VehicleNum").combobox({
            onSelect: function (row) {
                $("#Driver").textbox("setValue", row.UserDefine1);
                $("#Driver1").textbox("setValue", row.UserDefine2);
                $("#Driver2").textbox("setValue", row.UserDefine3);
            }
        });
    }

    //初始化
    init();
    //事件绑定
    bindEvent();
});