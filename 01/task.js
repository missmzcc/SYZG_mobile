var user = { usr: "", pwd: "", nickName: "" };
$(function () {
    //全局变量 start
    var taskId = "";                        //任务编号
    var clientId = "";                      //客户编号
    var editIndex = undefined;              //编辑的行
    var url = "";                           //ajax请求后台地址，根据保存或修改改变
    var approve = $.cookie("approve");      //权限
    //全局变量 end

    //初始化
    function init() {
        $.loginInfo(user);
        timeInit();
        pageLoad();
    }

    //时间初始化
    function timeInit() {
        var now = new Date();
        var yes = new Date(now.getTime() - 86400000);
        $("#beginTime").datetimebox({ value: yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00" });
        $("#endTime").datetimebox({ value: now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59" });
    }

    //表格初始化加载数据
    function pageLoad() {
        //初始化表格
        $("#listTasks").datagrid({
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
                { field: 'Id', title: '单号'},
                { field: "Name", title: "客户名称" },
                { field: "PlanTaskTotal", title: "计划量"},
                { field: "PlanBeginTime", title: "开盘时间" },
                {
                    field: "State", title: "状态", formatter: function (value,row,index) {
                        if (value == 0) {
                            return "待审核";
                        } else if (value == 1) {
                            return "已派车";
                        }else if (value == 2) {
                            return "结束";
                        }else if (value == 6) {
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
                }, "-",{
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
            onDblClickRow: function (rowIndex,rowData) {
                update();
            }
        });
        $('#listTasks').datagrid('sort', {	        // 指定了排序顺序的列
            sortName: 'Id',
            sortOrder: 'desc'
        });
        //分页
        var pager = $("#listTasks").datagrid("getPager");
        $(pager).pagination({
            onSelectPage: function (pageNumber,pageSize) {
                $(this).pagination("loading");
                getTasks();
                $(this).pagination("loaded");
            }
        });
    }

    //查询任务
    function getTasks() {
        //若是审核员，隐藏新增按钮
        if (approve === "srd") {
            $("#add").hide();
        }
        taskId = $("#taskId").combobox("getValue");
        clientId = $("#clientName").combobox("getValue");
        var beginTime = $("#beginTime").datetimebox("getValue");
        var endTime = $("#endTime").datetimebox("getValue");
        var pager = $("#listTasks").datagrid("getPager");
        var pageSize = pager.pagination('options').pageSize;
        var pageNumber = pager.pagination('options').pageNumber;
        $.post("api.ashx", { api: "SYZG_Task", usr: user.usr, pwd: user.pwd, Id: taskId, Client: clientId, beginTime: beginTime, endTime: endTime, page: pageNumber, rows: pageSize }, function (Result) {
            var result = JSON.parse(Result);
            if (result.success) {
                $("#listTasks").datagrid("loadData", result.data);
            } else {
                alert(result.message);
            }
        });
    }
    //新增任务
    function add() {
        $.mobile.go("#p3");
        $('#taskForm').form('reset');
        $('#InsertId').textbox('setValue',user.usr);
        $('#ModiId').textbox('setValue', user.usr);
        $('#InsertId').textbox('setText', user.nickName);
        //权限控制,只有业务员有新增权限,其他只有查看权限
        if (approve === 'crd') {
            $("#save").show();
        } else {
            $("#save").hide();
        }
        $("#closeing").hide();
        url = 'api.ashx?api=SYZG_InsertTask&usr=' + user.usr + '&pwd=' + user.pwd;
    }
    //easyui事件邦定
    $("#Name").combobox({
        onSelect: function () {
            getCustomInfo();
        }
    });
    //选择客户名称时连带填充相关信息
    function getCustomInfo() {
        $.post("api.ashx", { api: "getContactbyId", Client: $("#Name").combobox("getValue") }, function (Result) {
            if (Result) {
                var result = JSON.parse(Result);
                $("#Client").textbox("setValue", result[0].Id);
                $("#Contact").textbox("setValue", result[0].master);
                $("#Tel").textbox("setValue", result[0].MasterTel);
            }
        });
    }
    //修改任务
    function update() {
        var row = $("#listTasks").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        $('#taskForm').form('load', row);
        $('#InsertId').textbox('setText', user.nickName);
        //若是审核员，则审核否和关闭否之外的元素全部该为只读
        if (approve === "srd") {
            $("#Closed").combobox({ readonly: false });
            $("#Valid").combobox({ readonly: false });
            $("#VehicleType").textbox("textbox").attr("readonly", true);
            $("#Name").combobox("disable");//使用disable时,form表单不会提交该字段
            $("#SiteName").textbox("textbox").attr("readonly", true);
            $("#RentType").combobox({readonly:true});
            $("#PlanTaskTotal").textbox("textbox").attr("readonly", true);
            $("#RentUnitPrice").textbox("textbox").attr("readonly", true);
            $("#PlanBeginTime").datetimebox({ readonly: true });
            $("#PlanEndTime").datetimebox({ readonly: true });
            $("#Contact").textbox("textbox").attr("readonly", true);
            $("#Tel").textbox("textbox").attr("readonly", true);
            $("#Memo").textbox("textbox").attr("readonly", true);
            $("#closeing").hide();
        } else if (approve === 'crd') {
            //若是closed==1任务单关闭或任务单结束状态,任务单不可修改
            if (row.Closed != 0 || row.State == 2) {
                $("#closeing").hide();
                $("#save").hide();
            //若是关闭状态正常,审核状态不为待审核时不可修改任务单
            } else if (row.Closed == 0 && row.State != 0) {
                $("#save").hide();
                $("#closeing").show();
            } else {
                $("#save").show();
                $("#closeing").show();
            }
        } else {
            $("#save").hide();
            $("#closeing").hide();
        }
        //页面样式颜色处理
        validSuccess(row.Valid);
        stateSuccess(row.State);
        closedSuccess(row.Closed);
        url = 'api.ashx?api=SYZG_UpdateTask&usr=' + user.usr + '&pwd=' + user.pwd;
        $.mobile.go("#p3");
    }
    //删除任务
    function remove() {
        var row = $("#listTasks").datagrid("getSelected");
        if (!row) {
            alert("请选择需要修改的行");
            return;
        }
        if (confirm("是否确认删除?")) {
            $.post("api.ashx", { api: 'SYZG_DeleteTask', usr: user.usr, pwd: user.pwd, Id: row.Id }, function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    getTasks();
                }
                alert(result.message);
            });
        }
    }
    //保存任务或修改任务
    function save() {
        $("#taskForm").form("submit", {
            url: url,
            success: function (Result) {
                var result = JSON.parse(Result);
                if (result.success) {
                    alert(result.message);
                    $.mobile.go("#p2");
                    getTasks();
                } else {
                    alert(result.message);
                }
            }
        });
    }
    //撤销操作
    function redo() {
        $('#listTasks').datagrid('rejectChanges');
    }
    //申请状态关闭
    function closeing() {
        $("#Closed").combobox("setValue", "1");
        save();
    }

    //事件绑定
    function bindEvent() {
        //查询按钮
        $("#queryTasks").click(function () {
            $.mobile.go("#p2");
            getTasks();
        });
        //新增按钮
        $(document).on("click", "#addTask", function () {
            add();
        });
        //保存按钮
        $(document).on("click","#save",function () {
            save();
        });
        //关闭状态修改
        $(document).on("click", "#closeing", function () {
            $.messager.confirm('请注意', '确定申请关闭吗?', function (r) {
                if (r) {
                    closeing();
                }
            })
         });
    }

    //初始化
    init();
    //事件绑定
    bindEvent();
});

/*-----easyui样式初始化 start-----*/
//状态位初始化颜色
function stateSuccess(value) {
    if (value === '0') {//待审核
        $("#State").next('span').find('input').css({'background-color': 'red',color:'white'});
    } else if (value === '1') {//已派车
        $("#State").next('span').find('input').css({ 'background-color': 'green', color: 'white' });
    } else if (value === '2') {//结束
        $("#State").next('span').find('input').css({ 'background-color': 'gray', color: 'white' });
    } else if (value === '6') {//待派车
        $("#State").next('span').find('input').css({ 'background-color': 'blue', color: 'white' });
    }
}

//审核否下拉样式
function validFormatter(row) {
    switch (row.id) {
        case true:
            return '<div style="background-color:green;color:white;text-align:center;">通过</div>';
        default:
            return '<div style="background-color:red;color:white;text-align:center;">驳回</div>';
    }
}
//审核否初始化加载样式
function validSuccess(value) {
    if (value) {
        $("#Valid").next('span').find('input').css({'background-color': 'green',color:'white'});
    } else {
        $("#Valid").next('span').find('input').css({ 'background-color': 'red', color: 'white' });
    }
}
//审核否下拉选择后样式
function validSelect(row) {
    if (row.text == '通过') {
        $(this).next('span').find('input').css('background-color', 'green');
    } else {
        $(this).next('span').find('input').css('background-color', 'red');
    }
}
//关闭否颜色
function closedFormmater(row) {
    switch (row.id) {
        case '0':
            return '<div style="background-color:green;color:white;text-align:center;">正常</div>';
        case '1':
            return '<div style="background-color:blue;color:white;text-align:center;">申请撤单</div>';
        case '2':
            return '<div style="background-color:red;color:white;text-align:center;">关闭</div>';
        default:
            break;
    }
}
//关闭否初始化加载
function closedSuccess(value) {
    if (value === '0') {
        $("#Closed").next('span').find('input').css({ 'background-color': 'green', color: 'white' });
    } else if (value === '1') {
        $("#Closed").next('span').find('input').css({ 'background-color': 'blue', color: 'white' });
    } else if (value === '2') {
        $("#Closed").next('span').find('input').css({ 'background-color': 'red', color: 'white' });
    }
}
function closedSelect(row) {
    if (row.id === '0') {
        $(this).next('span').find('input').css('background-color', 'green');
    } else if (row.id === '1') {
        $(this).next('span').find('input').css('background-color', 'blue');
    } else if (row.id === '2') {
        $(this).next('span').find('input').css('background-color', 'red');
    }
}
/*-----easyui样式初始化 end-----*/
