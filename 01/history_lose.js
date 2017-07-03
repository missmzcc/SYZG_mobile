var user = {
    usr: "",
    pwd: ""
};
var car = "";
var dg;//datagrid
var pg;//分页控件

// 百度地图API功能
var map = new BMap.Map("allmap");    // 创建Map实例

//权限验证
function loginInfo() {
    $.loginInfo(user);
    setTimeout("$('#input_car').combobox('reload')", 500);
}

//换车查询
function qry_car() {
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
    $.post("api.ashx",
   { api: 'history_lose', usr: usr, pwd: pwd, car: car, begin_time: begin_time, end_time: end_time, page: page, rows: rows },
   function (Result) {
       var result = JSON.parse(Result);
       if (result.success) {
           var data = result.data;
           $('#dg').datagrid('loadData', data);
           $.mobile.go('#p2');
           //refresh(lng, lat, msg, lasttime);需重写
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
            var msg = "失联时刻：" + rowData.a + "<br>失联位置：" + rowData.poi + "<br>失联时长：" + rowData.nMin;
            refresh(rowData.lng, rowData.lat, msg, rowData.a)
            $.mobile.go('#p3');
        }

    });
    window.pg = $('#dg').datagrid('getPager');
    $('.datagrid-pager').pagination({
        onSelectPage: function (pageNumber, pageSize) {
            $(this).pagination('loading');
            //alert('pageNumber:' + pageNumber + ',pageSize:' + pageSize);            
            qry_pos();
            $(this).pagination('loaded');
        }
    });
}

function qry_test() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    var rows = window.pg.pagination('options').pageSize
    var page = window.pg.pagination('options').pageNumber
    var begin_time = $('#beginTime').datetimebox('getValue');
    var end_time = $('#endTime').datetimebox('getValue');
    $.post("api.ashx",
   { api: 'history_mileage_total', usr: user.usr, pwd: user.pwd, car: car, begin_time: begin_time, end_time: end_time, page: page, rows: rows },
   function (data) {
       if (data != 0) {
           //alert(data.length);
           if (data.substr(2, 3) != "err") {
               oData = eval("(" + data + ")")
               $('#dg').datagrid('loadData', oData);
               $.mobile.go('#p2');
               //refresh(lng, lat, msg, lasttime);需重写
           } else {
               oData = eval("(" + data + ")")
               alert(oData.err);
           }

       } else {
           alert("资料错误或页面过期!");
       }
   }
   );
}
//加载
loginInfo();
map_init();
datagrid_init();
setTimeout(input_init(), 5000);