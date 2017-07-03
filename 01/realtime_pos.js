﻿var user = {
    usr: "",
    pwd: "",
};
var car = "";
var beRealtime = false;
var interval = 30;
var points = [] ; //坐标集合
var map = new BMap.Map("allmap");    // 创建Map实例
/***** 全局变量end *****/

//权限验证
function loginInfo() {
    $.loginInfo(user);
    $.map_init(map);
}

//换车查询
function qry_car() {
    //清除覆盖物
    map.clearOverlays();
    //清空坐标集合
    window.points = [];

    qry_pos();
}

//车辆信息查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (!car) {
        alert("车牌号为空！");
        return;
    }
    $.post("api.ashx",
    { api: 'realtime_pos', usr: user.usr, pwd: user.pwd, car: car },
    function (Result) {
        var result = JSON.parse(Result);
        if (result.success) {
            var data = result.data[0];
            lng = data.lng;
            lat = data.lat;
            recordtime = data.recordtime;
            speed = data.speed;
            mileage = data.mileage;
            direction = data.direction;
            msg = "车牌号："+ car +"<br>时间：" + recordtime + "<br>速度：" + speed + "<br>里程：" + mileage;
            $.mobile.go('#p2');
            setTimeout('refresh(lng, lat, msg, recordtime, speed, direction, mileage)', 0);
            if (beRealtime == true) {
                setTimeout("qry_pos()", interval);
            }
       } else {
           alert(result.message);
       }
   });
}

//绘制地图
function refresh(lng, lat, msg, lasttime, speed, direction, mileage) {
    var point = new BMap.Point(lng, lat);
    map.panTo(point);
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


    //加标签
    //var opts = {
    //    position: point,    // 指定文本标注所在的地理位置
    //    offset: new BMap.Size(10, -10)    //设置文本偏移量
    //}
    //var label = new BMap.Label(car + "<br>" + lasttime, opts);  // 创建文本标注对象
    //map.addOverlay(label);

    //加信息窗口
    var point = new BMap.Point(lng, lat);
    var opts1 = {
        width: 200,     // 信息窗口宽度
        height: 110,     // 信息窗口高度
        title: "GPS信息", // 信息窗口标题
        enableMessage: true//设置允许信息窗发送短息
    }
    $.openInfoWindow(map,marker,msg,opts1,true);

    //消息栏显示
    $('#msg_time').text(lasttime);
    $('#msg_speed').text(speed);
    $('#msg_mileage').text(mileage);
}

//获取车辆方向和状态图片(轨迹回放静态点)
function GetVehilceImg(speed, direction) {
    if (speed == "0") {
        return "/Images/Direction/park.png";
    }
    //根据角度获取方向
    var dire = $.direction(direction);
    if (dire == "正东") {
        return "/Images/Direction/moveeast.png";
    }else if (dire == "正西") {
        return "/Images/Direction/movewest.png";
    }else if (dire == "正南") {
        return "/Images/Direction/movesouth.png";
    }else if (dire == "正北") {
        return "/Images/Direction/movenorth.png";
    }else if (dire == "东北") {
        return "/Images/Direction/movenortheast.png";
    }else if (dire == "东南") {
        return "/Images/Direction/movesoutheast.png";
    }else if (dire == "西北") {
        return "/Images/Direction/movenorthwest.png";
    }else {
        return "/Images/Direction/movesouthwest.png";
    }
}

/***** 设置 start *****/
function setting() {
    interval = document.getElementById("interval").value * 1000;
    beRealtime = document.getElementById("beRealtime").checked;
    setTimeout(qry_pos, 1000);
}
/***** 设置 end *****/

/***** 初始化方法调用 *****/
loginInfo();