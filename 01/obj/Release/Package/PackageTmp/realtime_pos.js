var usr = "";
var pwd = "";
var car = "";
var beRealtime = false;
var interval = 30;
var points = [] ; //坐标集合

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

//同车重查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    $.post("api.ashx",
   { api: 'realtime_pos', usr: usr, pwd: pwd, car: car },
   function (data) {
       if (data != 0) {
           //alert(data.length);
           if (data.substr(2, 3) != "err") {
               oData = eval("(" + data + ")")
               lng = oData[0].lng;
               lat = oData[0].lat;
               recordtime = oData[0].recordtime.substr(5, 11);
               speed = oData[0].speed;
               mileage = oData[0].mileage;
               direction = oData[0].direction;
               msg = "时间：" + recordtime + "<br>速度：" + speed + "<br>里程：" + mileage;
               $.mobile.go('#p2');
               setTimeout('refresh(lng, lat, msg, recordtime, speed, direction, mileage)', 0);
               if (beRealtime == true) {
                   setTimeout("qry_pos()", interval);
               }
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

    map.centerAndZoom(new BMap.Point(114.3229944, 30.63105472), 15);  // 初始化地图,设置中心点坐标和地图级别
    map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
    map.setCurrentCity("武汉");          // 设置地图显示的城市 此项是必须设置的
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放

}

//重查后刷新
function refresh(lng, lat, msg, lasttime, speed, direction, mileage) {

    //维护历史坐标
    var point = new BMap.Point(lng, lat)
    points.push(point);

    //维护轨迹
    if (points.length > 1) {
        var polyline = new BMap.Polyline([
            points[points.length - 2],
            points[points.length - 1]
        ], { strokeColor: "blue", strokeWeight: 2, strokeOpacity: 0.5 });   //创建折线
        map.addOverlay(polyline);   //增加折线
    }

    //加标注
    var img = GetVehilceImg(speed, direction);
    var icon = new BMap.Icon(img, new BMap.Size(25, 25));
    var marker = new BMap.Marker(point, { icon: icon });  // 创建标注
    map.addOverlay(marker);
    map.panTo(point);

    //加标签
    var opts = {
        position: point,    // 指定文本标注所在的地理位置
        offset: new BMap.Size(10, -10)    //设置文本偏移量
    }
    var label = new BMap.Label(car + "<br>" + lasttime, opts);  // 创建文本标注对象
    //map.addOverlay(label);

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
    //map.openInfoWindow(infoWindow, point);

    //消息栏显示
    $('#msg_time').text(lasttime);
    $('#msg_speed').text(speed);
    $('#msg_mileage').text(mileage);

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

//应用设置
function setting()
{
    interval = document.getElementById("interval").value * 1000;
    beRealtime = document.getElementById("beRealtime").checked;
    qry_pos();
}

//地图相关
//获取车辆方向和状态图片(轨迹回放静态点)
function GetVehilceImg(speed, direction) {
    var dire = TranslateDirection(direction);
    if (speed == "0") {
        return "/Images/Direction/park.png";
    }
    if (dire == "正东") {
        return "/Images/Direction/moveeast.png";
    }
    else if (dire == "正西") {
        return "/Images/Direction/movewest.png";
    }
    else if (dire == "正南") {
        return "/Images/Direction/movesouth.png";
    }
    else if (dire == "正北") {
        return "/Images/Direction/movenorth.png";
    }
    else if (dire == "东北") {
        return "/Images/Direction/movenortheast.png";
    }
    else if (dire == "东南") {
        return "/Images/Direction/movesoutheast.png";
    }
    else if (dire == "西北") {
        return "/Images/Direction/movenorthwest.png";
    }
    else {// (dire == "西南") {
        return "/Images/Direction/movesouthwest.png";
    }
}

/*创建marker*/
function CreateBackMarkerAndInfoWindow(info) {
    var point = new BMap.Point(info.lng, info.lat);
    var img = GetVehilceImg(info.gpsSpeed, info.dire);
    var icon = new BMap.Icon(img, new BMap.Size(25, 25));
    var marker = new BMap.Marker(point, { icon: icon });
    var infoWindow = new BMap.InfoWindow(GetInfoWindowHtml(info), {
        offset: new BMap.Size(0, -15),
        enableMessage: false
    }); // 创建信息窗口对象    
    marker.addEventListener("click", function () {
        this.openInfoWindow(infoWindow);      // 打开信息窗口 
    });
    marker.addEventListener("mouseover", function () {
        marker.setTop(true);
    });
    marker.addEventListener("mouseout", function () {
        marker.setTop(false);
    });
    return {
        marker: marker,
        point: point,
        infoWindow: infoWindow
    };
}

/*获取方向*/
function TranslateDirection(direction)
{
    //正北 正西 正南 正东 西北 西南  东南 东北
    var lret = "正北";

    if (direction > 22.5 && direction < 90 - 22.5) {
        return "东北";
    }
    else if (direction >= 90 - 22.5 && direction <= 90 + 22.5) {
        return "正东";
    }
    else if (direction > 90 + 22.5 && direction < 180 - 22.5) {
        return "东南";
    }
    else if (direction >= 180 - 22.5 && direction <= 180 + 22.5) {
        return "正南";
    }
    else if (direction > 180 + 22.5 && direction < 270 - 22.5) {
        return "西南";
    }
    else if (direction >= 270 - 22.5 && direction <= 270 + 22.5) {
        return "正西";
    }
    else if (direction > 270 + 22.5 && direction < 360 - 22.5) {
        return "西北";
    }
    else if (direction >= 360 - 22.5 && direction <= 360 || direction >= 0 && direction <= 22.5) {
        return "正北";
    }
    else {
        return "正北";
    }
}

//元素点击事件
function goFuction() {
    window.location.href = "/group.html";
}

loginInfo();
map_init();
