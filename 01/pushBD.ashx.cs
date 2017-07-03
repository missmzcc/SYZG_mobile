using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace _01
{
    /// <summary>
    /// pushBD 的摘要说明
    /// </summary>
    public class pushBD : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {   
        //百度apikey
        private static readonly String apikey = "ZTaGwVUDekLugCnG3ZE42TwO";
        //百度秘钥
        private static readonly String secret_key = "c5b4fMSpB2HcNYEYX7v7ySYeq2mGYcGz";
        //private static readonly String secret_key = "87772555E1C16715EBA5C85341684C58";
        //失效时间
        private static readonly long expires = 10 * 60 * 1000;
        //请求超时时间
        private static readonly int timeout = 20 * 1000;
        //url选择
        private static readonly Dictionary<String, String> pushTypeUrl = new Dictionary<String, String> {
            {"PUSH_ALL","push/all"},                                        //推送广播消息
            {"PUSH_SIGNLE_DEVICE","push/single_device"},                    //推送消息到单台设备
            {"PUSH_TAGS","push/tags"},                                      //推送组播消息
            {"PUSH_BATCH_DEVICE","push/batch_device"},                      //推送消息到给定的一组设备(批量单播)
            {"REPORT_QUERY_MSG_STATUS","report/query_msg_status"},          //查询消息的发送状态
            {"REPORT_QUERY_TIMER_RECORDS","report/query_timer_records"},    //查询定时消息的发送记录
            {"REPORT_QUERY_TOPIC_RECORDS","report/query_topic_records"},    //查询指定分类主题的发送记录
            {"APP_QUERY_TAGS","app/query_tags"},                            //查询标签组列表
            {"APP_CREATE_TAG","app/create_tag"},                            //创建标签组
            {"APP_DEL_TAG","app/del_tag"},                                  //删除标签组
            {"TAG_ADD_DEVICES","tag/add_devices"},                          //添加设备到标签组
            {"TAG_DEL_DEVICES","tag/del_devices"},                          //将设备从标签组中移除
            {"TAG_DEVICE_NUM","tag/device_num"},                            //查询标签组设备数量
            {"TIMER_QUERY_LIST","timer/query_list"},                        //查询定时任务列表
            {"TIMER_CANCEL","timer/cancel"},                                //取消定时任务
            {"TOPIC_QUERY_LIST","topic/query_list"},                        //查询分类主题列表
            {"REPORT_STATISTIC_MSG","report/statistic_msg"},                //当前应用的消息统计信息
            {"REPORT_STATISTIC_DEVICE","report/statistic_device"},          //当前应用的设备统计信息
            {"REPORT_STATISTIC_TOPIC","report/statistic_topic"}             //查询分类主题统计信息
        };

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //百度消息推送
        public static Object pushBaidu(String type){
            String url = "http://api.tuisong.baidu.com/rest/3.0/push/all";
            //String url = "http://api.tuisong.baidu.com/rest/3.0/test/echo";
            Object res = SendBaidu("POST", url);
            return res;
        }

        //发送消息到百度
        public static Object SendBaidu(String method, String url)
        {
            classResult result = new classResult();
            result.success = true;
            result.data = "";
            result.message = "成功";
            string msg = JsonConvert.SerializeObject(result);
            long timestamp = getTimestamp();
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("apikey",apikey);
            dic.Add("timestamp", timestamp);
            dic.Add("expires",expires);
            dic.Add("device_type",3);
            //dic.Add("channel_id","4227504391777756740");
            //dic.Add("msg_type","1");
            dic.Add("msg", msg);
            String sign = createSign(method, url, dic);
            dic.Add("sign", sign);

            Dictionary<String, Object> dic1 = new Dictionary<String, Object>();
            dic1.Add("apikey", "Ljc710pzAa99GULCo8y48NvB");
            dic1.Add("timestamp", "1427180905");
            dic1.Add("expires", 1313293565);
            String sign1 = createSign(method, url, dic1);

            String data = createUrl(dic);
            //处理http的请求
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            req.Timeout = timeout;
            req.Method = method;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.UserAgent = "BCCS_SDK/3.0 (Darwin; Darwin Kernel Version 14.0.0: Fri Sep 19 00:26:44 PDT 2014; root:xnu-2782.1.97~2/RELEASE_X86_64; x86_64) PHP/5.6.3 (Baidu Push Server SDK V3.0.0 and so on..) cli/Unknown ZEND/2.6.0";
            req.ContentLength = buffer.Length;
            req.Credentials = CredentialCache.DefaultCredentials;
            Stream postData = req.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();
            HttpWebResponse webResp = (HttpWebResponse)req.GetResponse();
            Stream answer = webResp.GetResponseStream();
            StreamReader answerData = new StreamReader(answer);
            //发送请求
            return webResp;
        }

        //百度推送签名算法
        public static String createSign(String httpMethod, String url, Dictionary<String, Object> dic)
        {
            var preData = new StringBuilder();
            dic = dic.OrderBy(p => p.Key).ToDictionary(p=>p.Key,p=>p.Value);
            foreach (var l in dic)
            {
                preData.Append(l.Key);
                preData.Append("=");
                preData.Append(l.Value);
            }
            String url1 = httpMethod + url + preData + secret_key;
            String sign = HttpUtility.UrlEncode(httpMethod.ToUpper() + url + preData.ToString() + secret_key);
            char[] cs = new char[sign.Length];
            for (int i = 0; i < sign.Length; i++)
            {
                cs[i] = sign[i];
                if (sign[i] == '%')
                {
                    cs[++i] = Convert.ToChar(sign[i].ToString().ToUpper());
                    cs[++i] = Convert.ToChar(sign[i].ToString().ToUpper());
                }
            }
            return md5(sign);
        }

        //获取当前时间戳
        public static long getTimestamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970,1,1,0,0,0,0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        //请求url拼接
        public static String createUrl(Dictionary<String, Object> dic)
        {
            StringBuilder sb = new StringBuilder();
            List<String> list = new List<String>();
            if(dic != null){
                foreach(var kv in dic){
                    StringBuilder sb1 = new StringBuilder();
                    sb.Append(kv.Key);
                    sb.Append("=");
                    sb.Append(kv.Value);
                    sb.Append("&");
                }
                return sb.ToString().Substring(0,sb.ToString().Length -1);
            }
            return "";
        }
        //md5加密
        public static String md5(string t)
        {
            StringBuilder buf;
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] c = md5.ComputeHash(Encoding.UTF8.GetBytes(t));
                return BitConverter.ToString(c).Replace("-","");
                //buf = new StringBuilder();

                //foreach (byte b in c)
                //{
                //    buf.Append(b.ToString("x2"));
                //}
            }
            catch (Exception)
            {
                throw;
            }

            //return buf.ToString();
        }

        public class classResult
        {
            public bool success;
            public string message;
            public object data;

        }
    }
    
}