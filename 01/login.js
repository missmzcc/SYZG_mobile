
//初始化页面时验证是否记住了密码 
$(document).ready(function () {
    if ($.cookie("rmbUser") == "true")
    {
        $("#rmbUser").prop("checked", true);
        $("#usr").val($.cookie("usr"));
        $("#pwd").val($.cookie("pwd"));
    }
});

function login() {
    //默认不记住密码
    if ($("#rmbUser").prop("checked") == true) {//勾选记住密码后 保存cookie
        var usr = $("#usr").val();
        var pwd = $("#pwd").val();
        $.cookie("rmbUser", "true", { expires: 7 }); // 存储一个带7天期限的 cookie 
        $.cookie("usr", usr, { expires: 7 }); // 存储一个带7天期限的 cookie 
        $.cookie("pwd", pwd, { expires: 7 }); // 存储一个带7天期限的 cookie 
        //alert(usr, passWord) 
    } else {
        var usr = $("#usr").val();
        var pwd = $("#pwd").val();
    }
    if (!usr || !pwd) {
        alert("登录名或密码不能为空");
        return;
    }
    $.post("api.ashx",
    { api: 'login', usr: usr, pwd: pwd },
    function (Result) {
        var result = JSON.parse(Result);
        if (result.success) {
            var data = result.data;
            if ("UN17030003" === data.approve) {
                $.cookie("approve","crd");//业务员
            } else if ("UN17030004" === data.approve) {
                $.cookie("approve", "srd");//审核员
            } else if ("UN17030005" === data.approve) {
                $.cookie("approve", "ct");//车队
            } else if ("UN17030006" === data.approve) {
                $.cookie("approve", "ch");//调度
            } else {
                $.cookie("approve", "test");
            }
            window.location.href = "group.html";
        } else {
            alert("登录名或密码错误");
        }
    });
}

function ShowLogin() {
    $(".FirstPage").hide();
    $("#p2").show();
}
$(".FirstPage").click(function () {
    ShowLogin();
});