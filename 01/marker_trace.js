var usr = "";
var pwd = "";
var car = "";
var beRealtime = false;
var interval = 30;
var points = []; //坐标集合
var app_para = [];
var app_para1 = [];

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
             //等文档完成后,usr,pwd有值再加载数据
             setTimeout("$('#input_car').combobox('reload')", 0);
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
    mark = $('#input_marker').combobox('getValue');
    if (mark == "") {
        alert("即将加载全部标注，可能导致页面卡顿！");
        //return;
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
               window.app_para[0] = lng;
               window.app_para[1] = lat;
               msg = "车牌：" + car + "<br>时间：" + recordtime + "<br>速度：" + speed + "<br>里程：" + mileage + "<br><a href='javascript:void(0)' onclick='run_app();' >增加到标注区域</a> ";
               $.mobile.go('#p2');
               setTimeout('refresh(lng, lat, msg, recordtime, speed, direction, mileage)', 0);
               setTimeout(qry_pos1(), 0);
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

//重查询区域并显示地图上
function qry_pos1() {
    var rows = 1000;
    var page = 1;
    var id = $('#input_marker').textbox('getValue');
    var reg_state = '';
    var begin_time = '2000-01-01 00:00:00';
    var end_time = '2099-01-01 00:00:00';
    $.post("api.ashx",
   { api: 'region', state: "q", usr: usr, pwd: pwd, page: page, rows: rows, id: id, reg_state: reg_state, begin_time: begin_time, end_time: end_time },
   function (data) {
       if (data != 0) {
           //alert(data.length);
           if (data.substr(2, 3) != "err") {
               oData = eval("(" + data + ")");
               for (var i = 0; i < oData.rows.length; i++) {
                   input_mark = $('#input_marker').combobox('getValue');

                   var point = new BMap.Point(oData.rows[i].regLongitude, oData.rows[i].regLatitude);
                   switch (oData.rows[i].state) {
                       case "R":
                           var myIcon = new BMap.Icon("/images/marker/Red.ico", new BMap.Size(16, 16));
                           break;
                       case "G":
                           var myIcon = new BMap.Icon("/images/marker/Green.ico", new BMap.Size(16, 16));
                           break;
                       case "Y":
                           var myIcon = new BMap.Icon("/images/marker/Yellow.ico", new BMap.Size(16, 16));
                           break;
                       default:
                           var myIcon = new BMap.Icon("/images/marker/Red.ico", new BMap.Size(16, 16));
                           break;
                   }
                   var marker = new BMap.Marker(point, { icon: myIcon });  // 创建标注 用于判断没有标注点号则显示全部，输入则只显示一个
                   if (input_mark) {
                       marker.disableMassClear();
                   } else {
                       marker.enableMassClear();
                   }

                   map.addOverlay(marker);

                   //加标签
                   var opts = {
                       position: point,    // 指定文本标注所在的地理位置
                       offset: new BMap.Size(10, -10)    //设置文本偏移量
                   }
                   var label = new BMap.Label(oData.rows[i].Id, opts);  // 创建文本标注对象;
                   if (input_mark) {
                       label.disableMassClear();
                   } else {
                       label.enableMassClear();
                   }

                   map.addOverlay(label);

                   //弹窗
                   var opts = {
                       width: 200,     // 信息窗口宽度
                       height: 100     // 信息窗口高度
                       //title: "标注点信息", // 信息窗口标题
                       //enableMessage: true,//设置允许信息窗发送短息
                       //message: "亲耐滴，晚上一起吃个饭吧？戳下面的链接看下地址喔~"
                   }
                   window.app_para1[0] = oData.rows[i].Id;
                   window.app_para1[1] = oData.rows[i].regId;
                   window.app_para1[2] = oData.rows[i].regName;
                   window.app_para1[3] = oData.rows[i].regLongitude;
                   window.app_para1[4] = oData.rows[i].regLatitude;
                   window.app_para1[5] = oData.rows[i].regRadius;
                   window.app_para1[6] = oData.rows[i].regAddress;
                   window.app_para1[7] = oData.rows[i].unitId;
                   window.app_para1[8] = oData.rows[i].insertTime;
                   window.app_para1[9] = oData.rows[i].state;
                   //window.app_para1[10] = $('#regId').combobox('getText');

                   if (input_mark) {
                       //var allOverlay = map.getOverlays();
                       //for (var j = 1; j < allOverlay.length - 1; j++) {
                       //    if (allOverlay[i].V == 'path') {
                       //        map.removeOverlay(allOverlay[j]);
                       //    }
                       //}
                       map.clearOverlays();
                       var pointA = new BMap.Point(window.app_para[0], window.app_para[1]);  // 创建点坐标A--大渡口区
                       var pointB = new BMap.Point(window.app_para1[3], window.app_para1[4]);  // 创建点坐标B--江北区
                       //alert('当前位置与标注点的距离是：' + (map.getDistance(pointA, pointB)).toFixed(2) + ' 米。');  //获取两点距离,保留小数点后两位
                       var polyline = new BMap.Polyline([pointA, pointB], { strokeColor: "blue", strokeWeight: 6, strokeOpacity: 0.5 });  //定义折线
                       map.addOverlay(polyline);     //添加折线到地图上


                       if (map.getDistance(pointA, pointB).toFixed(2) < 100) {
                           var infoWindow = new BMap.InfoWindow("标注名称：" + oData.rows[i].regName +
                               "<br>标注地址：" + oData.rows[i].regAddress +
                               "<br>创建时间：" + oData.rows[i].insertTime +
                               "<br>与标注点直线距离：" + (map.getDistance(pointA, pointB)).toFixed(2) + "米" +
                               "<br><a href='javascript:void(0)' onclick='run_app1();' >修改标注区域</a> ", opts);  // 创建信息窗口对象 
                       } else {
                           var infoWindow = new BMap.InfoWindow("标注名称：" + oData.rows[i].regName +
                              "<br>标注地址：" + oData.rows[i].regAddress +
                              "<br>创建时间：" + oData.rows[i].insertTime +
                              "<br>与标注点直线距离：" + (map.getDistance(pointA, pointB)).toFixed(2) + "米<br>无权修改，请靠近");
                       }


                       marker.addEventListener("click", function () {
                           map.openInfoWindow(infoWindow, point); //开启信息窗口
                       });
                   }

               }
               //$('#dg').datagrid('loadData', oData);
               //$.mobile.go('#p2');
               //refresh(lng, lat, msg, lasttime);双击中调用
           } else {
               oData = eval("(" + data + ")")
               alert(oData.err);
               $.mobile.go('#p2');
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
        polyline.disableMassClear();
        map.addOverlay(polyline);   //增加折线
    }

    //加标注
    var img = GetVehilceImg(speed, direction);
    var icon = new BMap.Icon(img, new BMap.Size(25, 25));
    var marker = new BMap.Marker(point, { icon: icon });  // 创建标注
    marker.disableMassClear();
    map.addOverlay(marker);
    map.panTo(point);

    //加标签
    var opts = {
        position: point,    // 指定文本标注所在的地理位置
        offset: new BMap.Size(10, -10)    //设置文本偏移量
    }
    var label = new BMap.Label(car + "<br>" + lasttime, opts);  // 创建文本标注对象
    label.disableMassClear();
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
        $.post("api.ashx",
        { api: 'getBaiduPoi', lng: lng, lat: lat },
        function (data) {
            if (data != 0) {
                if (data.substr(2, 3) != "err") {
                    var poi = data;
                    window.app_para[2] = poi;
                    infoWindow.content = msg + "<br>位置：" + poi;
                    map.openInfoWindow(infoWindow, point); //开启信息窗口
                } else {
                    oData = eval("(" + data + ")")
                    alert(oData.err);
                }
            } else {
                alert("资料错误或页面过期!");
            }
        }
        )

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
function setting() {
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
function TranslateDirection(direction) {
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

function getBaiduPoi(lng, lat) {
    var retval = "";
    $.post("api.ashx",
   { api: 'getBaiduPoi', lng: lng, lat: lat },
   function (data) {
       var retval = "";
       if (data != 0) {
           //alert(data.length);
           if (data.substr(2, 3) != "err") {
               oData = eval("(" + data + ")")
               retval = oData;
           } else {
               oData = eval("(" + data + ")")
               alert(oData.err);
           }
       } else {
           alert("资料错误或页面过期!");
       }
   }
   )
    return retval;
}

//元素点击事件
function goMenu() {
    window.location.href = "/page/index.html";
}

//车牌号输入框初始化
function input_init() {
    //api接口需要用户名密码
    $('#input_car').combobox({
        onBeforeLoad: function (param) {
            param.usr = usr;
            param.pwd = pwd;
        }
    });
}

//程序间带参数引用
function run_app() {
    //存到cookie中，等url程序启动来查找再处理    
    var anchor = 'p4';
    var data = window.app_para;
    var url = 'region.aspx';
    $.cookie('go_region_anchor', anchor, { expires: 1 });
    $.cookie('go_region_data', data, { expires: 1 });
    //向服务器请求页面
    window.open(url);
}
//程序间带参数引用
function run_app1() {
    //存到cookie中，等url程序启动来查找再处理    
    var anchor = 'p4';
    var data = window.app_para1;
    var url = 'region.aspx';
    $.cookie('go_region_anchor1', anchor, { expires: 1 });
    $.cookie('go_region_data1', data, { expires: 1 });
    //向服务器请求页面
    window.open(url);
}
loginInfo();
map_init();
input_init();
