var usr = "";
var pwd = "";
var car = "";

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

//重查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    $.post("api.ashx",
   { api: 'history_pos', usr: usr, pwd: pwd, car: car, begin_time: '2015-10-29 00:00:00', end_time: '2015-11-11 00:00:00' },
   function (data) {
       if (data != 0) {
           alert(data.length);
           if (data.substr(2,3)!="err") {
               oData = eval("(" + data + ")")
               lng = oData[0].lng;
               lat = oData[0].lat;;
               recordtime = oData[0].recordtime;
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
    var lng = document.getElementById("lng").innerHTML;
    var lat = document.getElementById("lat").innerHTML;
    var car = document.getElementById("car").innerHTML;
    var lasttime = document.getElementById("lasttime").innerHTML;
    var msg = document.getElementById("msg").innerHTML;
    $('#input_car').val(car);

    map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.centerAndZoom(new BMap.Point(lng, lat), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
    map.setCurrentCity("北京");          // 设置地图显示的城市 此项是必须设置的
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放

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
   { api: 'getFilterVehicleId', keyWord:'116' },
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

loginInfo();
map_init();
