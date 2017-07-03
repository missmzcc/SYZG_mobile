var usr = "";
var pwd = "";
var car = "";
var dg;//datagrid
var pg;//分页控件

// 百度地图API功能
var map = new BMap.Map("allmap");    // 创建Map实例

//权限验证
function loginInfo() {
    $.post("api.ashx",
     { api: 'loginInfo' },
     function (data) {
         if (data != 0) {
             //alert(data);
             oLoginInfo = eval("(" + data + ")");
             usr = oLoginInfo.usr;
             pwd = oLoginInfo.pwd;
         } else {
             alert("用户名或或密码错误!");
             window.location.href = "/login.html";
         }
     }
 );
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
    $.post("api.ashx",
   { api: 'history_park', usr: usr, pwd: pwd, car: car, begin_time: '2015-11-09 00:00:00', end_time: '2015-11-11 00:00:00', page: page, rows: rows },
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

//地图初始化
function map_init() {
    $('#input_car').val(car);

    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
    map.setCurrentCity("北京");          // 设置地图显示的城市 此项是必须设置的
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放

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
    var infoWindow = new BMap.InfoWindow(msg, opts);  // 创建信息窗口对象 
    marker.addEventListener("click", function () {
        map.openInfoWindow(infoWindow, point); //开启信息窗口
    });
    map.openInfoWindow(infoWindow, point);
}

//自动完成功能
function getFilterVehicleId() {
    $.post("api.ashx",
   { api: 'getFilterVehicleId', keyWord: '116' },
   function (data) {
       if (data != 0) {
           alert(data);
           odata = eval("(" + data + ")");
       } else {
           alert("资料错误!");
       }
   }
   );
}

//元素点击事件
function goFuction() {
    window.location.href = "/group.html";
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
        scrollbarSize: 0
    });
    window.pg = $('#dg').datagrid('getPager');
    $('.datagrid-pager').pagination({
        onSelectPage: function (pageNumber, pageSize) {
            //$(this).pagination('loading');
            //alert('pageNumber:' + pageNumber + ',pageSize:' + pageSize);
            //$(this).pagination('loaded');
            qry_pos();
        }
    });
}

//加载
loginInfo();
map_init();
datagrid_init();