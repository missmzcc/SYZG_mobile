<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="history_park.aspx.cs" Inherits="_01.history_park" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    	<style type="text/css">
	body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
	</style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=fmee6euzFj8GWL63WGXOqGmQ"></script>
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/metro/easyui.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/mobile.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/icon.css">  
    <link rel="stylesheet" type="text/css" href="lib/jquery-easyui-1.4.4/themes/color.css">
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.min.js"></script>  
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.min.js"></script> 
    <script type="text/javascript" src="lib/jquery-easyui-1.4.4/jquery.easyui.mobile.js"></script> 
    <script src="lib/jquery-easyui-1.4.4/locale/easyui-lang-zh_CN.js"></script>
    <title>停车信息</title>
</head>
<body>

    <div id="p1" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">历史停车查询</div>
                 <div class="m-left">                    <a href="group.html" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" ><span class="l-btn-left"><span class="l-btn-text">返回</span></span></a>                </div>                
            </div>
        </header>
        <div style="margin:50px 0 0;text-align:left;">
            <div style ="padding-left:25px">
                <div>
                    <p>车牌号</p>
                    <input id="input_car" class="easyui-combobox" name="input_car" 
                        data-options="required:true,valueField:'VehicleId',textField:'VehicleId',mode:'remote',url:'api.ashx?api=getFilterVehicleId&car='" />                               
			    </div>
                <div>
                    <p>开始时间</p>
                    <input id="beginTime" class="easyui-datetimebox" data-options="required:true,showSecond:true,width:200" />
                </div>
                 <div>
                    <p>结束时间</p>
                    <input id="endTime" class="easyui-datetimebox" data-options="required:true,showSecond:true,width:200" />
                </div>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" onclick="qry_car();" class="easyui-linkbutton c6" style="width:100%;height:33px;">地图详情</a>                
            </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" style="width:100px;height:30px" onclick="$.mobile.go('#p2')">Goto Panel2</a>--%>
        </div>
	</div>
    <div id="p3" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">地图信息查询</div>
                <div class="m-left">
					<a href="#" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" data-options="plain:true,outline:true,back:true" group="" id="A3"><span class="l-btn-left"><span class="l-btn-text">Back</span></span></a>
				</div>
                <div class="m-right">
                    <a href="javascript:void(0)" onclick="$.mobile.go('#p3');" class="easyui-linkbutton m-next l-btn l-btn-small l-btn-plain l-btn-outline" plain="true" outline="true" group="" id="A1"><span class="l-btn-left"><span class="l-btn-text">设置</span></span></a>
                </div>
    <%--             <div id="toolbar" style="padding:0; position:fixed; bottom:0px; z-index:11;background-color:white;display:block;width:100%">
                     <p>速度<span id="msg_speed" class="">0</span></p>
                </div>--%>
            </div>
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
            <div id ="allmap" style="height:100%"> 
                </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$.mobile.back()">Go Back</a>--%>
        </div>
        <footer>
			<div class="m-toolbar" style="font-size: small;">
                <table style="padding-top: 3px;">
                    <tr>
                        <td>
                            时间
                        </td>
                            <td id="msg_time">-</td>
                        <td>
                            速度
                        </td>
                        <td id="msg_speed">-</td>
                        <td>
                            里程
                        </td>
                        <td id="msg_mileage">-</td>
                        <td>
                            <a href="#" class="easyui-linkbutton c6" style="width:100%">播放</a>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
			</div>
		</footer>
    </div>
    <div id="p2" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">停车查询明细</div>
                <div class="m-left">
					<a href="javascript:void(0)" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" data-options="plain:true,outline:true,back:true" id="A2"><span class="l-btn-left"><span class="l-btn-text">重查</span></span></a>
				</div>
            </div>
        </header>
        <table id="dg">  
        <thead>  
            <tr>  
                <th data-options="field:'a',width:60">停车时刻</th>  
                <th data-options="field:'nMin',width:50">时长</th>  
                <th data-options="field:'poi',width:80,">地点</th>  
            </tr>
        </thead>  
    </table>
    </div>
</body>
</html>
<script src="common.js"></script>
<script src="commonMap.js"></script>
<script src="history_park.js"></script>