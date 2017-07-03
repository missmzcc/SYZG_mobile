<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mark_manager.aspx.cs" Inherits="_01.mark_manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
	    body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;font-family:"微软雅黑";}
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
    <title>标注点管理</title>
</head>
<body>
    <div id="p1" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">标注点管理</div>
                 <div class="m-left">                    <a href="group.html" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline"  ><span class="l-btn-left"><span class="l-btn-text">返回</span></span></a>                </div>                
            </div>
        </header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <div style="margin-bottom:10px;">
                    <h3>归属单位</h3>
                    <input id="units" name="units" style="width:50%;" />
			    </div>
                <table id="listMarkers" style="height:500px;"></table>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" id="mapDetail" class="easyui-linkbutton c6" style="width:100%;height:33px;">地图详情</a>                
            </div>
        </div>
    </div>
    <div id="p2" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">地图信息查询</div>
                <div class="m-left">
					<a href="#" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" data-options="plain:true,outline:true,back:true" id="A3"><span class="l-btn-left"><span class="l-btn-text">Back</span></span></a>
				</div>
            </div>
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
            <div id ="allmap" style="height:100%"></div>
        </div>
    </div>
    <div id="p3" class="easyui-navpanel"></div>
    <script src="common.js"></script>
    <script src="mark_manager.js"></script>
    <script src="commonMap.js"></script>
</body>
</html>