$(function () {
    //权限验证
    function loginInfo() {
        $.post("api.ashx",{ api: 'loginInfo' },
        function (Result) {
            var result = JSON.parse(Result);
            if (result.success) {
                var oLoginInfo = result.data;
                var usr = oLoginInfo.usr;
                var pwd = oLoginInfo.pwd;
                var nickName = oLoginInfo.nickName;
                $(" .div010").html(nickName);
            } else {
                alert("登录超时");
                window.location.href = "/login.html";
            }
        });
    }

    loginInfo();
})