var user = { usr: "", pwd: "" };
var car = "";

//权限验证
function loginInfo() {
    $.loginInfo(user);
    setTimeout("$('#input_car').combobox('reload')", 500);
}

function qry_mileage() {
    var beginTime = $("#startTime").datetimebox("getValue");
    var endTime = $("#endTime").datetimebox("getValue");
    if (beginTime == "" || beginTime == null || endTime == "" || endTime == null) {
        beginTime = "2015-11-26 00:00:00";
        endTime = "2015-11-26 09:30:00";
    }
    var oData;
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空！");
        return;
    }

    $.post("api.ashx",
   { api: 'history_mileage_total', usr: usr, pwd: pwd, car: car, begin_time: beginTime, end_time: endTime },
   function (data) {
       if (data != 0) {
           //alert(data.length);
           if (data.substr(2, 3) != "err") {
               oData = null;
               oData = eval("(" + data + ")");

               //document.getElementById("mileage").value = parseFloat(oData.mileage).toFixed(2);
               //document.getElementById("Time_1").value = oData.rows[0].recordtime;
               //document.getElementById("Time_2").value = oData.rows[1].recordtime;
               //document.getElementById("minute").value = (parseInt(oData.seconds) / 60).toFixed(0);
               //document.getElementById("a_speed").value = parseFloat(oData.speed).toFixed(2);
               datagrid_init();
               var m_data = [                    { "mileage_name": "里程", "mileage_value": parseFloat(oData.mileage).toFixed(2) + "km" },                    { "mileage_name": "开始时间", "mileage_value": oData.rows[0].recordtime },                    { "mileage_name": "结束时间", "mileage_value": oData.rows[1].recordtime },                    { "mileage_name": "时长", "mileage_value": (parseInt(oData.seconds) / 60).toFixed(0) + "分钟" },                    { "mileage_name": "平均速度", "mileage_value": parseFloat(oData.speed).toFixed(2) + "km/h" }               ];
               $('#Table2').datagrid('loadData', m_data);
           }
           else {
               oData = eval("(" + data + ")")
               alert(oData.err);
           }
       }
       else {
           alert("资料错误或页面过期!");
       }
   });
}

//车牌号输入框初始化
function input_init() {
    //api接口需要用户名密码
    $('#input_car').combobox({
        onBeforeLoad: function (param) {
            param.usr = usr;
            param.pwd = pwd;
        }
    });
}

loginInfo();
input_init();