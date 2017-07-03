var user = {
    usr: "",
    pwd: ""
};
var car = "";
var dg;//datagrid
var pg;//分页控件
// 百度地图API功能
var map = new BMap.Map("allmap");    // 创建Map实例
/***** 全局变量 end *****/

//权限验证
function loginInfo() {
    $.loginInfo(user);
    timeInit();
}

//时间初始化
function timeInit() {
    var now = new Date();
    var yes = new Date(now.getTime() - 86400000);
    $("#beginTime").datetimebox({value: yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00"});
    $("#endTime").datetimebox({value: now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59"});
}

//地图初始化
function map_init() {
    $('#input_car').val(car);
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

//重查询
function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }
    var rows = window.pg.pagination('options').pageSize
    var page = window.pg.pagination('options').pageNumber
    var beginTime = $("#beginTime").datetimebox("getValue");
    var endTime = $("#endTime").datetimebox("getValue");
    $.post("api.ashx",
    { api: 'history_park', usr: user.usr, pwd: user.pwd, car: car, begin_time: beginTime, end_time: endTime, page: page, rows: rows },
    function (Result) {
        var result = JSON.parse(Result);
        if (result.success) {
            $('#dg').datagrid('loadData', result.data);
            $.mobile.go('#p2');
            var datas = result.data.rows;
            var leng = datas.length;
            for (var i = 0; i < leng; i++) {
                var Data = datas[i];
                refresh(Data.lng, Data.lat, Data.a, Data.b);//需重写
            }
        } else {
            alert(result.message);
        }
   });
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
    var opts1 = {
        width: 200,     // 信息窗口宽度
        height: 100,     // 信息窗口高度
        title: "GPS信息", // 信息窗口标题
        enableMessage: true//设置允许信息窗发送短息
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
        pageSize: 10,
        pageList:[10,20],
        fit: true,
        fitColumns: true,
        scrollbarSize: 0
    });
    window.pg = $('#dg').datagrid('getPager');
    $('.datagrid-pager').pagination({
        onSelectPage: function (pageNumber, pageSize) {
            qry_pos();
        }
    });
}

//加载
loginInfo();
map_init();
datagrid_init();