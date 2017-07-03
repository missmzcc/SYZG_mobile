<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="history_pos.aspx.cs" Inherits="_01.history_pos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    	<style type="text/css">
	body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
	        .auto-style1 {
                width: 2%;
            }
	</style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=fmee6euzFj8GWL63WGXOqGmQ"></script>
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/metro/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/mobile.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/icon.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/color.css" />
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.min.js"></script>  
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.min.js"></script> 
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.mobile.js"></script> 
    <script src="lib/jquery-easyui-1.4.4/locale/easyui-lang-zh_CN.js"></script>
    <title>历史轨迹查询</title>
</head>
<body>

    <div id="p1" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">历史轨迹查询</div>
                 <div class="m-left">
                    <a href="group.html" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" ><span class="l-btn-left"><span class="l-btn-text">返回</span></span></a>                    
                </div>  
                             
            </div>
        </header>
        <div style="margin:15px 0 0;text-align:left;">
            <div style ="padding-left:25px">
                <div>
                    <p>车牌号</p>
                    <input id="input_car" class="easyui-combobox" name="input_car" 
                        data-options="required:true,valueField:'VehicleId',textField:'VehicleId',mode:'remote',url:'api.ashx?api=getFilterVehicleId&car='" />   
                </div>    
                <div>
                    <p>开始时间:</p>
                    <input id="startTime" class="easyui-datetimebox" data-options="value:'<%=DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") %>',editable: true, required: true, showSeconds: false">
                </div> 
                <div>
                    <p>结束时间:</p>
                    <input id="endTime" class="easyui-datetimebox" data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>',editable: true, required: true, showSeconds: false">
                </div>                        
			</div>
            <div style="padding:20px">
                <a href="javascript:void(0)" onclick="qry_pos();$.mobile.go('#p2');" class="easyui-linkbutton c6" style="width:100%;height:33px;">地图详情</a>                
            </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" style="width:100px;height:30px" onclick="$.mobile.go('#p2')">Goto Panel2</a>--%>
        </div>
	</div>

    <div id="p2" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">历史轨迹查询</div>
                <div class="m-left">
                    <a href="#" class="easyui-linkbutton m-back" data-options="plain:true,outline:true,back:true">重查</a>
                </div>
                <div class="m-right">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-next l-btn l-btn-small l-btn-plain l-btn-outline" plain="true" outline="true" group="" id="A1" onclick="$.mobile.go('#p3')"><span class="l-btn-left"><span class="l-btn-text">数据</span></span></a>
                </div>
            </div>            
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
            <div id ="allmap" style="height:100%">                 
                 
             </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$.mobile.back()">Go Back</a>--%>
            <%--<div style="position:fixed; bottom:0; z-index:11;background-color:white;display:block; left: 0; width: 100%; height:3%;">--%>
            <%--<div class="m-title">
                                <label id="Info"></label>
                <span style="float:right">
                    <img id="startplay" src="images/start_play.png" onclick="javascript:start_play()" />
                    <img id="stopplay" src="images/stop_play.png" onclick="javascript:stop_play()" />
                </span>
            </div>--%>
         </div>
        <footer>
			<div class="m-toolbar" style="font-size: small;">
                <table style="padding-top: 3px;">
                    <tr >
                        <td style="width:30px" >
                           <span style="width:100%;height:100%;">时间</span>
                        </td>
                        <td style="width:60px" >
                            <input type="text" style="border-style: none; border-color: inherit; border-width: 0; width:100%; height: 25px;"  id="time" />
                        </td>
                        <td style="width:30px" >
                            <span style="width:100%;height:100%;">速度</span>
                        </td>
                        <td style="width:40px" >
                                <input type="text" style="border-style: none; border-color: inherit; border-width: 0; width:100%; height: 29px;" id="speed" />
                        </td>
                        <%--<td>
                            里程
                        </td>
                        <td id="msg_mileage">-</td>--%>
                        <td class="auto-style1">
                            <%--<a href="#" class="easyui-linkbutton c6" style="width:100%">播放</a>--%>
                            <img id="startplay" src="images/start_play.png" style="width:29px; height:29px;padding-top: 5px;" onclick="javascript:start_play()"/>
                            </td>
                        <td class="auto-style1">
                            <img id="stopplay" src="images/stop_play.png" style="width:29px; height:29px;padding-top: 5px;" onclick="javascript:stop_play()" />
                        </td>
                    </tr>
                </table>
			</div>
		</footer>


    </div>
    <div id="p3" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" plain="true" outline="true" onclick="$.mobile.back()" group="" id="A2"><span class="l-btn-left"><span class="l-btn-text">地图</span></span></a>                    
                </div>  
            </div>
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
               <table id="dg" data-options="header:'#hh',singleSelect:true,border:false,fit:true,fitColumns:true,scrollbarSize:0">  
        <thead>  
            <tr>  
                <th data-options="field:'it',width:20,align:'right'">序号</th>
                <th data-options="field:'recordtime',width:120,align:'center'">时间</th>  
                <%--<th data-options="field:'lng',width:40">经度</th>  
                <th data-options="field:'lat',width:40,align:'right'">纬度</th>  --%>
                <th data-options="field:'speed',width:20,align:'center'">速度</th> 
                
            </tr>
        </thead>  
    </table>
        </div>
    </div>
