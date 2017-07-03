<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="task.aspx.cs" Inherits="_01.task" %>

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
    <title>任务单管理</title>
</head>
<body>
	<div id="p1" class="easyui-navpanel">
		<header>
			<div class="m-toolbar">
				<span id="p2-title" class="m-title">任务单</span>
                <div class="m-left">
                    <a href="group.html" class="easyui-linkbutton m-back" >返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <p>任务单号</p>
                <input id="taskId" class="easyui-combobox" name="task_id" 
                    data-options="valueField:'Id',textField:'Id',mode:'remote',url:'api.ashx?api=getFilterTaskId'"/>
                <p>客户编号</p>
                <input id="clientName" class="easyui-combobox" name="clientName" 
                    data-options="valueField:'Id',textField:'Name',mode:'remote',url:'api.ashx?api=getClientbyId' " />
                <p>开始时间</p>
                <input id="beginTime" class="easyui-datetimebox" name="beginTime" 
                    data-options="value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>' " />
                <p>结束时间</p>
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
				<span id="Span1" class="m-title">任务单详情</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p1')">返回</a>
                </div>
			</div>
		</header>
        <div style="margin:15px 0 0;text-align:center;">
            <div>
                <table id="listTasks" style="height:500px;"></table>
            </div>
        </div>
	</div>
    <div id="p3" class="easyui-navpanel">
        <header>
			<div class="m-toolbar">
				<span id="Span2" class="m-title">任务单修改</span>
                <div class="m-left">
                    <a href="javascript:void(0)" class="easyui-linkbutton m-back" onclick="$.mobile.go('#p2')">返回</a>
                </div>
			</div>
		</header>
        <div style="padding-left:25px" >
            <form id="taskForm" method="post" novalidate>
                <table>
                    <tr>
                        <td><label>状态:</label></td>
                        <td>
                            <input name="State" id="State" class="easyui-combobox" style="width:200px;" data-options="
                                valueField: 'id',width:200,value:'0',readonly:true,color:'white',
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
                                " />
                        </td>
                    </tr>
                    <tr>
                        <td><label>审核否:</label></td>
                        <td>
                            <input name="Valid" id="Valid" class="easyui-combobox" data-options="
                                valueField: 'id',width:200,value:true,readonly:true,
		                        textField: 'text',
		                        data: [{
			                        text: '通过',
			                        id: true
		                        },{
			                        text: '驳回',
			                        id: false  
                                },{
			                        text: '通过',
			                        id: 'true'  
                                },{
			                        text: '驳回',
			                        id: 'false'  
		                        }],
                                formatter:validFormatter,
                                onSelect: validSelect
                                " />
                        </td>
                    </tr>
                    <tr>
                        <td><label>关闭否:</label></td>
                        <td>
                            <input name="Closed" id="Closed" class="easyui-combobox" data-options="
                                valueField: 'id',width:200,value:'0',readonly:true,
		                        textField: 'text',
		                        data: [{
			                        text: '正常',
			                        id: '0'
		                        },{
			                        text: '申请撤单',
			                        id: '1'  
		                        },{
			                        text: '关闭',
			                        id: '2'  
		                        }],
                                formatter:closedFormmater,
                                onSelect: closedSelect
                                " />
                        </td>
                    </tr>
                    <tr>
                        <td><label>业务代表:</label></td>
                        <td><input name="InsertId" id="InsertId" class="easyui-textbox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>车型:</label></td>
                        <td><input name="VehicleType" id="VehicleType" class="easyui-textbox" data-options="width:200,required:true,prompt:'46米'" /></td>
                    </tr>
                    <tr>
                        <td><label>客户代码:</label></td>
                        <td><input name="Client" id="Client" class="easyui-textbox" data-options="width:200,readonly:true" /></td>
                    </tr>
                    <tr>
                        <td><label>客户名称:</label></td>
                        <td><input name="Name" id="Name"  class="easyui-combobox" editable="false" 
                            data-options="valueField:'Id',textField:'Name',required:true,width:200,mode:'remote',url:'api.ashx?api=getClientbyId' " /></td>
                    </tr>
                    <tr>
                        <td><label>施工地:</label></td>
                        <td><input name="SiteName" id="SiteName" class="easyui-textbox" data-options="width:200,required:true" /></td>
                    </tr>
                    <tr>
                        <td><label>租赁方式:</label></td>
                        <td>
                            <select name="RentType" id="RentType" class="easyui-combobox" style="width:200px;" required="required">
                                <option value="0" selected="selected">方量</option>
                                <option value="1">其他</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td><label>计划量:</label></td>
                        <td><input name="PlanTaskTotal" id="PlanTaskTotal" class="easyui-numberbox" data-options="width:200,min:1,value:1,required:true" /></td>
                    </tr>
                    <tr>
                        <td><label>合同单价:</label></td>
                        <td><input name="RentUnitPrice" id="RentUnitPrice" class="easyui-numberbox" data-options="width:200,min:0,value:0,required:true" /></td>
                    </tr>
                    <tr>
                        <td><label>计划开盘时间:</label></td>
                        <td><input name="PlanBeginTime" id="PlanBeginTime" class="easyui-datetimebox" data-options="required:true,width:200,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr>
                        <td><label>计划收盘时间:</label></td>
                        <td><input name="PlanEndTime" id="PlanEndTime" class="easyui-datetimebox" data-options="required:true,width:200,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr>
                        <td><label>联系人:</label></td>
                        <td><input name="Contact" id="Contact" class="easyui-textbox" data-options="required:true,width:200,value:''" /></td>
                    </tr>
                    <tr>
                        <td><label>联系电话:</label></td>
                        <td><input name="Tel" id="Tel" class="easyui-textbox" data-options="required:true,width:200,value:''" /></td>
                    </tr>
                    <tr>
                        <td><label>备注:</label></td>
                        <td><input name="Memo" id="Memo" class="easyui-textbox" data-options="width:200,height:60,multiline:true" /></td>
                    </tr>


                    <tr style="display:none">
                        <td><label>泵车属性:</label></td>
                        <td>
                            <select name="Type1" id="Type1" class="easyui-combobox" style="width:200px;">
                                <option value="1" selected="selected">内泵</option>
                                <option value="2">外泵</option>
                            </select>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td><label>任务单号:</label></td>
                        <td><input name="Id" id="Id" class="easyui-textbox" data-options="width:120,readonly:true" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>配比单号:</label></td>
                        <td><input name="MixId" id="MixId" class="easyui-textbox" data-options="width:200" value=""/></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>内部任务单号:</label></td>
                        <td><input name="InnerId" id="InnerId" class="easyui-textbox" data-options="width:200" value=""/></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>自定义:</label></td>
                        <td><input name="UerDefine" id="UerDefine" class="easyui-textbox" data-options="width:200" value=""/></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>生产厂区:</label></td>
                        <td><input name="Factory" id="Factory" class="easyui-textbox" data-options="width:200" value="RG17030001"/></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>工地:</label></td>
                        <td><input name="Site" id="Site" class="easyui-textbox" data-options="width:200" value="RG17030002"/></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>产品标号:</label></td>
                        <td><input name="Grade" id="Grade" class="easyui-textbox" data-options="width:200,value:'C30'" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>施工部位:</label></td>
                        <td><input name="Position" id="Position" class="easyui-textbox" data-options="width:200,value:''" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>坍落度:</label></td>
                        <td><input name="SlumpCone" id="SlumpCone" class="easyui-textbox" data-options="width:200,value:'70'" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>抗渗等级:</label></td>
                        <td>
                            <select name="Imper" id="Imper" class="easyui-combobox" style="width:200px;">
                                <option value="1" selected="selected">S2</option>
                                <option value="2">S4</option>
                                <option value="3">S6</option>
                                <option value="4">S8</option>
                                <option value="5">S10</option>
                                <option value="6">S12</option>
                            </select>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td><label>浇注方式:</label></td>
                        <td>
                            <select name="PourType" id="PourType" class="easyui-combobox" style="width:200px;">
                                <option value="1" selected="selected">泵送</option>
                                <option value="2">自卸</option>
                                <option value="3">塔调</option>
                                <option value="0">其他</option>
                            </select>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td><label>默认车辆:</label></td>
                        <td><input name="VehicleNum" id="VehicleNum" class="easyui-textbox" data-options="width:200,value:''" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>默认司机:</label></td>
                        <td><input name="Driver" id="Driver" class="easyui-textbox" data-options="width:200,value:''" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>运输运距:</label></td>
                        <td><input name="Distance" id="Distance" class="easyui-textbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>工程合同:</label></td>
                        <td><input name="Contract" id="Contract" class="easyui-textbox" data-options="width:200,value:''" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>工程预计方量:</label></td>
                        <td><input name="PlanProjTotal" id="PlanProjTotal" class="easyui-textbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>运送次数:</label></td>
                        <td><input name="ShipCount" id="ShipCount" class="easyui-textbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>运送消耗时间:</label></td>
                        <td><input name="ShipTime" id="ShipTime" class="easyui-numberbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>已送数量:</label></td>
                        <td><input name="DeliveryQty" id="DeliveryQty" class="easyui-textbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>卸料消耗时间:</label></td>
                        <td><input name="UnloadTime" id="UnloadTime" class="easyui-numberbox" data-options="width:200,value:0" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>创建时间:</label></td>
                        <td><input name="InsertDate" id="InsertDate" class="easyui-datetimebox" data-options="width:200,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>修改时间:</label></td>
                        <td><input name="ModiDate" id="ModiDate" class="easyui-datetimebox" data-options="width:200,showSeconds:true,readonly:true,value:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %>'" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>修改人:</label></td>
                        <td><input name="ModiId" id="ModiId" class="easyui-textbox" data-options="width:200,readonly:true,value:''" /></td>
                    </tr>
                    <tr style="display:none">
                        <td><label>其它要求:</label></td>
                        <td><input name="Other" id="Other" class="easyui-textbox" data-options="width:200,height:60,multiline:true" /></td>
                    </tr>
                    
                </table>
            </form>
            </div>
            <div style="padding:20px">
                <a href="javascript:void(0)" id="save" class="easyui-linkbutton c6" style="width:100%;height:33px;">保存资料</a>
                <a href="javascript:void(0)" id="closeing" class="easyui-linkbutton c6" style="width:100%;height:33px;">申请关闭</a>
            </div>
<%--        <div style="width:300px;height:180px;border:1px solid;display:none;margin:-220px auto 0 auto;z-index:100">
                <p style="text-align:center;padding-top:20px">确定要申请关闭吗?</p>
                <div style="text-align:center;padding-top:60px">
                    <a href="javascript:viod(0)" class="easyui-linkbutton" icon="icon-ok">确定</a>
                    <a href="javascript:viod(0)" class="easyui-linkbutton" icon="icon-cancel">取消</a>
                </div>
        </div>--%>
    </div>
    <script src="common.js"></script>
    <script src="task.js"></script>
</body>
</html>