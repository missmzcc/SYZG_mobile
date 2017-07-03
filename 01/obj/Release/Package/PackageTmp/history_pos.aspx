<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="history_pos.aspx.cs" Inherits="_01.history_pos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    	<style type="text/css">
	body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
	</style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=fmee6euzFj8GWL63WGXOqGmQ"></script>
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/metro/easyui.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4//themes/mobile.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/./themes/icon.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/color.css">
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4//jquery.min.js"></script>  
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4//jquery.easyui.min.js"></script> 
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4//jquery.easyui.mobile.js"></script> 
    <title>最后位置</title>
</head>
<body>

    <div class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">历史轨迹查询</div>
                 <div class="m-left">                    <a href="javascript:void(0)" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" plain="true" outline="true" onclick="$.mobile.back()" group="" id=""><span class="l-btn-left"><span class="l-btn-text">Back</span></span></a>                </div>                
            </div>
        </header>
        <div style="margin:50px 0 0;text-align:center">
            <div class="m-toolbar">
                <input id="input_car" class="easyui-combobox" name="input_car" 
                    data-options="valueField:'VehicleId',textField:'VehicleId',mode:'remote',url:'api.ashx?api=getFilterVehicleId&car='" />                               
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
                    <a href="#" class="easyui-linkbutton m-back" data-options="plain:true,outline:true,back:true">Back</a>
                </div>
            </div>
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
            <div id ="allmap" style="height:100%"> 
                </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$.mobile.back()">Go Back</a>--%>
        </div>
    </div>
</body>
</html>
<script src="history_pos.js"></script>