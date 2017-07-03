var user = {
    usr: "",
    pwd: "",
};
var car = "";
//百度地图初始化
var map = new BMap.Map("allmap");

/***** 全局变量end *****/

//权限验证
function loginInfo() {
    $.loginInfo(user);
}

//查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (!car) {
        alert("车牌号为空！");
        return;
    }
    $.post("api.ashx", { api: 'last_poi', usr: user.usr, pwd: user.pwd, car: car }, function (Result) {
        var result = JSON.parse(Result);
        if (result.success) {
            var data = result.data;
            lng = data.lng;
            lat = data.lat;
            msg = data.msg;
            lasttime = data.lasttime;
            $.mobile.go('#p2');
            setTimeout("refresh(lng, lat, msg, lasttime)", 0);
       } else {
           alert(result.message);
           location.href = "/group.html";
       }
   });
}

//地图初始化
function map_init() {
    $.map_init(map);
}

//重查后刷新
function refresh(lng, lat, msg, lasttime) {
    map.clearOverlays();
    //添加标注
    var new_point = new BMap.Point(lng, lat);
    var marker = new BMap.Marker(new_point);
    map.addOverlay(marker);
    map.panTo(new_point);

    //移动到标注点
    map.panTo(new_point);

    //加标签
    var opts = {
        position: new_point,    // 指定文本标注所在的地理位置
        offset: new BMap.Size(10, -10)    //设置文本偏移量
    }
    var label = new BMap.Label(car + "<br>" + lasttime, opts);  // 创建文本标注对象
    map.addOverlay(label);

    //加信息弹窗
    var point = new BMap.Point(lng, lat);
    var opts1 = {
        width: 200,     // 信息窗口宽度
        height: 100,     // 信息窗口高度
        title: "GPS信息", // 信息窗口标题
        enableMessage: true//设置允许信息窗发送短息
    }
    $.openInfoWindow(map,marker,msg,opts1);
}

//登陆校验
loginInfo();
//地图初始化
map_init();