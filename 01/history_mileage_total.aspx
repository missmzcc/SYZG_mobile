<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="history_mileage_total.aspx.cs" Inherits="_01.history_mileage_total" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    	<style type="text/css">
	body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
	        .auto-style1 {
                width: 2%;
            }
	</style>
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=fmee6euzFj8GWL63WGXOqGmQ"></script>
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/metro/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/mobile.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/icon.css" />  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/color.css" />
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.min.js"></script>  
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.min.js"></script> 
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.mobile.js"></script> 
    <script src="lib/jquery-easyui-1.4.4/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <div id="p1" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">历史里程查询</div>
                 <div class="m-left">
                    <a href="group.html" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" ><span class="l-btn-left"><span class="l-btn-text">返回</span></span></a>                    
                </div>  
                             
            </div>
        </header>
        <div style="margin:15px 0 0;text-align:left;">
            <div style ="padding-left:25px">                <div>
                    <p>车牌号</p>                    <input style="" id="input_car" class="easyui-combobox" name="input_car" 
                            data-options="required:true,valueField:'VehicleId',textField:'VehicleId',mode:'remote',url:'api.ashx?api=getFilterVehicleId&car='" />                   </div>
                <div>
                    <p>开始时间</p>
                    <input id="startTime" class="easyui-datetimebox"  data-options="required:true,editable:true"/>
                </div>
                <div>
                    <p>结束时间</p>
                    <input id="endTime" class="easyui-datetimebox"  data-options="required:true,editable:true"/>
                </div>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" onclick="qry_mileage();$.mobile.go('#p2');" class="easyui-linkbutton c6" style="width:100%;height:33px;">查询</a>       
            </div>
        </div>      
    </div>
    <div id="p2" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div id="vehicleNum" class="m-title">历史里程查询</div>
                 <div class="m-left">
                    <a class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline"  onclick="$.mobile.back()" id="A1"><span class="l-btn-left"><span class="l-btn-text">重查</span></span></a>                    
                </div>  
                             
            </div>
        </header>
            <div style="margin:0px 0 0;text-align:center;height:100%;">
               <table id="Table2" data-options="header:'#hh',singleSelect:true,border:false,fit:true,fitColumns:true,scrollbarSize:0">                  <thead>                      <tr hidden="hidden">                          <th data-options="field:'mileage_name',width:40,align:'right'"></th>                        <th data-options="field:'mileage_value',width:120,align:'center'"></th>                                     </tr>                </thead>                 </table>
           </div>
    </div>
</body>
</html>
<script src="history_mileage_total.js"></script>
<script type="text/javascript">    var data = [        { "mileage_name": "里程", "mileage_value": "" },        { "mileage_name": "开始时间", "mileage_value": "" },        { "mileage_name": "结束时间", "mileage_value": "" },        { "mileage_name": "时长", "mileage_value": "" },        { "mileage_name": "平均速度", "mileage_value": "" }    ];    //datagrid初始化
    function datagrid_init() {
        window.dg = $('#Table2').datagrid({
            data: data,
            idField: 'a',
            header: '#hh',
            singleSelect: true,
            border: false,
            //pagination: true,
            fit: true,
            fitColumns: true,
            scrollbarSize: 0,
        });
    }	</script>

