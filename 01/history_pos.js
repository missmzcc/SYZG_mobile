var user = {
    usr: "",
    pwd: ""
};
var pwd = "";
var car = "";
var backPoints = [];//所有点
var backMoveMarker;//移动的标注
var backMarkers = [];
var backCurIndex = 0;//当前播放的索引
var backMoveInfoWindow;//移动标注的信息窗口
var backInterval;//播放定时器
var historyData = [];//历史轨迹点
var map = new BMap.Map("allmap");    // 创建Map实例
/***** 全局变量 end*****/

//初始化
function init() {
    //登陆校验
    $.loginInfo(user);
    setTimeout("$('#input_car').combobox('reload')", 500);

    //时间初始化
    var now = new Date();
    //不可直接使用setValue方法，必须先有value才可使用setValue，且日期格式必须为月/日/年
    $("#startTime").datetimebox({ value: now.toLocaleDateString().replace(/\//, "-") + " 0:0:0" });
    $("#endTime").datetimebox({ value: now.toLocaleDateString().replace(/\//, "-") + " 23:59:59" });

    //地图初始化
    $.map_init(map);
}

//重查询
function qry_pos() {
    if (Started == 1) {
        Started = 0;
        Paused = 0;
        StopTrackBack();
        map.clearOverlays();
    }
    //选择条件校验
    var beginTime = $("#startTime").datetimebox("getValue");
    var endTime = $("#endTime").datetimebox("getValue");
    if (!beginTime || !endTime || beginTime == "0" || endTime == "0") {
        alert("请选择开始时间和结束时间");
        return;
    }
    var oData = null;
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    historyData = [];
    $.post("api.ashx",
    { api: 'history_pos', usr: user.usr, pwd: user.pwd, car: car, begin_time: beginTime, end_time: endTime },
    function (data) {
        var result = JSON.parse(data);
        if (result.success) {
            var oData = result.data;
            backPoints = [];//清空标注点
            var j = 0;
            var leng = oData.length;
            for (var i = 0; i < leng; i++) {
                var info = oData[i];
                if (info.lng == null || info.lat == null || info.lng == "" || info.lat == "" || info.speed == 0) {
                    continue;
                }
                historyData.push(info);
                historyData[j].it = j++;
                var mi = CreateBackMarkerAndInfoWindow(info);
                if ((i % 20 == 0) || (i == oData.length - 1)) {
                    backMarkers.push(mi.marker);
                }
                backPoints.push(mi.point);
            }
            datagrid_init();
            $('#dg').datagrid('loadData', historyData);
            map.clearOverlays();//清除地图上的划线
            var polyline = new BMap.Polyline(
                 backPoints,
                 {
                     strokeColor: "#5b849e",
                     strokeWeight: 5,
                     strokeStyle: "solid"
                 });
            map.addOverlay(polyline);
            map.setCenter(backPoints[0]);
        } else {
            alert(reuslt.message);
        }
   });
    //refresh(mi.point, "", "");
}

/*创建marker*/
function CreateBackMarkerAndInfoWindow(info) {
    var point = new BMap.Point(info.lng, info.lat);
    var img = GetVehilceImg(info.speed, $.direction(info.direction), info.state0);//state0表示ACC
    var icon = new BMap.Icon(img, new BMap.Size(25, 25));
    var time = info.recordtime;
    var marker = new BMap.Marker(point, { icon: icon }, { time: time });

    var infoWindow = new BMap.InfoWindow(GetInfoWindowHtml(info), {
        offset: new BMap.Size(0, -15),
        enableMessage: false,
        content: time
    }); // 创建信息窗口对象    
    marker.addEventListener("click", function () {
        if (infoWindow.content.indexOf("当前位置") < 0) {
            //重新组建infoWindow
            var lng = this.IA.lng;
            var lat = this.IA.lat;
            $.post("api.ashx",
                    { api: 'getBaiduPoi', lng: lng, lat: lat },
                            function (data) {
                                infoWindow.content += "<tr><td>当前位置：</td><td>";
                                infoWindow.content += data;
                                infoWindow.content += "</td></tr>";
                                marker.openInfoWindow(infoWindow);      // 打开信息窗口 
                            });
        }
        else { marker.openInfoWindow(infoWindow); }
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

//获取车辆方向和状态图片
function GetVehilceImg(speed, dire, acc) {
    if (speed == "0") {
        if (acc == "开") {
            return "images/ready.png";
        }else {
            return "images/Direction/park.png";
        }
    }
    if (dire == "正东") {
        return "images/Direction/moveeast.png";
    }
    else if (dire == "正西") {
        return "images/Direction/movewest.png";
    }
    else if (dire == "正南") {
        return "images/Direction/movesouth.png";
    }
    else if (dire == "正北") {
        return "images/Direction/movenorth.png";
    }
    else if (dire == "东北") {
        return "images/Direction/movenortheast.png";
    }
    else if (dire == "东南") {
        return "images/Direction/movesoutheast.png";
    }
    else if (dire == "西北") {
        return "images/Direction/movenorthwest.png";
    }
    else {
        return "images/Direction/movesouthwest.png";
    }
}

//获取infowindow显示的内容
function GetInfoWindowHtml(info) {
    var ret = "";
    ret += "<table style='font-family:verdana;font-size:12;color:black;'>";
    //ret += "<tr><td>车牌号：</td><td>";
    //ret += info.name + "</td></tr>";
    //ret += "<tr><td>ACC状态：</td><td>";
    //ret += info.state0 + "</td></tr>";
    //ret += "<tr><td>电量(百分比)：</td><td>";
    //ret += info.battery + "</td></tr>";
    ret += "<tr><td>上传时间：</td><td>";
    ret += info.recordtime + "</td></tr>";
    ret += "<tr><td>速度：</td><td>";
    ret += info.speed + "km/h" + "</td></tr>";
    //ret += "<tr><td>行驶方向：</td><td>";
    //ret += info.dire + "</td></tr>";
    //ret += "<tr><td>当前位置：</td><td>";
    //ret += info.addr + "</td></tr>";
    //ret += "</table>";
    return ret;
}

/*设置移动标注*/
function SetMoveMarker() {
    //map.clearOverlays();
    if (backMoveMarker != null) {
        //移除上一个标注点
        map.removeOverlay(backMoveMarker);
    }
    //添加当前标注点到地图并地图中心移动到该标注点]
    var leng = backMarkers.length;
    if (leng !== 0) {
        backMoveMarker = backMarkers[backCurIndex];
        map.addOverlay(backMoveMarker);
        map.panTo(backMoveMarker.getPosition());
    } else {
        map.panTo(backPoints[0]);
    }

    //if (backCurIndex != 0) {
    //    /*边移动边画轨迹*/
    //    var points = new Array();
    //    points.push(backPoints[backCurIndex - 1]);
    //    points.push(backPoints[backCurIndex]);
    //    var polyline = new BMap.Polyline(points, { strokeColor: "#5b849e", strokeWeight: 5, strokeStyle: "solid" });
    //    map.addOverlay(polyline);
    //}

    document.getElementById("time").value = historyData[backCurIndex].recordtime;
    document.getElementById("speed").value = historyData[backCurIndex].speed + "km/h";

    //FocusRow(backCurIndex);
    backCurIndex++;
    if ((leng > 0 && backCurIndex == backMarkers.length) || (backCurIndex == historyData.length)) {//播放结束
        StopTrackBack();
        alert("历史轨迹播放结束");
    }
}

//停止播放
function StopTrackBack() {
    Paused = 0;
    Started = 0;
    if (backMoveMarker != null) {
        //移除上一个标注点
        map.removeOverlay(backMoveMarker);
    }
    backMoveMarker = null;
    backMoveInfoWindow = null;
    clearInterval(backInterval);
    //map.clearOverlays();
    backCurIndex = 0;
    map.setCenter(backPoints[0]);
    document.getElementById("time").value = null;
    document.getElementById("speed").value = null;
    document.getElementById("startplay").src = "images/start_play.png";
}

/*暂停播放*/
function PauseTrackBack() {
    clearInterval(backInterval);
}

var Started = 0;//开始/继续
var Paused = 0; //
//开始播放按钮
function start_play() {
    if (Started == 1)//暂停或继续
    {
        if (Paused == 0) {//暂停
            Paused = 1;
            document.getElementById("startplay").src = "images/start_play.png";
            PauseTrackBack();
        }
        else {//继续
            Paused = 0;
            document.getElementById("startplay").src = "images/pause_play.png";
            //继续播放
            backInterval = setInterval("SetMoveMarker()", 1000);
        }
    }
    else {
        Started = 1;
        //map.clearOverlays();
        document.getElementById("startplay").src = "images/pause_play.png";
        backInterval = setInterval("SetMoveMarker()", 1000);

    }

}

//结束播放按钮
function stop_play() {
    StopTrackBack();
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

init();
input_init();