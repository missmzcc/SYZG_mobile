<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="region.aspx.cs" Inherits="_01.region" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <script src="lib/base/jquery.cookie.js"></script>
    <script src="lib/base/hammer.min.js"></script>
    <script src="lib/base/jquery.hammer.js"></script>
	<!--加载鼠标绘制工具-->
	<script type="text/javascript" src="http://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.js"></script>
	<link rel="stylesheet" href="http://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.css" />
	<!--加载检索信息窗口-->
	<script type="text/javascript" src="http://api.map.baidu.com/library/SearchInfoWindow/1.4/src/SearchInfoWindow_min.js"></script>
	<link rel="stylesheet" href="http://api.map.baidu.com/library/SearchInfoWindow/1.4/src/SearchInfoWindow_min.css" />
    <script src="lib/base/fastclick.js"></script>
    <title>区域管理</title>
</head>
<body>
    <div id="p1" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">区域查询</div>
                 <div class="m-left">                    <a href="group.html" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" onclick="$.mobile.back()"  id="A1"><span class="l-btn-left"><span class="l-btn-text">返回</span></span></a>                </div>                
            </div>
        </header>
        <div style="margin:15px 0 0;text-align:left;">
            <div style ="padding-left:25px">
                <div>
                    <p>区域编号</p>
                    <input id="input_car" class="easyui-combobox" name="input_reg" 
                        data-options="required:false,valueField:'id',textField:'regName',mode:'remote',url:'api.ashx?api=getFilterRegionId&reg='" />                               
			    </div>
                 <div>
                    <p>开始时间</p>
                    <input id="beginTime" class="easyui-datetimebox" style="width:50%" data-options="required:true,editable:true" />
                </div>
                <div>
                    <p>结束时间</p>
                    <input id="endTime" class="easyui-datetimebox" style="width:50%" data-options="required:true,editable:true"/>
                </div>
                <div>
                    <p>状态</p>
                    <select id="input_state" class="easyui-combobox" name="region_state" data-options="required:true,editable:true" style="width:200px;">   
                        <option value="">全部区域</option>
                        <option value="R">异常区域</option>   
                        <option value="G">正常区域</option>   
                        <option value="Y">待确认区域</option>      
                    </select> 
                    <!--input id="Text2" class="easyui-combobox" style="width:50%" data-options="required:true,editable:true"-->
                </div>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" onclick="qry_car();" class="easyui-linkbutton c6" style="width:100%;height:33px;">查询详情</a>                
            </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" style="width:100px;height:30px" onclick="$.mobile.go('#p2')">Goto Panel2</a>--%>
        </div>
	</div>
    <div id="p3" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">地图信息查询</div>
                <div class="m-left">
					<a href="#" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" data-options="plain:true,outline:true,back:true" id="A3"><span class="l-btn-left"><span class="l-btn-text">Back</span></span></a>
				</div>
                <%--<div class="m-right">
                    <a href="javascript:void(0)" onclick="$.mobile.go('#p3');" class="easyui-linkbutton m-next l-btn l-btn-small l-btn-plain l-btn-outline" plain="true" outline="true" group="" id="A1"><span class="l-btn-left"><span class="l-btn-text">设置</span></span></a>
                </div>
                 <div id="toolbar" style="padding:0; position:fixed; bottom:0px; z-index:11;background-color:white;display:block;width:100%">
                     <p>速度<span id="msg_speed" class="">0</span></p>
                </div>--%>
            </div>
        </header>
        <div style="margin:0px 0 0;text-align:center;height:100%;">
            <div id ="allmap" style="height:100%"> 
                </div>
            	<div id="result" style="display:none">
		            <input type="button" value="获取绘制的覆盖物个数" onclick="alert(overlays.length)"/>
		            <input type="button" value="清除所有覆盖物" onclick="clearAll()"/>
	            </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$.mobile.back()">Go Back</a>--%>
        </div>
        <footer>
			<div class="m-toolbar" style="font-size: small;">
			</div>
		</footer>
    </div>
    <div id="p2" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">
                <div class="m-title">区域编辑</div>
                <div class="m-left">
					<a href="#" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline" data-options="plain:true,outline:true,back:true"  id="A2"><span class="l-btn-left"><span class="l-btn-text">重查</span></span></a>
				</div>
                <div class="m-right">
                    <a href="javascript:void(0)" onclick="$.mobile.go('#p3');" class="easyui-linkbutton m-next l-btn l-btn-small l-btn-plain l-btn-outline" id="A4"><span class="l-btn-left"><span class="l-btn-text">地图</span></span></a>
                </div>
            </div>
        </header>
        <table id="dg">  
        <thead>  
            <tr>  
                <th data-options="field:'Id',width:'40px'">编号</th>  
                <th data-options="field:'regName',width:'100px',align:'left'">名称</th>  
                <th data-options="field:'regAddress',width:'60px',align:'right',hidden:'true'">地址</th>  
                <th data-options="field:'unitId',width:'100px',align:'left',hidden:'true'">单位</th> 
                <th data-options="field:'unitName',width:'100px',align:'left',hidden:'true'">单位名称</th> 
                <th data-options="field:'regLongitude',width:'50px',align:'right'">经度</th>  
                <th data-options="field:'regLatitude',width:'50px',align:'right'">纬度</th>  
                <th data-options="field:'state',width:'30px',align:'center',editor:'textbox'">状态</th> 
                <th data-options="field:'insertTime',width:'20px',align:'right',hidden:'true'">时间</th> 
            </tr>
        </thead>  
    </table>
        <div id="hh">
		<div class="m-toolbar">
			<div class="m-title"></div>
			<div class="m-right">
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="add()"></a>
				<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="removeit()"></a>
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true" onclick="edit()"></a>
				<!--a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true" onclick="accept()"></a-->
				<!--a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-undo',plain:true" onclick="reject()"></a-->
			</div>
		</div>
	</div>
    </div>
    <div id="p4" class="easyui-navpanel">
        <header>
            <div class="m-toolbar">                
                <div class="m-title">区域修改</div>
                 <div class="m-left">                    <a href="javascript:void(0)" class="easyui-linkbutton m-back l-btn l-btn-small l-btn-plain l-btn-outline"  data-options="plain:true,outline:true,back:true" onclick="$.mobile.back()" id="A5"><span class="l-btn-left"><span class="l-btn-text">Back</span></span></a>                </div>                
            </div>
        </header>
        <div style="margin:15px 0 0;text-align:left;">
            <div style="padding-left:25px">
            <form id="fm" action = 'api.ashx?state=c' method="post" novalidate>
            <table>
                <tr>
                    <td><label>序号:</label></td>
                    <td><input name="Id" id="Id" class="easyui-textbox" data-options="width:120,readonly:true" required="false" /></td>
                </tr>  
                <tr>
                    <td><label>编号:</label></td>
                    <td><input name="regId" id="regId" class="easyui-textbox" data-options="width:160" required="true" /></td>
                </tr>          
                <tr>
                    <td><label>名称:</label></td>
                    <td><input name="regName" id="regName" class="easyui-textbox" data-options="width:200" required="true" /></td>
                </tr>  
                <tr>
                    <td><label>地址:</label></td>
                    <td><input name="regAddress" id="regAddress" class="easyui-textbox" data-options="width:200" required="true" /></td>
                </tr>    
                <tr>
                    <td><label>单位:</label></td>
                    <td><input name="unitId" id="unitId" class="easyui-combobox"
                        data-options="required:true,valueField:'NodeId',textField:'NodeName',mode:'remote',url:'api.ashx?api=getFilterUnitId&car=',width:150"
                         /></td>
                </tr>      
                <tr>
                    <td><label>经纬度:</label></td>
                    <td><a id="btn""javascript:void(0)" class="easyui-linkbutton" onclick="navigator.geolocation.getCurrentPosition(getPositionSuccess, getPositionError, position_option);" data-options="iconCls:'icon-search',plain:'true'">使用本设备解析的经纬度</a></td>
                </tr>  
                <tr>
                    <td><label></label></td>
                    <td><a id="btn1""javascript:void(0)" class="easyui-linkbutton" onclick="curOverlay2form();" data-options="iconCls:'icon-search',plain:'true'">使用手绘的经纬度</a></td>
                </tr>  
                <tr>
                    <td><label>经度:</label></td>
                    <td><input name="regLongitude" id="regLongitude" class="easyui-numberbox" data-options="min:0,precision:6,value:0,max:360" required="true" /> </td>
                </tr>
                <tr>
                    <td><label>纬度:</label></td>
                    <td><input name="regLatitude" id="regLatitude" class="easyui-numberbox"  data-options="min:0,precision:6,value:0,max:90" required="true" /></td>
                </tr>
                <tr>
                    <td><label>半径:</label></td>
                    <td><input name="regRadius" id="regRadius" class="easyui-numberbox"  data-options="min:0,precision:0,value:0,max:10000" required="false" /></td>
                </tr>
                <tr>
                    <td><label>状态:</label></td>
                    <td>
                        <select id="regionState" class="easyui-combobox" name="region_state" data-options="required:true,editable:true" style="width:200px;">   
                        <option value="R">异常区域</option>   
                        <option value="G">正常区域</option>   
                        <option value="Y">待确认区域</option>      
                        </select> 
                    </td>
                </tr>
            </table>
            </form>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" onclick="accept();" class="easyui-linkbutton c6" style="width:100%;height:33px;">保存资料</a>                
            </div>
            <%--<a href="javascript:void(0)" class="easyui-linkbutton" style="width:100px;height:30px" onclick="$.mobile.go('#p2')">Goto Panel2</a>--%>
        </div>
	</div>
</body>
</html>
<script src="common.js"></script>
<script src="commonMap.js"></script>
<script src="region.js"></script>