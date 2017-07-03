var usr = "";
var pwd = "";
var car = "";

function loginInfo() {
    $.post("api.ashx",
     { api: 'loginInfo'},
     function (data) {
         if (data != 0) {
             //alert(data);
             oLoginInfo = eval("(" + data + ")");
             usr = oLoginInfo.usr;
             pwd = oLoginInfo.pwd;
         } else {
             alert("用户名或或密码错误!");
         }
     }
 );
}

function qry_pos() {
    car = $('#input_car').combobox('getValue');
    if (car == "") {
        alert("车牌号为空!");
        return;
    }
   var url = "/last_poi.aspx?usr=" + usr + "&pwd=" + pwd + "&car=" + car + "";
   window.location.href = url;
}

loginInfo();