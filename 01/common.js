(function ($) {
    var timeout = 5000;//超时时间,默认5秒
    $.fn.extend();
    $.extend({
        popAlert: function (content, time) {
            content = content ? content : "发生错误";
            var pop = document.getElementById("pop");
            var contents = document.getElementById("contents");
            if (!pop) {
                pop = document.createElement("div");
                pop.id = "pop";
                pop.style.position = "absolute";
                pop.style.top = 0;
                pop.style.left = 0;
                pop.style.width = "100%";
                pop.style.height = "100%";
                pop.style.opacity = 0.5;
                pop.style.filter = "Alpha(opacity=30)";
                pop.style.zIndex = 9999;
                pop.style.backgroundColor = "gray";
                contents = document.createElement("div");
                contents.id = "contents";
                contents.style.position = "absolute";
                contents.style.left = "50%";
                contents.style.width = "300px";
                contents.style.marginLeft = "-150px";
                contents.style.top = "50%";
                contents.style.height = "150px";
                contents.style.marginTop = "-100px";
                contents.style.textAlign = "center";
                contents.style.zIndex = 10000;
                contents.style.backgroundColor = "#fff";
                var a = document.createElement("a");
                a.id = "message";
                a.innerHTML = content;
                a.style.width = "300px";
                a.style.height = "150px";
                a.style.display = "table-cell";
                a.style.verticalAlign = "middle";
                a.style.wordBreak = "break-all";
                contents.appendChild(a);
                document.body.appendChild(contents);
                document.body.appendChild(pop);
            } else {
                var a = document.getElementById("message");
                a.innerHTML = content;
                pop.style.display = "block";
                contents.style.display = "block";
            }
            time = time ? time : 2;
            var popTime = setTimeout(function () { 
                pop.style.display = "none";
                contents.style.display = "none";
                window.clearTimeout(popTime);
            }, time * 1000);
            document.onclick = function (e) {
                e.stopPropagation();
                pop.style.display = "none";
                contents.style.display = "none";
            }
        },
        commonAjax : function(param, callBack){
            var defaultParams = {
                type: "post",       //请求方式,默认post
                async: true,        //是否异步,默认异步
                cache: true,        //重复请求是否读取缓存,默认读取
                timeout: timeout,   //超时时间
            };
            var params = $.extend({}, defaultParams, param);
            $.ajax({
                url: params.url,
                data: params.data,
                dataType: "json",
                type: params.type,
                async: params.async,
                cache: params.cache,
                success: callBack
            });
        },
        loginInfo: function (user) {
            $.ajax({
                url: "api.ashx",
                data: { api: 'loginInfo' },
                async: false,
                success: function (Result) {
                    var result = JSON.parse(Result);
                    if (result.success) {
                        var oLoginInfo = result.data;
                        user.usr = oLoginInfo.usr;
                        user.pwd = oLoginInfo.pwd;
                        user.nickName = oLoginInfo.nickName;
                    } else {
                        alert("登录超时");
                        window.location.href = "/login.html";
                    }
                }
            });
        },
        //针对easyuidatetimebox格式化的昨天时间，根据easyui版本不同，时间的分隔符不同
        yesterday: function () {
            var now = new Date();
            var yes = new Date(now.getTime() - 86400000);
            return yes.toLocaleDateString().replace(/\//g, "-") + " 00:00:00"
        },
        nowday: function (isBegin) {
            var now = new Date();
            if (isBegin) {
                return now.toLocaleDateString().replace(/\//g, "-") + " 00:00:00";
            } else {
                return now.toLocaleDateString().replace(/\//g, "-") + " 23:59:59";
            }
        },
        //表格初始化
        form_init: function () {

        }
    })
})(window.jQuery)