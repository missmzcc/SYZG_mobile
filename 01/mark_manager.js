$(function () {
    var user = {};          //用户信息
    var map;                //地图对象
    //登陆校验
    function loginInfo() {
        $.loginInfo(user);
    }
    //获取单位列表
    function getUnits() {
        $("#units").combobox({
            url: "",
            valueFiled: "value",
            textField: "text",
            onSelect:function(){
                var company = $("#units").combobox("getValue");
            }
        });
    }
    /***** 标注点列表管理 start *****/
    function marksDetail() {
        $('#listMarkers').datagrid({
            url:"",
            striped: true,
            singleSelect: true,
            border: true,
            collapsible: false,          //是否可折叠的
            autoRowHeight: true,
            remoteSort: false,
            pagination: true,            //分页控件
            pageSize: 10,
            pageList: [10, 15, 20, 25, 50],
            rownumbers: true,            //行号
            columns: [[
                { field: 'Id', title: '编号' },
                { field: "regName", title: "名称", editor: { type: "text", options: { required: true, missingMessage: "标注点不能为空" } } },
                { field: "regAddress", title: "地址", editor: { type: "text", options: { required: true, missingMessage: "地址不能为空" } } },
                {
                    field: "state",
                    title: "状态",
                    width: 70,
                    editor: {
                        tyep: 'combobox',
                        options: {
                            valueField: "id",
                            textField: "name",
                            data: [{ id: "R", name: "关注点" }, { id: "G", name: "正常点" }, { id: "Y", name: "待确认点" }],
                            required: false
                        }
                    }
                },
                { field: "regLongitude", title: "经度", editor: { type: "numberbox", options: { precision: 10, required: true, missingMessage: '经度不能为空' } } },
                { field: "regLatitude", title: "纬度", editor: { type: "numberbox", options: { precision: 10, required: true, missingMessage: '纬度不能为空' } } },
            ]],
            onClickCell: function (index, field) {
                if (editIndex != index) {
                    if (endEditing()) {
                        $('#customdg').datagrid('selectRow', index)
                                .datagrid('beginEdit', index);
                        var ed = $('#customdg').datagrid('getEditor', { index: index, field: field });
                        if (ed) {
                            ($(ed.target).data('textbox') ? $(ed.target).textbox('textbox') : $(ed.target)).focus();
                        }
                        editIndex = index;
                    } else {
                        setTimeout(function () {
                            $('#customdg').datagrid('selectRow', editIndex);
                        }, 0);
                    }
                }
            },
            toolbar:
                [{
                    id: "add",
                    text: "新增",
                    iconCls: "icon-add",
                    handler: function () {
                        append();
                    }
                }, "-", {
                    id: "save",
                    text: "保存",
                    iconCls: 'icon-save',
                    handler: function () {
                        accept();
                    }
                }, '-', {
                    id: "del",
                    text: "删除",
                    iconCls: 'icon-cancel',
                    handler: function () {
                        removeit();
                    }
                }, "-", {
                    text: "定位",
                    iconCls: "icon-search",
                    handler: function () {
                        getChanges();
                    }
                }, "-", {
                    text: "撤销",
                    iconCls: "icon-redo",
                    handler: function () {
                        reject();
                    }
                }]
        });
        //分页加载数据
        var pager = $("#listMarkers").datagrid("getPager");
        $(pager).pagination({
            onSelectPage: function () {
                $(this).pagination('loading');
                $(this).pagination('loaded');
                $.post("","",function(data){
                    $(this).datagrid("loadData",data);
                });
            }
        });
    }
    //新增标点
    function append() {
        if (!permissionadd) {
            $.messager.alert('提示', '您没有权限执行此操作');
            reject();
            return;
        }
        if (endEditing()) {
            $('#List2').datagrid('appendRow', { state: 'R', id: 'R' });
            editIndex = $('#List2').datagrid('getRows').length - 1;
            $('#List2').datagrid('selectRow', editIndex)
                    .datagrid('beginEdit', editIndex);
        }
    }
    //删除标点
    function removeit() {
        if (!permissiondel) {
            $.messager.alert('提示', '您没有权限执行此操作');
            reject();
            return;
        }
        $.messager.confirm('确认', '您确认想要删除记录吗？', function (r) {
            if (r) {
                if (editIndex == undefined) { return }
                var id = $('#List2').datagrid('getSelected').Id;
                $.post("/MonitorCenter/DeleteMarker",
                { id: id },
                function (data) {
                    if (data == "0") {
                        $.messager.alert('提示', '对不起，删除失败！');
                    } else {
                        var allOverlay = m_Map.getOverlays();
                        for (var i = 0; i < allOverlay.length - 1; i++) {
                            try {
                                if (allOverlay[i].getLabel().content == id) {
                                    m_Map.removeOverlay(allOverlay[i]);
                                }
                            } catch (e) {

                            }
                        }
                        $.post("/MonitorCenter/GetPurchaseOrder", { pageNum: 1, pageSize: 10 },
                             function (data) {
                                 Marker = data;
                                 $('#List2').datagrid('loadData', Marker);
                             }
                         );
                        var allOverlay = m_Map.getOverlays();
                        for (var i = 0; i < allOverlay.length; i++) {
                            try {
                                if (allOverlay[i].getLabel().content == id) {
                                    m_Map.removeOverlay(allOverlay[i]);
                                }
                            } catch (e) {

                            }
                        }
                    }
                });
                $('#List2').datagrid('cancelEdit', editIndex)
                        .datagrid('deleteRow', editIndex);
                editIndex = undefined;
            }
        });
    }
    //定位
    function getChanges() {
        var regLongitude = $('#List2').datagrid('getSelected').regLongitude;
        var regLatitude = $('#List2').datagrid('getSelected').regLatitude;
        if (m_Map == null) {
            m_Map = new BMap.Map(div);               // 创建Map实例
        }
        var new_point = new BMap.Point(regLongitude, regLatitude);
        m_Map.panTo(new_point);
        $('#List2').datagrid('rejectChanges');
        editIndex = undefined;
    }

    //撤销
    function reject() {
        $('#List2').datagrid('rejectChanges');
        editIndex = undefined;
    }
    function accept() {
        endEditing();
        var inrows = $('#List2').datagrid('getChanges', 'inserted');
        var uprows = $('#List2').datagrid('getChanges', 'updated');
        unitId = $('#Company').combobox('getValue');
        if (unitId == "" || unitId == null) {
            $.messager.alert('提示', '请选择单位');
            return;
        }
        var newaddid = "";
        var newupid1 = "";
        var newupid2 = "";
        if (!permissionadd) {
            inrows = "";
        }
        if (!permissionsave) {
            uprows = "";
        }
        if (inrows.length > 0) {
            for (var i = 0; i < inrows.length; i++) {
                var regname = inrows[i].regName;
                var longitude = inrows[i].regLongitude;
                var latitude = inrows[i].regLatitude;
                var state = inrows[i].state;
                var address = inrows[i].regAddress;
                if (regname == "" || regname == null || longitude == "" || longitude == null || latitude == "" || latitude == null || state == "" || state == null || address == "" || address == null) {
                    $.messager.alert('提示', '数据不能为空');
                    return;
                }
                $.post("/MonitorCenter/SaveMarker",
                { unitId: unitId, regname: regname, longitude: longitude, latitude: latitude, state: state, address: address },
                function (data) {
                    if (data == "0") {
                        //$.messager.alert('提示', '对不起，新增失败！');
                    } else {
                        for (var iw = 0; iw < inrows.length; iw++) {
                            var radius = '0.000000000000000e+000';
                            addRegion(inrows[iw].regLongitude, inrows[iw].regLatitude, radius, inrows[iw].regName, inrows[iw].state, inrows[iw].regAddress, inrows[iw].Id);
                        }
                    }
                });
            }
        }
        var uplist = JSON.stringify(uprows);
        if (uprows.length > 0) {
            $.ajax({
                url: "/MonitorCenter/UpdateMarker",
                data: { uplist: uplist },
                type: 'post',
                success: function (data) {
                    for (var iw = 0; iw < uprows.length; iw++) {
                        var allOverlay = m_Map.getOverlays();
                        for (var j = 0; j < allOverlay.length; j++) {
                            try {
                                if (allOverlay[j].getLabel().content == uprows[iw].Id) {
                                    m_Map.removeOverlay(allOverlay[j]);
                                }
                            } catch (e) {

                            }
                        }
                        var radius = '0.000000000000000e+000';
                        addRegion(uprows[iw].regLongitude, uprows[iw].regLatitude, radius, uprows[iw].regName, uprows[iw].state, uprows[iw].regAddress, uprows[iw].Id);
                    }
                    $.messager.alert('提示', '更新成功' + data + "条数据");
                }
            });
        }
        if (endEditing()) {
            $('#List2').datagrid('acceptChanges');
        }
        $.post("/MonitorCenter/GetPurchaseOrder", { pageNum: pagenum == null ? 1 : pagenum, pageSize: pagesize == null ? 10 : pagesize },
            function (data) {
                Marker = data;
                $('#List2').datagrid('loadData', Marker);
            }
        );
    }
    /***** 标注点列表管理 end *****/

    /***** 地图详情 start *****/
    //地图初始化
    function mapDetail() {
        map = new BMap.Map("allmap");
        $.map_init(map);
        paintRegion();
    }
    //画区域
    function paintRegion() {
        $.post("url", "data", function (data) {
            if (data) {
                var leng = data.length;
                for (var i = 0; i < leng; i++) {
                    var row = data[i];
                    addRegion(row.mLng, row.mLat, row.mRadius, row.mName, row.mState, row.mAddress, row.mId);
                }
            }
        });
    }
    function addRegion(lng, lat, radius, name, state, address, id) {
        if (name == "" || name == null) {
            return;
        }
        if (radius == '0.000000000000000e+000') {
            var pt = new BMap.Point(lng, lat);
            var myIcon,statename;
            if (state == "R") {
                myIcon = new BMap.Icon("../Images/red.ico", new BMap.Size(16, 16));
                statename = "关注点";
            } else if (state == "Y") {
                myIcon = new BMap.Icon("../Images/yellow.ico", new BMap.Size(16, 16));
                statename = "待确认点";
            } else {
                myIcon = new BMap.Icon("../Images/green.ico", new BMap.Size(16, 16));
                statename = "正常点";
            }
            //显示标注点
            var marker2 = new BMap.Marker(pt, { icon: myIcon });    // 创建标注点
            m_Map.addOverlay(marker2);                              // 将标注添加到地图中
            //弹出框
            var opts = {
                width: 250,             // 信息窗口宽度
                height: 120,            // 信息窗口高度
                title: "标点信息",      // 信息窗口标题
                enableMessage: true     //设置允许信息窗发送短息
            };
            var msg = "编号：" + id + "<br/>名称：" + name + "<br/>状态：" + statename + "<br/>地址：" + address;
            //addClickHandler(msg, marker2, opts);                    //点击标注点弹出信息
            $.openInfoWindow(map,marker2,msg,opts);
        } else {
            var point = new BMap.Point(lng, lat);
            var circle = new BMap.Circle(point, radius, {
                strokeColor: "red",     //圆边线颜色
                fillColor: "red",       //填充颜色
                fillOpacity: 0.35,      //填充透明度
                strokeWeight: 2  //边线宽度
            });
            var hoffset = 0;
            var m = /[\u4E00-\u9FA5]/;
            for (var i = 0; i < name.length; i++) {
                var ch = name[i];
                if (m.test(ch)) {
                    hoffset += 13;
                }
                else {
                    hoffset += 7;
                }
            }
            var label = new BMap.Label(name, { offset: new BMap.Size(-hoffset / 2, -8), position: point });
            label.setStyle({ color: "white", backgroundColor: "#ff7851", border: "1px white solid" });
            m_Map.addOverlay(label);
            m_Map.addOverlay(circle);
        }

    }
    //标注点点击事件-点
    function addClickHandler(content, marker, opts) {
        marker.addEventListener("click", function (e) {
            var p = e.target;
            var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
            map.openInfoWindow(new BMap.InfoWindow(content, opts), point);
        });
    }
    /***** 地图详情 end *****/

    /***** 事件绑定 start *****/
    function bindEvent() {
        $("#mapDetail").click(function () {
            $.mobile.go("#p2");
        });
    }
    /***** 事件绑定 end *****/

    bindEvent();
    //登陆校验
    loginInfo();
    //获取单位列表
    getUnits();
    //加载标注点
    marksDetail();
    //地图详情
    setTimeout(mapDetail,1000);
})