</body>
</html>
<script src="common.js"></script>
<script src="commonMap.js"></script>
<script src="history_pos.js"></script>
<script type="text/javascript">
    var data = [
        { "productid": "FI-SW-01", "productname": "Koi", "unitcost": 10.00, "status": "P", "listprice": 36.50, "attr1": "Large", "itemid": "EST-1" },
        { "productid": "K9-DL-01", "productname": "Dalmation", "unitcost": 12.00, "status": "P", "listprice": 18.50, "attr1": "Spotted Adult Female", "itemid": "EST-10" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 38.50, "attr1": "Venomless", "itemid": "EST-11" },
        { "productid": "RP-SN-01", "productname": "Rattlesnake", "unitcost": 12.00, "status": "P", "listprice": 26.50, "attr1": "Rattleless", "itemid": "EST-12" },
        { "productid": "RP-LI-02", "productname": "Iguana", "unitcost": 12.00, "status": "P", "listprice": 35.50, "attr1": "Green Adult", "itemid": "EST-13" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 158.50, "attr1": "Tailless", "itemid": "EST-14" },
        { "productid": "FL-DSH-01", "productname": "Manx", "unitcost": 12.00, "status": "P", "listprice": 83.50, "attr1": "With tail", "itemid": "EST-15" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 23.50, "attr1": "Adult Female", "itemid": "EST-16" },
        { "productid": "FL-DLH-02", "productname": "Persian", "unitcost": 12.00, "status": "P", "listprice": 89.50, "attr1": "Adult Male", "itemid": "EST-17" },
        { "productid": "AV-CB-01", "productname": "Amazon Parrot", "unitcost": 92.00, "status": "P", "listprice": 63.50, "attr1": "Adult Male", "itemid": "EST-18" }
    ];
    //datagrid初始化
    function datagrid_init() {
        window.dg = $('#dg').datagrid({
            data: data,
            idField: 'a',
            header: '#hh',
            singleSelect: true,
            border: false,
            //pagination: true,
            fit: true,
            fitColumns: true,
            scrollbarSize: 0,
            onDblClickRow: function (rowIndex, rowData) {
                //alert(rowData.lng);
                var msg = "时间：" + rowData.recordtime + "<br>速度：" + rowData.speed;
                $.post("api.ashx",
                        { api: 'getBaiduPoi', lng: rowData.lng, lat: rowData.lat },
                        function (data) {
                            if (data != null && data != "") {
                                msg = msg + "<br>地址：" + data;
                                refresh(rowData.lng, rowData.lat, msg, rowData.recordtime)
                                $.mobile.go('#p2');
                            }
                        });
            }
        });
        //window.pg = $('#dg').datagrid('getPager');
        //$('.datagrid-pager').pagination({
        //    onSelectPage: function (pageNumber, pageSize) {
        //        $(this).pagination('loading');
        //        //alert('pageNumber:' + pageNumber + ',pageSize:' + pageSize);            
        //        qry_pos();
        //        $(this).pagination('loaded');
        //    }
        //});
    }
	</script>
