var user = {
    usr: "",
    pwd: ""
};
var pwd = "";
var car = "";
var dg;//datagrid
var pg;//分页控件
var map = new BMap.Map("allmap");
/*****全局变量 end *****/

//权限验证
function loginInfo() {
    $.loginInfo(user);   
    setTimeout("$('#input_car').combobox('reload')", 500);       
}

//换车查询
function qry_warn() {

    //清除覆盖物
    map.clearOverlays();
    //清空坐标集合
    window.points = [];

    qry_pos();
}

//重查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    var rows = window.pg.pagination('options').pageSize
    var page = window.pg.pagination('options').pageNumber
    var begin_time = $('#beginTime').datetimebox('getValue');
    var end_time = $('#endTime').datetimebox('getValue');
    var warnType ="";
    var OverSpeed = document.getElementById("OverSpeed").checked;
    var ParkTimeout = document.getElementById("ParkTimeout").checked;
    var PowerOff = document.getElementById("PowerOff").checked;
    var Unload = document.getElementById("Unload").checked;
    var GnssModel = document.getElementById("GnssModel").checked;
    if (OverSpeed || ParkTimeout || PowerOff || Unload || GnssModel) {
        if (OverSpeed)
            warnType += "1,";
        if (GnssModel)
            warnType += "4,";
        if (PowerOff)
            warnType += "8,";
        if (ParkTimeout)
            warnType += "13,";
        if (Unload)
            warnType += "48,";
    }
    else {
        alert("请选择一个报警类型！");
        return;
    }
    $.post("api.ashx",
   { api: 'history_warn', usr: user.usr, pwd: user.pwd, car: car, begin_time: begin_time, end_time: end_time, warn_type: warnType.substr(0, warnType.length - 1), page: page, rows: rows },
   function (Result) {
       var result = JSON.parse(Result);
       if (result.success) {
           oData = eval("(" + data + ")");
           $('#dg').datagrid('loadData', oData);
           $.mobile.go('#p2');
           refresh(lng, lat, msg, lasttime);
       } else {
           alert(result.message);
       }
   });
}

//地图初始化
function map_init() {
    $('#input_car').val(car);
    $.map_init(map);
}

//重查后刷新
function refresh(lng, lat, msg, lasttime) {
    map.clearOverlays();

    //加标注
    var new_point = new BMap.Point(lng, lat);
    var marker = new BMap.Marker(new_point);  // 创建标注                
    map.addOverlay(marker);
    map.panTo(new_point);

    //加标签
    var opts = {
        position: new_point,    // 指定文本标注所在的地理位置
        offset: new BMap.Size(10, -10)    //设置文本偏移量
    }
    var label = new BMap.Label(car + "<br>" + lasttime, opts);  // 创建文本标注对象
    map.addOverlay(label);

    //加信息窗口
    var point = new BMap.Point(lng, lat);
    var opts1 = {
        width: 200,     // 信息窗口宽度
        height: 100,     // 信息窗口高度
        title: "GPS信息", // 信息窗口标题
        enableMessage: true,//设置允许信息窗发送短息
        message: ""
    }
    $.openInfoWindow(map,marker,msg,opts1);
}

//datagrid初始化
function datagrid_init() {
    window.dg = $('#dg').datagrid({
        idField: 'a',
        header: '#hh',
        singleSelect: true,
        border: false,
        pagination: true,
        fit: true,
        fitColumns: true,
        scrollbarSize: 0,
        onDblClickRow: function (rowIndex, rowData) {
            //alert(rowData.lng);
            var msg = "报警时间：" + rowData.warnstarttime + "<br>停车位置：" + rowData.poi + "<br>报警类型：" + rowData.warntype;
            refresh(rowData.lng, rowData.lat, msg, rowData.warnstarttime)
            $.mobile.go('#p3');
        }

    });
    window.pg = $('#dg').datagrid('getPager');
    $('.datagrid-pager').pagination({
        onSelectPage: function (pageNumber, pageSize) {
            $(this).pagination('loading');           
            qry_pos();
            $(this).pagination('loaded');
        }
    });
}

//车牌号输入框初始化
function input_init() {
    //api接口需要用户名密码
    $('#input_car').combobox({
        onBeforeLoad: function (param) {
            param.usr = user.usr;
            param.pwd = user.pwd;
        }
    });
}

//加载
loginInfo();
map_init();
datagrid_init();
input_init();