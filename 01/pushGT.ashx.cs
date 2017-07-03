//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Text;
//using Google.ProtocalBuffers;
//using com.igetui.api.openservice;
//using com.igetui.api.openservice.igetui;
//using com.igetui.api.openservice.igetui.template;
//using com.igetui.api.openservice.payload;
//using System.Net;

//namespace _01
//{
//    /// <summary>
//    /// pushGT 的摘要说明
//    /// </summary>
//    public class pushGT : IHttpHandler
//    {

//        public void ProcessRequest(HttpContext context)
//        {
//            context.Response.ContentType = "text/plain";
//            context.Response.Write("Hello World");
//        }

//        public bool IsReusable
//        {
//            get
//            {
//                return false;
//            }
//        }

//        public class demo
//        {
//            //参数设置 <-----参数需要重新设置----->
//            //http的域名
//            private static String HOST = "http://sdk.open.api.igexin.com/apiex.htm";

//            //https的域名
//            //private static String HOST = "https://api.getui.com/apiex.htm";

//            //定义常量, appId、appKey、masterSecret 采用本文档 "第二步 获取访问凭证 "中获得的应用配置
//            private static String APPID = "";
//            private static String APPKEY = "";
//            private static String MASTERSECRET = "";


//            static void Main(string[] args)
//            {
//                //toList接口每个用户状态返回是否开启，可选
//                Console.OutputEncoding = Encoding.GetEncoding(936);
//                Environment.SetEnvironmentVariable("gexin_pushList_needDetails", "true");
//                pushMessageToApp();
//            }
//            //pushMessageToApp接口测试代码
//            private static void pushMessageToApp()
//            {
//                IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
//                // 定义"AppMessage"类型消息对象，设置消息内容模板、发送的目标App列表、是否支持离线发送、以及离线消息有效期(单位毫秒)
//                AppMessage message = new AppMessage();

//                TransmissionTemplate template = TransmissionTemplateDemo();

//                message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
//                message.OfflineExpireTime = 1000 * 3600 * 12;     // 离线有效时间，单位为毫秒，可选
//                message.Data = template;
//                //判断是否客户端是否wifi环境下推送，2:4G/3G/2G,1为在WIFI环境下，0为无限制环境
//                //message.PushNetWorkType = 0; 
//                //message.Speed = 1000;

//                List<String> appIdList = new List<string>();
//                appIdList.Add(APPID);

//                List<String> phoneTypeList = new List<string>();   //通知接收者的手机操作系统类型
//                //phoneTypeList.Add("ANDROID");
//                //phoneTypeList.Add("IOS");

//                List<String> provinceList = new List<string>();    //通知接收者所在省份
//                //provinceList.Add("浙江");
//                //provinceList.Add("上海");
//                //provinceList.Add("北京");

//                List<String> tagList = new List<string>();
//                //tagList.Add("中文");

//                message.AppIdList = appIdList;
//                message.PhoneTypeList = phoneTypeList;
//                message.ProvinceList = provinceList;
//                message.TagList = tagList;


//                String pushResult = push.pushMessageToApp(message);
//                System.Console.WriteLine("-----------------------------------------------");
//                System.Console.WriteLine("服务端返回结果：" + pushResult);
//            }

//            //透传模板动作内容
//            public static TransmissionTemplate TransmissionTemplateDemo()
//            {
//                TransmissionTemplate template = new TransmissionTemplate();
//                template.AppId = APPID;
//                template.AppKey = APPKEY;
//                //应用启动类型，1：强制应用启动 2：等待应用启动
//                template.TransmissionType = "1";
//                //透传内容  
//                template.TransmissionContent = "测试";
//                //设置通知定时展示时间，结束时间与开始时间相差需大于6分钟，消息推送后，客户端将在指定时间差内展示消息（误差6分钟）
//                String begin = "2015-03-06 14:36:10";
//                String end = "2015-03-06 14:46:20";
//                template.setDuration(begin, end);

//                return template;
//            }
//        }
//    }
//}