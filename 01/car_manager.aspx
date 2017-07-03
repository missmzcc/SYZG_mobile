<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_manager.aspx.cs" Inherits="_01.car_manager" %>

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
    <script src="lib/base/jquery.cookie.js"></script>
    <title>车台长报单</title>
</head>
<body>
    <div id="p1" class="easyui-navpanel">
		<header>
			<div class="m-toolbar">
				<span id="p2-title" class="m-title">车台长报单</span>
                <div class="m-left">
                    <a href="group.html" class="easyui-linkbutton m-back" onclick="/group.html">返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <p>任务单号</p>
                <input id="managerId" class="easyui-combobox" name="managerId" 
                    data-options="valueField:'Id',textField:'Id',mode:'remote',url:'api.ashx?api=getFilterTaskId'"/>
                <p>订单号</p>
                <input id="order" class="easyui-textbox" name="order" />
                <p>客户编号</p>
                <input id="customer" class="easyui-combobox" name="customer" 
                    data-options="valueField:'Id',textField:'Name',mode:'remote',url:'api.ashx?api=getClientbyId' " />
                <p>开单开始时间</p>
                <input id="beginTime" class="easyui-datetimebox" name="beginTime" 
                    data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>' " />
                <p>开单结束时间</p>
                <input id="endTime" class="easyui-datetimebox" name="endTime" 
                    data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>' " />
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" id="queryTasks" class="easyui-linkbutton c6" style="width:100%;height:33px;">查询</a>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" id="addTask" class="easyui-linkbutton c6" style="width:100%;height:33px;">新增</a>
            </div>
        </div>
	</div>
    <div id="p2" class="easyui-navpanel">
		<header>
			<div class="m-toolbar">
				<span id="Span1" class="m-title">报单列表</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p1')">返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <table id="listCarManager" style="height:500px;"></table>
            </div>
        </div>
	</div>
    <div id="p3" class="easyui-navpanel">
        <header>
			<div class="m-toolbar">
				<span id="Span2" class="m-title">报单修改</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p2')">返回</a>
                </div>
			</div>
		</header>
        <div style="padding-left:25px">
            <form id="carManagerForm" method="post" enctype="multipart/form-data" novalidate >
                <table>
                    <tr>
                        <%--此处添加required为true页面会报错，但是效果实现了，若不想报错，则必须配合editable=false使用--%>
                        <td><label>运输单:</label></td>
                        <td><input name="ShipId" id="ShipId" class="easyui-combobox"  
                            data-options="width:200,required:true,valueField:'Id',textField:'SiteInfo',mode:'remote',prompt:'请输入车牌号或工地',url:'api.ashx?api=getSiteInfo'" /></td>
                    </tr>
                    <tr>
                        <td><label>开单日期:</label></td>
                        <td><input name="ReportTime" id="ReportTime" class="easyui-datetimebox" 
                            data-options="width:200,required:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr>
                        <td><label>订单号:</label></td>
                        <td><input name="OrderId" id="OrderId" class="easyui-textbox" data-options="width:200,required:true,value:''" /></td>
                    </tr>
                    <tr>
                        <td><label>施工量:</label></td>
                        <td><input name="Quantity" id="Quantity" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr>
                        <td><label>客户点加油量:</label></td>
                        <td><input name="Oil" id="Oil" class="easyui-numberbox" data-options="width:200,required:true,value:1" /></td>
                    </tr>
                    <tr>
                        <td><label>备注:</label></td>
                        <td><input name="Memo" id="Memo" class="easyui-textbox" data-options="width:200,height:60,multiline:true" /></td>
                    </tr>
                    <tr>
                        <td><label>上传报单附件:</label></td>
                        <td><input name="Attach" id="Attach" class="easyui-filebox" data-options="width:140,prompt:'文件',buttonText:'选择'"/>
                            <a id="look" href="javascript:void(0);" class="easyui-linkbutton" data-options="width:50,height:33">查看</a>
                        </td>
                    </tr>
                    <%--隐藏字段--%>
                    <tr style="display:none;">
                        <td><label>编号:</label></td>
                        <td><input name="Id" id="Id" class="easyui-textbox" data-options="width:120,readonly:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>任务单号:</label></td>
                        <td><input name="TaskId" id="TaskId" class="easyui-textbox" data-options="width:120,readonly:true" /></td>
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
                        <td><label>创建时间:</label></td>
                        <td><input name="InsertDate" id="InsertDate" class="easyui-datetimebox" data-options="width:200,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>创建人:</label></td>
                        <td><input name="InsertId" id="InsertId" class="easyui-textbox" data-options="width:200,readonly:true,required:true" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>修改时间:</label></td>
                        <td><input name="ModiDate" id="ModiDate" class="easyui-datetimebox" data-options="width:200,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr style="display:none;">
                        <td><label>修改人:</label></td>
                        <td><input name="ModiId" id="ModiId" class="easyui-textbox" data-options="width:200,readonly:true,value:''" /></td>
                    </tr>
                    
                </table>
        </div>
        <div style="padding:20px">
            <a href="javascript:void(0)" id="save" class="easyui-linkbutton c6" style="width:100%;height:33px;">保存资料</a>
        </div>
        
    </div>
    <div id="p4" class="easyui-navpanel">
		    <header>
			    <div class="m-toolbar">
				    <span id="Span3" class="m-title">附件查看</span>
                    <div class="m-left">
                        <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.back()">返回</a>
                    </div>
			    </div>
		    </header>
            <div style="margin:15px 0 0;text-align:center;">
                <img alt="请稍等"  />
	        </div>
    </div>
    <script src="common.js"></script>
    <script src="car_manager.js"></script>
</body>
</html>
