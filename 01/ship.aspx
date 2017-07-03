<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ship.aspx.cs" Inherits="_01.ship" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script type="text/javascript" src="lib/base/jquery.cookie.js"></script>
    <script src="lib/jquery-easyui-1.4.4/locale/easyui-lang-zh_CN.js"></script>
    <title>运输单</title>
</head>
<body>
    <div id="p1" class="easyui-navpanel">
		<header>
			<div class="m-toolbar">
				<span id="p2-title" class="m-title">运输单</span>
                <div class="m-left">
                    <a href="group.html" class="easyui-linkbutton m-back" onclick="/group.html">返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <p>运输单号</p>
                <input id="shipId" class="easyui-combobox" name="shipId" 
                    data-options="valueField:'Id',textField:'Id',mode:'remote',url:'api.ashx?api=getFilterShipId'"/>
                <p>施工地</p>
                <input id="siteName" class="easyui-combobox" name="siteName" 
                    data-options="valueField:'TaskId',textField:'SiteName',mode:'remote',url:'api.ashx?api=getSite' " />
                <p>开单开始时间</p>
                <input id="beginTime" class="easyui-datetimebox" name="beginTime" 
                    data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>' " />
                <p>开单结束时间</p>
                <input id="endTime" class="easyui-datetimebox" name="endTime" 
                    data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>' " />
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0);" id="queryTasks" class="easyui-linkbutton c6" style="width:100%;height:33px;">查询</a>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0);" id="addTask" class="easyui-linkbutton c6" style="width:100%;height:33px;">新增</a>
            </div>
        </div>
	</div>
    <div id="p2" class="easyui-navpanel">
		<header>
			<div class="m-toolbar">
				<span id="Span1" class="m-title">运输单列表</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p1')">返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <table id="listDatas" style="height:500px;"></table>
            </div>
        </div>
	</div>
    <div id="p3" class="easyui-navpanel">
        <header>
			<div class="m-toolbar">
				<span id="Span2" class="m-title">运输单修改</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p2')">返回</a>
                </div>
			</div>
		</header>
        <div style="padding-left:25px">
            <form id="dataForm" method="post" enctype="multipart/form-data" novalidate >
                <table>
                    <tr>
                        <td><label>运输单号:</label></td>
                        <td><input name="Id" id="Id" class="easyui-textbox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>任务单号:</label></td>
                        <td><input name="TaskId" id="TaskId" class="easyui-combobox" 
                            data-options="valueField:'Id',textField:'SiteName',width:200,mode:'remote',url:'api.ashx?api=getSite'" /></td>
                    </tr>
                    <tr>
                        <td><label>车牌号:</label></td>
                        <td><input name="VehicleNum" id="VehicleNum" class="easyui-combobox" 
                            data-options="valueField:'VehicleNum',textField:'VehicleId',width:200,mode:'remote',url:'api.ashx?api=getVehicleInfo'" /></td>
                    </tr>
                    <tr>
                        <td><label>外租否:</label></td>
                        <td><input name="Rent" id="Rent" class="easyui-combobox" data-options="
                                valueField: 'id',width:200,value:true,
		                        textField: 'text',
		                        data: [{
			                        text: '不外租',
			                        id: false
		                        },{
			                        text: '外租',
			                        id: true
                                }]" /></td>
                    </tr>
                    <tr>
                        <td><label>车台长:</label></td>
                        <td><input name="Driver1" id="Driver1" class="easyui-textbox" data-options="width:200,value:'',readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>操作手1:</label></td>
                        <td><input name="Driver2" id="Driver2" class="easyui-textbox" data-options="width:200,value:'',readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>操作手2:</label></td>
                        <td><input name="Driver3" id="Driver3" class="easyui-textbox" data-options="width:200,value:'',readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>数量:</label></td>
                        <td><input name="Qty" id="Qty" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr>
                        <td><label>派车时间:</label></td>
                        <td><input name="DisTime" id="DisTime" class="easyui-datetimebox" data-options="width:200" /></td>
                    </tr>
                    <tr>
                        <td><label>状态:</label></td>
                        <td><input name="State" id="State" class="easyui-combobox" data-options="
                                valueField: 'id',width:200,value:'0',readonly:true,
		                        textField: 'text',
		                        data: [{
			                        text: '待审核',
			                        id: '0'
		                        },{
			                        text: '已派车',
			                        id: '1'  
		                        },{
			                        text: '结束',
			                        id: '2'  
                                },{
			                        text: '待派车',
			                        id: '6'  
		                        }]
                                " /></td>
                    </tr>
                    <tr>
                        <td><label>创建时间:</label></td>
                        <td><input name="InsertDate" id="InsertDate" class="easyui-datetimebox" data-options="width:200,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr>
                        <td><label>创建人:</label></td>
                        <td><input name="InsertId" id="InsertId" class="easyui-textbox" data-options="width:200,readonly:true,required:true" /></td>
                    </tr>

                    <%--隐藏字段--%>
                    <tr style="display:none;">
                        <td><label>塔楼:</label></td>
                        <td><input name="Tower" id="Tower" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>离厂时间:</label></td>
                        <td><input name="LeftFacTime" id="LeftFacTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>回厂时间:</label></td>
                        <td><input name="RetFacTime" id="RetFacTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>到场时间:</label></td>
                        <td><input name="ArrSiteTime" id="ArrSiteTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>离场时间:</label></td>
                        <td><input name="LeftSiteTime" id="LeftSiteTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>开始卸料时间:</label></td>
                        <td><input name="BeginUnloadTime" id="BeginUnloadTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>结束卸料时间:</label></td>
                        <td><input name="EndUnloadTime" id="EndUnloadTime" class="easyui-datetimebox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>工厂距离:</label></td>
                        <td><input name="DistFactory" id="DistFactory" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>工地距离:</label></td>
                        <td><input name="DistSite" id="DistSite" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>有效否:</label></td>
                        <td>
                            <input name="Valid" id="Valid" class="easyui-combobox" data-options="
                                valueField: 'id',width:80,value:true,
		                        textField: 'text',
		                        data: [{
			                        text: '有效',
			                        id: true
		                        },{
			                        text: '无效',
			                        id: false  
		                        }]
                                " />
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>修改时间:</label></td>
                        <td><input name="ModiDate" id="ModiDate" class="easyui-datetimebox" data-options="width:200,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>修改人:</label></td>
                        <td><input name="ModiId" id="ModiId" class="easyui-textbox" data-options="width:200,readonly:true,value:''" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>InnerId:</label></td>
                        <td><input name="InnerId" id="InnerId" class="easyui-textbox" data-options="width:200,readonly:true,value:''" /></td>
                    </tr>
                </table>
            </form>
        </div>
        <div style="padding:20px">
            <a href="javascript:void(0)" id="save" class="easyui-linkbutton c6" style="width:100%;height:33px;">保存资料</a>
        </div>
    </div>
    <script src="common.js"></script>
    <script src="ship.js"></script>
</body>
</html>