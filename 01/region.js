var user = {
    usr: "",
    pwd: ""
};
var car = "";
var dg;//datagrid
var pg;//分页控件
var editIndex = undefined;
var url = "";
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

//datagrid初始化
function datagrid_init() {
    window.dg = $('#dg').datagrid({
        idField: 'Id',
        header: '#hh',
        singleSelect: true,
        border: false,
        pagination: true,
        fit: true,
        fitColumns: true,
        scrollbarSize: 0,
        onDblClickRow: function (rowIndex, rowData) {
            //alert(rowData.lng);
            var state = "";
            switch (rowData.state) {
                case "R":
                    state = "Red(异常)"
                    break;
                case "Y":
                    state = "Yellow(待确)"
                    break;
                case "G":
                    state = "Green(正常)"
                    break;
                default:
                    break;
            }
            var msg = "区域编号：" + rowData.Id + "<br>区域名称：" + rowData.regName +
                "<br>区域位置：" + rowData.regAddress + "<br>区域状态：" + state +
                "<br><a href='javascript:void(0)' onclick='edit();' >修改标注</a> ";
            refresh(rowData.regLongitude, rowData.regLatitude, msg, rowData.insertTime, rowData.regRadius, rowData.state)
            $.mobile.go('#p3');
        },
        onClickRow: onClickRow

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

//车牌号输入框初始化
function input_init() {
    //api接口需要用户名密码
    $('#input_car').combobox({
        onBeforeLoad: function (param) {
            param.usr = user.usr;
            param.pwd = user.pwd;
        }
    });
    //api接口需要用户名密码
    $('#unitId').combobox({
        onBeforeLoad: function (param) {
            param.usr = user.usr;
            param.pwd = user.pwd;
        }
        //onLoadSuccess: function (data) {
        //    if (data) {
        //        $('#unitId').combobox('setValue',data[0].NodeId);//会自动补全值，不采用
        //    }
        //}
    });
    setTimeout(function () {
        $('#beginTime').datetimebox('setValue', new Date().toLocaleDateString().replace(/\//, "-") + " 0:0:0");
        $('#endTime').datetimebox('setValue', new Date().toLocaleDateString().replace(/\//, "-") + " 23:59:59");
        //设定默认值
        $('#unitId').combobox('reload');
        //var unitData = $('#unitId').combobox('getValue');
        //if (unitData) {
        //    $('#unitId').combobox('select', unitData[0].unitId);
        //}
    }, 0);

}

//重查询
function qry_pos() {
    var rows = window.pg.pagination('options').pageSize;
    var page = window.pg.pagination('options').pageNumber;
    var id = $('#input_car').combobox('getValue');
    var reg_state = $('#input_state').combobox('getValue');
    var begin_time = $('#beginTime').datetimebox('getValue');
    var end_time = $('#endTime').datetimebox('getValue');
    $.post("api.ashx",
   { api: 'region', state: "q", usr: user.usr, pwd: user.pwd, page: page, rows: rows, id: id, reg_state: reg_state, begin_time: begin_time, end_time: end_time },
   function (Result) {
       var result = JSON.parse(Result);
       if (result.success) {
           var data = result.data;
           $('#dg').datagrid('loadData', data);
           $.mobile.go('#p2');
           //refresh(lng, lat, msg, lasttime);双击中调用
       } else {
           $.popAlert(result.message);
       }
   }
   );
}

//地图初始化
function map_init() {
    $('#input_car').val(car);
    $.map_init(map);
}

//重查后刷新
function refresh(lng, lat, msg, lasttime, radius, state) {
    map.clearOverlays();

    //加标注
    var new_point = new BMap.Point(lng, lat);
    switch (state) {
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
    var marker = new BMap.Marker(new_point, { icon: myIcon });  // 创建标注   
    map.addOverlay(marker);
    map.panTo(new_point);

    //加标签
    var opts = {
        position: new_point,    // 指定文本标注所在的地理位置
        offset: new BMap.Size(10, -10)    //设置文本偏移量
    }
    var label = new BMap.Label("创建时间" + "<br>" + lasttime, opts);  // 创建文本标注对象
    map.addOverlay(label);

    //创建圆
    if (radius > 0) {
        var circle = new BMap.Circle(new_point, radius, { strokeColor: "blue", strokeWeight: 2, strokeOpacity: 0.5 });
        map.addOverlay(circle);            //增加圆
    }

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
function add() {
    //navigator.geolocation.getCurrentPosition(getPositionSuccess, getPositionError, position_option);
    //$('#p4').dialog('open').dialog('center').dialog('setTitle', 'Edit User');
    $.mobile.go('#p4');
    $('#fm').form('reset');
    //单位默认第一个
    var unitdata = $('#unitId').combobox('getData');
    if (unitdata) {
        $('#unitId').combobox('select', unitdata[0].NodeId);
    }
    url = 'api.ashx?api=region&state=c'
}
function edit() {
    var row = $('#dg').datagrid('getSelected');
    if (row) {
        //$('#p4').dialog('open').dialog('center').dialog('setTitle', 'Edit User');
        $.mobile.go('#p4');
        $('#fm').form('load', row);

        //重新下载下拉列表数据
        var url_new = "api.ashx?api=getFilterUnitId&q=" + $('#unitId').combobox('getValue');
        $.post(url_new, { usr: usr, pwd: pwd }, function (data) {
            if (data) {
                var unitList = eval("(" + data + ")");
                $('#unitId').combobox('loadData', unitList);
            }
        });

        url = 'api.ashx?api=region&state=e';
    }
}
function endEditing() {
    if (editIndex == undefined) { return true }
    if ($('#dg').datagrid('validateRow', editIndex)) {
        $('#dg').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function onClickRow(index) {
    //if (editIndex != index){
    //    if (endEditing()){
    //        $('#dg').datagrid('selectRow', index)
    //                .datagrid('beginEdit', index);
    //        editIndex = index;
    //    } else {
    //        $('#dg').datagrid('selectRow', editIndex);
    //    }
    //}
}
function removeit() {
    var row = $('#dg').datagrid('getSelected');
    if (row) {
        url = 'api.ashx?api=region&state=d';
        $.post(url, { Id: row.Id, usr: usr, pwd: pwd },
            function (data) {
                if (data != 0) {
                    if (data.substr(2, 3) != "err") {
                        oData = eval("(" + data + ")");
                        alert(oData.message);
                        //$('#dg').datagrid('reload');//url方式
                        qry_pos();;
                    } else {
                        oData = eval("(" + data + ")");
                        alert(oData.err);
                    }

                } else {
                    alert("资料错误或页面过期!");
                }
            }
        )
    };
    if (editIndex == undefined) { return }
    $('#dg').datagrid('cancelEdit', editIndex)
            .datagrid('deleteRow', editIndex);
    editIndex = undefined;
}
function accept() {
    var regName = $('#regName').textbox('getValue');
    if (regName == "") {
        alert("请输入区域名称！");
        return;
    }
    var unitId = $('#unitId').combobox('getValue');
    if (unitId == "") {
        alert("请选择所属单位！");
        return;
    }
    if (endEditing()) {
        $('#fm').form('submit', {
            url: url,
            onSubmit: function () {
                // do some check    
                // return false to prevent submit;    
            },
            success: function (data) {
                var data = eval('(' + data + ')');  // change the JSON string to javascript object    
                if (data.success) {
                    alert(data.message);
                    if (data.IDENTITY) {
                        $('#Id').textbox('setValue', data.IDENTITY);
                    }
                    //$('#dg').datagrid('reload');//url方式
                    qry_pos();
                }
            }
        });
    }
}
function reject() {
    $('#dg').datagrid('rejectChanges');
    editIndex = undefined;
}

var position_option = {
    enableHighAccuracy: true,
    maximumAge: 30000,
    timeout: 20000
};

//取得当前经纬度
function getPositionSuccess(position) {
    var lat = position.coords.latitude;
    var lng = position.coords.longitude;
    alert("您所在的位置GPS坐标： 纬度" + lat + "，经度" + lng);

    setTimeout(function () {
        var ggPoint = new BMap.Point(lng, lat);
        var convertor = new BMap.Convertor();
        var pointArr = [];
        pointArr.push(ggPoint);
        convertor.translate(pointArr, 1, 5, translateCallback)
    }, 1000);
    if (typeof position.address !== "undefined") {
        var country = position.address.country;
        var province = position.address.region;
        var city = position.address.city;
        //alert(' 您位于 ' + country + province + '省' + city + '市');
        $('#regAddress').textbox('setValue', country + province + '省' + city + '市');
    }
}
//coords其他返回信息：
//coords.accuracy：返回经纬度的精度（米）
//coords.speed :速度
//coords.altitude ：当前的高度，海拔（米）
//coords.altitudeAccuracy：高度的精度（米）
//coords.heading：朝向
function getPositionError(error) {
    switch (error.code) {
        case error.TIMEOUT:
            alert("连接超时，请重试");
            break;
        case error.PERMISSION_DENIED:
            alert("您拒绝了使用位置共享服务，查询已取消");
            break;
        case error.POSITION_UNAVAILABLE:
            alert("获取位置信息失败");
            break;
    }
}

//坐标转换完之后的回调函数
translateCallback = function (data) {
    if (data.status === 0) {
        //var marker = new BMap.Marker(data.points[0]);
        //bm.addOverlay(marker);
        //var label = new BMap.Label("转换后的百度坐标（正确）", { offset: new BMap.Size(20, -10) });
        //marker.setLabel(label); //添加百度label
        //bm.setCenter(data.points[0]);
        $('#regLongitude').textbox('setValue', data.points[0].lng);
        $('#regLatitude').textbox('setValue', data.points[0].lat);
    }
}

//如果缓存中存在启动参数，则处理
function app_init() {
    //调用新增
    if ($.cookie('go_region_anchor')) {
        if ($.cookie('go_region_data')) {
            var anchor = '#' + $.cookie('go_region_anchor');
            var data_cookie = $.cookie('go_region_data');
            var data = data_cookie.split(",");
            if (data) {
                if (anchor) {
                    setTimeout(function () {
                        $.mobile.go(anchor);
                        $('#fm').form('reset');
                        $('#regLongitude').numberbox('setValue', data[0]);
                        $('#regLatitude').numberbox('setValue', data[1]);
                        $('#regAddress').textbox('setValue', data[2]);
                        //单位默认第一个
                        var unitdata = $('#unitId').combobox('getData');
                        if (unitdata) {
                            $('#unitId').combobox('select', unitdata[0].NodeId);
                        }
                        url = 'api.ashx?api=region&state=c'
                        $.removeCookie('go_region_anchor');
                        $.removeCookie('go_region_data');
                    },
                    1000);
                }
            }
        }
    }
    //调用修改
    if ($.cookie('go_region_anchor1')) {
        if ($.cookie('go_region_data1')) {
            var anchor = '#' + $.cookie('go_region_anchor1');
            var data_cookie = $.cookie('go_region_data1');
            var data = data_cookie.split(",");
            if (data) {
                if (anchor) {
                    setTimeout(function () {
                        $.mobile.go(anchor);
                        $('#fm').form('reset');
                        $('#Id').textbox('setValue', data[0]);
                        $('#regId').textbox('setValue', data[1]);
                        $('#regName').textbox('setValue', data[2]);
                        $('#regLongitude').numberbox('setValue', data[3]);
                        $('#regLatitude').numberbox('setValue', data[4]);
                        $('#regRadius').numberbox('setValue', data[5]);
                        $('#regAddress').textbox('setValue', data[6]);
                        $('#unitId').textbox('setValue', data[7]);
                        $('#regionState').combobox('setValue', data[9]);
                        //$('#regId').combobox('setText', data[10]);
                        //var regId_data = new { NodeId: data[1], NodeName: [10] };
                        //参考
                        //window.app_para1[0] = oData.rows[i].Id;
                        //window.app_para1[1] = oData.rows[i].regId;
                        //window.app_para1[2] = oData.rows[i].regName;
                        //window.app_para1[3] = oData.rows[i].regLongitude;
                        //window.app_para1[4] = oData.rows[i].regLatitude;
                        //window.app_para1[5] = oData.rows[i].regRadius;
                        //window.app_para1[6] = oData.rows[i].regAddress;
                        //window.app_para1[7] = oData.rows[i].unitId;
                        //window.app_para1[8] = oData.rows[i].insertTime;
                        //window.app_para1[9] = oData.rows[i].state;
                        //window.app_para1[10] = $('#regId').combobox('getText');
                        url = 'api.ashx?api=region&state=e'
                        $.removeCookie('go_region_anchor1');
                        $.removeCookie('go_region_data1');
                    },
                    1000);
                }
            }
        }
    }
}

//绘制工具管理库
var overlays = [];
var curOverlay;
var overlaycomplete = function (e) {
    overlays.push(e.overlay);
};
var styleOptions = {
    strokeColor: "red",    //边线颜色。
    fillColor: "red",      //填充颜色。当参数为空时，圆形将没有填充效果。
    strokeWeight: 3,       //边线的宽度，以像素为单位。
    strokeOpacity: 0.8,	   //边线透明度，取值范围0 - 1。
    fillOpacity: 0.6,      //填充的透明度，取值范围0 - 1。
    strokeStyle: 'solid' //边线的样式，solid或dashed。
}
//实例化鼠标绘制工具
var drawingManager = new BMapLib.DrawingManager(map, {
    isOpen: false, //是否开启绘制模式
    enableDrawingTool: true, //是否显示工具栏
    drawingToolOptions: {
        anchor: BMAP_ANCHOR_TOP_RIGHT, //位置
        offset: new BMap.Size(150, 5), //偏离值
        scale: 0.6,//缩放值
        drawingModes: [BMAP_DRAWING_MARKER],
        drawingTypes: [
        BMAP_DRAWING_MARKER,
        BMAP_DRAWING_CIRCLE,
        BMAP_DRAWING_POLYLINE,
        BMAP_DRAWING_POLYGON,
        BMAP_DRAWING_RECTANGLE
        ]
    },
    circleOptions: styleOptions, //圆的样式
    polylineOptions: styleOptions, //线的样式
    polygonOptions: styleOptions, //多边形的样式
    rectangleOptions: styleOptions //矩形的样式
});
//添加鼠标绘制工具监听事件，用于获取绘制结果
drawingManager.addEventListener('overlaycomplete', overlaycomplete);
function clearAll() {
    for (var i = 0; i < overlays.length; i++) {
        map.removeOverlay(overlays[i]);
    }
    overlays.length = 0
}
//存储起来用作新点新增或修改经纬度用
drawingManager.addEventListener("markercomplete", function (e, overlay) {
    //alert(overlay);
    clearAll();
    curOverlay = overlay;
});
function curOverlay2form() {
    $('#regLongitude').textbox('setValue', curOverlay.point.lng);
    $('#regLatitude').textbox('setValue', curOverlay.point.lat);
}

//触摸处理初始化
function hammer_init() {
    //jq语法，需要jquery.hammer.js库
    //$("#p1").hammer().bind('tap', function (e) { alert("tap ok"); });
    //$("#p1").hammer().bind('press', function (e) { alert("press ok"); });
    //$("#p1").hammer().bind('swipleft', function (e) { alert("swipleft ok"); });
    //$("#p1").hammer().bind('swipe', function (e) { alert("swipedown ok"); });

    //js语法
    //创建一个新的hammer对象并且在初始化时指定要处理的dom元素
    //var hammertime = new Hammer(document.getElementById("p1"));
    //为该dom元素指定触屏移动事件
    //hammertime.on("swipe", function (ev) {
    //控制台输出
    //console.log(ev);
    //alert('swipe');
    //});
    //FastClick.attach(document.body);
}




//加载
loginInfo();
map_init();
datagrid_init();
input_init();
setTimeout(app_init(), 0);
setTimeout(hammer_init(), 100);