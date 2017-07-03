var usr = "";
var pwd = "";

function login() {
    usr = $('#usr').val();
    pwd = $('#pwd').val();
    $.post("api.ashx",
     { api:'login',usr: usr, pwd: pwd },
     function (data) {
         if (data==1) {
             window.location.href = "/group.html";
         } else {
             alert("用户名或或密码错误!")
         }
     }
 );
}