using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Web.SessionState;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Net;
using _01;

namespace _01
{
      //三一重工任务单
    public partial class classSYZG_Task
    {
        //SYZG_Task-任务单        
        public classSYZG_Task()
        { }
        /// <summary>
        /// 任务单号
        /// </summary>		
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 配比单号
        /// </summary>		
        private string _mixid;
        public string MixId
        {
            get { return _mixid; }
            set { _mixid = value; }
        }
        /// <summary>
        /// 内部任务单号
        /// </summary>		
        private string _innerid;
        public string InnerId
        {
            get { return _innerid; }
            set { _innerid = value; }
        }
        /// <summary>
        /// 自定义
        /// </summary>		
        private string _uerdefine;
        public string UerDefine
        {
            get { return _uerdefine; }
            set { _uerdefine = value; }
        }
        /// <summary>
        /// 区域管理
        /// </summary>		
        private string _factory;
        public string Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        /// <summary>
        /// 计划起运时间
        /// </summary>		
        private DateTime _planbegintime;
        public DateTime PlanBeginTime
        {
            get { return _planbegintime; }
            set { _planbegintime = value; }
        }
        /// <summary>
        /// 计划结束时间
        /// </summary>		
        private DateTime _planendtime;
        public DateTime PlanEndTime
        {
            get { return _planendtime; }
            set { _planendtime = value; }
        }
        /// <summary>
        /// 产品标号
        /// </summary>		
        private string _grade;
        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        /// <summary>
        /// 施工部位
        /// </summary>		
        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// 单位mm
        /// </summary>		
        private int _slumpcone;
        public int SlumpCone
        {
            get { return _slumpcone; }
            set { _slumpcone = value; }
        }
        /// <summary>
        /// S2,S4,S6,S8,S10,S12
        /// </summary>		
        private string _imper;
        public string Imper
        {
            get { return _imper; }
            set { _imper = value; }
        }
        /// <summary>
        /// 其它要求
        /// </summary>		
        private string _other;
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }
        /// <summary>
        /// 浇注方式
        /// </summary>		
        private string _pourtype;
        public string PourType
        {
            get { return _pourtype; }
            set { _pourtype = value; }
        }
        /// <summary>
        /// 泵车类型
        /// </summary>		
        private string _vehicletype;
        public string VehicleType
        {
            get { return _vehicletype; }
            set { _vehicletype = value; }
        }
        /// <summary>
        /// 泵车属性
        /// </summary>		
        private string _type1;
        public string Type1
        {
            get { return _type1; }
            set { _type1 = value; }
        }
        /// <summary>
        /// 默认车辆
        /// </summary>		
        private string _vehiclenum;
        public string VehicleNum
        {
            get { return _vehiclenum; }
            set { _vehiclenum = value; }
        }
        /// <summary>
        /// 默认司机
        /// </summary>		
        private string _driver;
        public string Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
        /// <summary>
        /// 单位Km
        /// </summary>		
        private decimal _distance;
        public decimal Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _memo;
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// 工程合同
        /// </summary>		
        private string _contract;
        public string Contract
        {
            get { return _contract; }
            set { _contract = value; }
        }
        /// <summary>
        /// 工程预计方量
        /// </summary>		
        private int _planprojtotal;
        public int PlanProjTotal
        {
            get { return _planprojtotal; }
            set { _planprojtotal = value; }
        }
        /// <summary>
        /// 任务预计方量
        /// </summary>		
        private int _plantasktotal;
        public int PlanTaskTotal
        {
            get { return _plantasktotal; }
            set { _plantasktotal = value; }
        }
        /// <summary>
        /// 客户
        /// </summary>		
        private string _client;
        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }
        /// <summary>
        /// 区域管理
        /// </summary>		
        private string _site;
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }
        /// <summary>
        /// 施工地
        /// </summary>		
        private string _SiteName;
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }     
        /// <summary>
        /// 联系人
        /// </summary>		
        /// 
        private string _contact;
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private string _state;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 运送次数
        /// </summary>		
        private int _shipcount;
        public int ShipCount
        {
            get { return _shipcount; }
            set { _shipcount = value; }
        }
        /// <summary>
        /// 单位:分钟
        /// </summary>		
        private int _shiptime;
        public int ShipTime
        {
            get { return _shiptime; }
            set { _shiptime = value; }
        }
        /// <summary>
        /// 已送数量
        /// </summary>		
        private decimal _deliveryqty;
        public decimal DeliveryQty
        {
            get { return _deliveryqty; }
            set { _deliveryqty = value; }
        }
        /// <summary>
        /// 卸料时间
        /// </summary>		
        private int _unloadtime;
        public int UnloadTime
        {
            get { return _unloadtime; }
            set { _unloadtime = value; }
        }
        /// <summary>
        /// 有效否
        /// </summary>		
        private bool _valid;
        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }
        /// <summary>
        /// 租赁方式
        /// </summary>		
        private string _RentType;
        public string RentType
        {
            get { return _RentType; }
            set { _RentType = value; }
        }
        /// <summary>
        /// 租赁单价
        /// </summary>		
        private decimal _RentUnitPrice;
        public decimal RentUnitPrice
        {
            get { return _RentUnitPrice; }
            set { _RentUnitPrice = value; }
        }
        private string _Closed;
        public string Closed 
        {
            get { return _Closed; }
            set { _Closed = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        private DateTime _insertdate;
        public DateTime InsertDate
        {
            get { return _insertdate; }
            set { _insertdate = value; }
        }
        /// <summary>
        /// 创建人
        /// </summary>		
        private string _insertid;
        public string InsertId
        {
            get { return _insertid; }
            set { _insertid = value; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>		
        private DateTime _modidate;
        public DateTime ModiDate
        {
            get { return _modidate; }
            set { _modidate = value; }
        }
        /// <summary>
        /// 修改人
        /// </summary>		
        private string _modiid;
        public string ModiId
        {
            get { return _modiid; }
            set { _modiid = value; }
        }      
    }
    //三一重工运输单资料表
    public class classSYZG_Ship
    {
        public String Id;
        public String TaskId;
        public String VehicleNum;
        public bool Rent;
        public String Driver1;
        public String Driver2;
        public String Driver3;
        public decimal Qty;
        public String Tower;
        public DateTime DisTime;
        public DateTime LeftFacTime;
        public DateTime RetFacTime;
        public DateTime ArrSiteTime;
        public DateTime LeftSiteTime;
        public DateTime BeginUnloadTime;
        public DateTime EndUnloadTime;
        public Decimal DistFactory;
        public Decimal DistSite;
        public String State;
        public bool Valid;
        public DateTime InsertDate;
        public string InsertId;
        public DateTime ModiDate;
        public string ModiId;

    }
    //车台长报单
    public class classSYZG_Report
    {
        public String Id;
        public String TaskId;
        public String ShipId;
        public DateTime ReportTime;
        public string OrderId;
        public decimal Quantity;
        public decimal Oil;
        public String Memo;
        public Byte[] Attach;
        public bool Valid;
        public DateTime InsertDate;
        public string InsertId;
        public DateTime ModiDate;
        public string ModiId;

    }

    //发短信
    class sms_service
    {
        /*
         sms_service sms = new sms_service();
         sms.send("这是第二个测试");
         */
        private string url = "http://111.47.110.68/api/SmSendServer";
        private string account = "HB20160921172617";
        private string pwd = "Jy!39884as";
        private string productId = "3590627";
        public string mobile = "";
        public string msg = "这是第一个测试";

        public string result_msg;

        public Dictionary<string, string> result = new Dictionary<string, string>();

        public sms_service()
        {
            result_init();
        }

        private void result_init()
        {
            result.Add("101", "无此用户");
            result.Add("102", "账号或是密码错");
            result.Add("103", "提交过快（提交速度超过流速限制）");
            result.Add("104", "系统忙（因平台侧原因，暂时无法处理提交的短信）");
            result.Add("105", "敏感短信（短信内容包含敏感词）");
            result.Add("106", "消息长度错（>500或<=0）");
            result.Add("107", "包含错误的手机号码");
            result.Add("108", "手机号码个数错误（群发>1000或<=0）");
            result.Add("109", "无发送额度（该用户可用短信数已使用完）");
            result.Add("110", "不在发送时间内或是发送时间错误");
            result.Add("111", "超出该账户当月发送额度限制");
            result.Add("112", "产品id未指定或是无此产品，用户没有订购该产品");
            result.Add("114", "自动审核驳回");
            result.Add("115", "签名不合法");
            result.Add("116", "IP地址认证错,请求调用的IP地址不是系统登记的IP地址");
            result.Add("117", "用户没有相应的发送权限");
            result.Add("118", "用户被禁用或是账号http通道被关闭");
            result.Add("119", "系统异常");
        }

        public bool send(string msg)
        {
            bool lret = false;
            string data = "account=" + account + "&pwd=" + pwd + "&productId=" + productId + "&mobile=" + mobile + "&msg=" + msg;
            string retString = Post(url, data);
            if (retString.Substring(0, 1) == "0")
            {
                lret = true;
            }
            else
            {
                lret = false;
                this.result_msg = result[retString];
            }
            return lret;
        }

        private static string Post(string url, string data)
        {
            string returnData = null;

            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = buffer.Length;
                Stream postData = webReq.GetRequestStream();
                postData.Write(buffer, 0, buffer.Length);
                postData.Close();
                HttpWebResponse webResp = (HttpWebResponse)webReq.GetResponse();
                Stream answer = webResp.GetResponseStream();
                StreamReader answerData = new StreamReader(answer);
                returnData = answerData.ReadToEnd();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return returnData.Trim() + "\n";
        }
        
    }

    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        //string cnnStr = ConfigurationManager.ConnectionStrings["MspBaseSqlCon"].ToString();//新增代码
        sms_service sms = new sms_service();
        public string api_id;
        public string logFileLog = "";
        public string RespStr; 
        public void ProcessRequest(HttpContext context)
        {
            logFileLog = context.Request.PhysicalApplicationPath + "request.log";
            api_id = context.Request["api"];
            classResult result = new classResult();
            switch (api_id)
            {
                case "login":
                    string usr = context.Request["usr"];
                    string pwd = context.Request["pwd"];
                    DataRow user = authority(usr, pwd, false);
                    if (user != null)
                    {
                        context.Session["usr"] = usr;
                        context.Session["pwd"] = md5(pwd);
                        Dictionary<String, String> dic = new Dictionary<String, String>();
                        dic.Add("NickName", user["NickName"].ToString());
                        DataRow approve = getRightDetailsbyId(usr, md5(pwd));
                        if (approve == null)
                        {
                            result.message = "该帐号未分配权限";
                        }
                        else
                        {
                            //dic.Add("crd",approve["CRD"].ToString());
                            //dic.Add("ct", approve["CT"].ToString());
                            //dic.Add("ch", approve["CH"].ToString());
                            //dic.Add("srd", approve["SRD"].ToString());
                            dic.Add("approve",approve["UnitId"].ToString());
                        }
                        result.data = dic;
                        result.success = true;
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        context.Response.End();
                    }
                    else
                    {
                        result.success = false;
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        context.Response.End();
                    }
                    break;
                case "loginInfo":
                    if (context.Session["usr"] != null)
                    {   
                        string loginInfoUsr = context.Session["usr"].ToString();
                        string loginInfoPwd = context.Session["pwd"].ToString();
                        DataRow userInfo = authority(loginInfoUsr,loginInfoPwd,true);
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        if (userInfo != null)
                        {
                            result.success = true;
                            dic.Add("usr", userInfo["UserId"].ToString());
                            dic.Add("pwd", loginInfoPwd);
                            dic.Add("nickName", userInfo["NickName"].ToString());
                            result.data = dic;
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            context.Response.End();
                        }
                        else
                        {
                            result.success = false;
                            context.Response.Write(JsonConvert.SerializeObject(result));
                            context.Response.End();
                        }
                    }
                    break;
                case "last_poi":
                    string last_poi_usr = context.Request["usr"];
                    string last_poi_pwd = context.Request["pwd"];
                    string last_poi_car = context.Request["car"];
                    string last_poi_point = last_poi_location(last_poi_usr, last_poi_pwd, last_poi_car);
                    context.Response.Write(last_poi_point);
                    context.Response.End();
                    break;
                case "getFilterVehicleId":
                    string getFilterVehicleIdKeyWord = context.Request["q"];
                    string getFilterVehicleIdRet = getFilterVehicleId(getFilterVehicleIdKeyWord);
                    context.Response.Write(getFilterVehicleIdRet);
                    context.Response.End();
                    break;
                case "realtime_pos":
                    string realtime_pos_usr = context.Request["usr"];
                    string realtime_pos_pwd = context.Request["pwd"];
                    string realtime_posi_car = context.Request["car"];
                    string realtime_pos_begin_time = context.Request["begin_time"];
                    string realtime_pos_end_time = context.Request["end_time"];
                    string realtime_pos_ret = realtime_pos(realtime_pos_usr, realtime_pos_pwd, realtime_posi_car);
                    context.Response.Write(realtime_pos_ret);
                    context.Response.End();
                    break;
                case "history_pos":
                    string history_pos_usr = context.Request["usr"];
                    string history_pos_pwd = context.Request["pwd"];
                    string history_posi_car = context.Request["car"];
                    string history_pos_begin_time = context.Request["begin_time"];
                    string history_pos_end_time = context.Request["end_time"];
                    string history_pos_ret = history_pos(history_pos_usr, history_pos_pwd, history_posi_car, history_pos_begin_time, history_pos_end_time);
                    context.Response.Write(history_pos_ret);
                    context.Response.End();
                    break;
                case "history_park":
                    string history_park_usr = context.Request["usr"];
                    string history_park_pwd = context.Request["pwd"];
                    string history_park_car = context.Request["car"];
                    string history_park_begin_time = context.Request["begin_time"];
                    string history_park_end_time = context.Request["end_time"];
                    string history_park_page = context.Request["page"];
                    string history_park_rows = context.Request["rows"];
                    string history_park_ret = history_park(history_park_usr, history_park_pwd, history_park_car, history_park_begin_time, history_park_end_time,history_park_page,history_park_rows);
                    context.Response.Write(history_park_ret);
                    context.Response.End();
                    break;

                case "getFilterTaskId":                   
                    string getFilterTaskIdKeyWord = context.Request["q"];
                    string getFilterTaskIdRet = getFilterTaskId(getFilterTaskIdKeyWord);
                    context.Response.Write(getFilterTaskIdRet);
                    context.Response.End();
                    break;
                case "getFilterClientId":
                    string getFilterClientIdKeyWord = context.Request["q"];
                    string getFilterClientIdRet = getFilterClientId(getFilterClientIdKeyWord);
                    context.Response.Write(getFilterClientIdRet);
                    context.Response.End();
                    break;
                case "getClientbyId":
                    string getClientbyIdKeyWord = context.Request["q"];
                    string getClientbyIdRet = getClientbyId(getClientbyIdKeyWord);
                    context.Response.Write(getClientbyIdRet);
                    context.Response.End();
                    break;
                case "getContactbyId":
                    string getContactbyIdKeyWord = context.Request["Client"];
                    string getContactbyIdRet = getContactbyId(getContactbyIdKeyWord);
                    context.Response.Write(getContactbyIdRet);
                    context.Response.End();
                    break;
                case "getVehicleInfo":
                    string keyWord = context.Request["q"];
                    string getVehicleInfoRet = getVehicleInfo(keyWord);
                    context.Response.Write(getVehicleInfoRet);
                    context.Response.End();
                    break;
                case "approveClosedbyUsr":
                    string approveClosedbyUsr_usr = context.Request["usr"];
                    string approveClosedbyUsr_pwd = context.Request["pwd"];
                    string approveClosedbyUsr_ret = approveClosedbyUsr(ref context, approveClosedbyUsr_usr, approveClosedbyUsr_pwd);
                    context.Response.Write(approveClosedbyUsr_ret);
                    context.Response.End();
                    break;
                case "SYZG_InsertTask":
                    string SYZG_InsertTask_usr = context.Request["usr"];
                    string SYZG_InsertTask_pwd = context.Request["pwd"];
                    string SYZG_InsertTask_ret = SYZG_InsertTask(ref context,SYZG_InsertTask_usr, SYZG_InsertTask_pwd);
                    context.Response.Write(SYZG_InsertTask_ret);
                    context.Response.End();
                    break;
                case "SYZG_UpdateTask":
                    string SYZG_UpdateTask_usr = context.Request["usr"];
                    string SYZG_UpdateTask_pwd = context.Request["pwd"];
                    string SYZG_UpdateTask_ret = SYZG_UpdateTask(ref context, SYZG_UpdateTask_usr, SYZG_UpdateTask_pwd);
                    context.Response.Write(SYZG_UpdateTask_ret);
                    context.Response.End();
                    break;
                case "SYZG_DeleteTask":
                    string SYZG_DeleteTask_usr = context.Request["usr"];
                    string SYZG_DeleteTask_pwd = context.Request["pwd"];
                    string SYZG_DeleteTask_id = context.Request["Id"];
                    string SYZG_DeleteTask_ret = SYZG_DeleteTask(ref context, SYZG_DeleteTask_usr, SYZG_DeleteTask_pwd, SYZG_DeleteTask_id);
                    context.Response.Write(SYZG_DeleteTask_ret);
                    context.Response.End();
                    break;
                case "SYZG_Task":
                    string SYZG_Task_usr = context.Request["usr"];
                    string SYZG_Task_pwd = context.Request["pwd"];
                    string SYZG_Task_Id = context.Request["Id"];
                    string SYZG_Task_Client = context.Request["Client"];
                    string SYZG_Task_page = context.Request["page"];
                    string SYZG_Task_rows = context.Request["rows"];
                    string SYZG_Task_beginTime = context.Request["beginTime"];
                    string SYZG_Task_endTime = context.Request["endTime"];
                    string SYZG_Task_ret = SYZG_Task(SYZG_Task_usr, SYZG_Task_pwd, SYZG_Task_Id, SYZG_Task_Client, SYZG_Task_beginTime, SYZG_Task_endTime,SYZG_Task_page, SYZG_Task_rows);
                    context.Response.Write(SYZG_Task_ret);
                    context.Response.End();
                    break;
                case "getSite":
                    string getSiteKeyWord = context.Request["q"];
                    string getSiteRet = getSite(getSiteKeyWord);
                    context.Response.Write(getSiteRet);
                    context.Response.End();
                    break;
                case "getFilterShipId":
                    string getFilterShipIdKeyWord = context.Request["q"];
                    string getFilterShipIdRet = getFilterShipId(getFilterShipIdKeyWord);
                    context.Response.Write(getFilterShipIdRet);
                    context.Response.End();
                    break;
                case "SYZG_InsertShip":
                    string SYZG_InsertShip_usr = context.Request["usr"];
                    string SYZG_InsertShip_pwd = context.Request["pwd"];
                    string SYZG_InsertShip_ret = SYZG_InsertShip(ref context, SYZG_InsertShip_usr, SYZG_InsertShip_pwd);
                    context.Response.Write(SYZG_InsertShip_ret);
                    context.Response.End();
                    break;
                case "SYZG_UpdateShip":
                    string SYZG_UpdateShip_usr = context.Request["usr"];
                    string SYZG_UpdateShip_pwd = context.Request["pwd"];
                    string SYZG_UpdateShip_ret = SYZG_UpdateShip(ref context, SYZG_UpdateShip_usr, SYZG_UpdateShip_pwd);
                    context.Response.Write(SYZG_UpdateShip_ret);
                    context.Response.End();
                    break;
                case "SYZG_DeleteShip":
                    string SYZG_DeleteShip_usr = context.Request["usr"];
                    string SYZG_DeleteShip_pwd = context.Request["pwd"];
                    string SYZG_DeleteShip_id = context.Request["Id"];
                    string SYZG_DeleteShip_ret = SYZG_DeleteShip(ref context, SYZG_DeleteShip_usr, SYZG_DeleteShip_pwd);
                    context.Response.Write(SYZG_DeleteShip_ret);
                    context.Response.End();
                    break;
             
                case "SYZG_Ship":
                    string SYZG_Ship_usr = context.Request["usr"];
                    string SYZG_Ship_pwd = context.Request["pwd"];
                    string SYZG_Ship_Id = context.Request["Id"];
                    string SYZG_Ship_TaskId = context.Request["TaskId"];
                    string SYZG_Ship_Site = context.Request["SiteName"];
                    string SYZG_Ship_begintime = context.Request["begintime"];
                    string SYZG_Ship_endtime = context.Request["endtime"];
                    string SYZG_Ship_page = context.Request["page"];
                    string SYZG_Ship_rows = context.Request["rows"];
                    string SYZG_Ship_ret = SYZG_Ship(SYZG_Ship_usr, SYZG_Ship_pwd, SYZG_Ship_Id, SYZG_Ship_TaskId, SYZG_Ship_begintime, SYZG_Ship_endtime, SYZG_Ship_page, SYZG_Ship_rows);
                    context.Response.Write(SYZG_Ship_ret);
                    context.Response.End();
                    break;
                
                case "SYZG_InsertReport":
                    string SYZG_InsertReport_usr = context.Request["usr"];
                    string SYZG_InsertReport_pwd = context.Request["pwd"];
                    string SYZG_InsertReport_ret = SYZG_InsertReport(ref context, SYZG_InsertReport_usr, SYZG_InsertReport_pwd);
                    context.Response.Write(SYZG_InsertReport_ret);
                    context.Response.End();
                    break;
                case "SYZG_UpdateReport":
                    string SYZG_UpdateReport_usr = context.Request["usr"];
                    string SYZG_UpdateReport_pwd = context.Request["pwd"];
                    string SYZG_UpdateReport_ret = SYZG_UpdateReport(ref context, SYZG_UpdateReport_usr, SYZG_UpdateReport_pwd);
                    context.Response.Write(SYZG_UpdateReport_ret);
                    context.Response.End();
                    break;
                
                case "SYZG_DeleteReport":
                    string SYZG_DeleteReport_usr = context.Request["usr"];
                    string SYZG_DeleteReport_pwd = context.Request["pwd"];
                    string SYZG_DeleteReport_id = context.Request["Id"];
                    string SYZG_DeleteReport_ret = SYZG_DeleteReport(ref context, SYZG_DeleteReport_usr, SYZG_DeleteReport_pwd);
                    context.Response.Write(SYZG_DeleteReport_ret);
                    context.Response.End();
                    break;
                case "SYZG_Report":
                    string SYZG_Report_usr = context.Request["usr"];
                    string SYZG_Report_pwd = context.Request["pwd"];
                    string SYZG_Report_taskno = context.Request["TaskId"];
                    string SYZG_Report_Client = context.Request["Client"];
                    string SYZG_Report_orderno = context.Request["OrderId"];
                    string SYZG_Report_begintime = context.Request["begintime"];
                    string SYZG_Report_endtime = context.Request["endtime"];
                    string SYZG_Report_page = context.Request["page"];
                    string SYZG_Report_rows = context.Request["rows"];
                    string SYZG_Report_ret = SYZG_Report(ref context, SYZG_Report_usr, SYZG_Report_pwd, SYZG_Report_taskno, SYZG_Report_Client, SYZG_Report_orderno, SYZG_Report_begintime, SYZG_Report_endtime, SYZG_Report_page, SYZG_Report_rows);                    
                    context.Response.Write(SYZG_Report_ret);
                    context.Response.End();
                    break;
                case "getAttachbyId":
                    string getAttachbyIdKeyWord = context.Request["Id"];
                    string getAttachbyIdRet = getAttachbyId(ref context,getAttachbyIdKeyWord);
                    context.Response.Write(getAttachbyIdRet);
                    context.Response.End();
                    break;
                case "getSiteInfo":
                    string getSiteInfoKeyWord = context.Request["Id"];
                    string getSiteInfoRet = getSiteInfo(ref context);
                    context.Response.Write(getSiteInfoRet);
                    context.Response.End();
                    break;        

                default:
                    break;
            }
            context.Response.ContentType = "text/plain";
            result.success = false;
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //权限检查，存入服务器session
        private DataRow authority(string usr, string pwd, bool encrypt)
        {
            DataRow lret = null;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                string lpwd = "";

                //密码是否加密
                lpwd = encrypt ? pwd : md5(pwd);
                /***********************************************旧代码**********************************************/
                #region 访问数据库
                lsql += "DECLARE @USR varchar(50)\n";
                lsql += "DECLARE @PWD varchar(50)\n";
                lsql += "DECLARE @nLEVEL INT\n";
                lsql += "DECLARE @UNIT varchar(50)\n";
                lsql += "DECLARE @CAR varchar(50)\n";
                lsql += "\n";
                lsql += "SET @USR = '" + usr + "'\n";
                lsql += "SET @PWD = '" + lpwd + "'\n";
                lsql += "\n";
                lsql += "SELECT * FROM [MspBase].[dbo].[LoginUsers]\n";
                lsql += "WHERE NickName= @USR\n";
                lsql += "  AND PassWord = @PWD  \n";
                #endregion

                lcnn.Open();
                lcmd.Connection = lcnn;
                lcmd.CommandText = lsql;
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_vehicle);
                if (ltb_vehicle.Rows.Count == 1)
                    lret = ltb_vehicle.Rows[0];
                else
                    lret = null;
            }
            catch (Exception ex)
            {
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //车辆权限检查，与服务器session比较
        private bool authority(string usr, string pwd, string car)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
            bool lret = false;
            try
            {
              
                string lsql = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();

                #region 访问数据库
                lsql += "DECLARE @USR varchar(50)\n";
                lsql += "DECLARE @PWD varchar(50)\n";
                lsql += "DECLARE @nLEVEL INT\n";
                lsql += "DECLARE @UNIT varchar(50)\n";
                lsql += "DECLARE @CAR varchar(50)\n";
                lsql += "\n";
                lsql += "SET @USR = '" + usr + "'\n";
                lsql += "SET @PWD = '" + pwd + "'\n";
                lsql += "SET @CAR = '" + car + "'\n";
                lsql += "\n";
                lsql += "SELECT @UNIT = UnitId FROM [MspBase].[dbo].[LoginUsers]\n";
                lsql += "WHERE UserId = @USR\n";
                lsql += "  AND PassWord = @PWD  \n";
                lsql += "\n";
                lsql += "SET @nLEVEL = 0\n";
                lsql += "\n";
                lsql += "\n";
                lsql += "CREATE TABLE #T(UNITID VARCHAR(50),nLEVEL INT)\n";
                lsql += "INSERT INTO #T VALUES(@UNIT,0)\n";
                lsql += "\n";
                lsql += "WHILE EXISTS(SELECT * FROM #T)\n";
                lsql += "BEGIN\n";
                lsql += "IF EXISTS(\n";
                lsql += "SELECT * FROM [MspBase].[dbo].[InfoUnit] \n";
                lsql += " WHERE [ParentUnitId] IN\n";
                lsql += " (SELECT UNITID FROM #T WHERE nLEVEL = @nLEVEL)\n";
                lsql += " )\n";
                lsql += " BEGIN\n";
                lsql += "INSERT INTO #T \n";
                lsql += "SELECT [UnitId],@nLEVEL + 1\n";
                lsql += "  FROM [MspBase].[dbo].[InfoUnit] \n";
                lsql += " WHERE [ParentUnitId] IN\n";
                lsql += " (SELECT UNITID FROM #T WHERE nLEVEL =@nLEVEL)\n";
                lsql += " SET @nLEVEL = @nLEVEL + 1\n";
                lsql += " END\n";
                lsql += " ELSE\n";
                lsql += " BEGIN\n";
                lsql += "    BREAK\n";
                lsql += " END\n";
                lsql += "END\n";
                lsql += "\n";
                lsql += "\n";
                lsql += "SELECT VehicleNum FROM [MspBase].[dbo].[InfoVehicle]\n";
                lsql += " WHERE ParentUnitId IN\n";
                lsql += "(\n";
                lsql += "SELECT UNITID FROM #T\n";
                lsql += ")\n";
                lsql += "AND VehicleId = @CAR \n";
                lsql += "\n";
                lsql += "DROP TABLE #T\n";
                #endregion

                lcnn.Open();
                lcmd.Connection = lcnn;
                lcmd.CommandText = lsql;
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_vehicle);
                if (ltb_vehicle.Rows.Count == 1)
                    lret = true;
                else
                    lret = false;
            }
            catch (Exception ex)
            {
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //车牌自动完成查询
        private string getFilterVehicleId(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                lcmd.CommandText = "SELECT TOP 10 VehicleId,VehicleNum,UserDefine1,UserDefine2,UserDefine3 FROM [MspBase].[dbo].[InfoVehicle]  WHERE VehicleId LIKE '%" + keyWord + "%' ";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_vehicle);
                if (ltb_vehicle.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_vehicle,Formatting.Indented);
                }
            }
            catch (Exception)
            {                
                //throw;
            }

            return lret;
        }
        //最后位置查询
        private string last_poi_location(string last_poi_usr, string last_poi_pwd, string last_poi_car)
        {
            string lret = "";
            string ret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string car_no = last_poi_car;
                string lng = "";
                string lat = "";
                string lasttime = "";
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                };
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                if (car_no == null) 
                {
                    result.success = false;
                    result.message = "无车牌号";
                    return JsonConvert.SerializeObject(result);
                };
                if (!authority(usr, pwd, car_no))
                {
                    result.success = false;
                    result.message = "没有此权限";
                    return JsonConvert.SerializeObject(result);
                }
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_gpswarn = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回车辆基础表infovehicle，业务表gpsbase,gpswarn信息
                lsql += "   declare @dbbase varchar(100)\n";
                lsql += "   declare @dbgps varchar(1000)\n";
                lsql += "   declare @ParaDef varchar(1000)\n";
                lsql += "   declare @sql Nvarchar(1000)\n";
                lsql += "   declare @vehicleIdVar varchar(100)\n";
                lsql += "    \n";
                lsql += "   set @dbbase = N'MspBase' \n";
                lsql += "   set @dbgps = N'MspHistory' + CONVERT(varchar(6),getdate(),112) \n";
                lsql += "      \n";
                lsql += "   set @sql = N'   \n";
                lsql += "   declare @vehicleNum varchar(40)   \n";
                lsql += "   declare @simId varchar(40)   \n";
                lsql += "   declare @lRetSetUp bit   \n";
                lsql += "   declare @lSetupDate Datetime   \n";
                lsql += "   declare @lWorkOK bit   \n";
                lsql += "   declare @vehicleId varchar(100)   \n";
                lsql += "   set @vehicleId = ''" + car_no + "'' \n ";
                lsql += "   select @vehicleNum = VehicleNum,  \n ";
                lsql += "      @simId = SimId   \n";
                lsql += "      from ' + @dbbase + '..InfoVehicle   \n ";
                lsql += "      where VehicleId = @vehicleId   \n";
                lsql += "      \n";
                lsql += "   select * from ' + @dbbase + '..InfoVehicle where VehicleId = @vehicleId  \n ";
                lsql += "   select * from ' + @dbgps + '..GpsBase  \n ";
                lsql += "   where Id in   \n";
                lsql += "   (   \n";
                lsql += "   select MAX(Id) from ' + @dbgps + '..GpsBase where VehicleNum=@vehicleNum   \n";
                lsql += "   )   \n";
                lsql += "      \n";
                lsql += "   select * from ' + @dbgps + '..GpsWarn  \n ";
                lsql += "   where SimId = @simId and BeginTime =   \n ";
                lsql += "   (   \n";
                lsql += "   select MAX(BeginTime) from ' + @dbgps + '..GpsWarn  \n ";
                lsql += "   where SimId = @simId   \n";
                lsql += "   )\n";
                //lsql += "   select * from ' + @dbbase + '..TranTaskList where 1 = 0   ";
                lsql += "'   \n";
                lsql += "      \n";
                lsql += "   print @sql   \n";
                lsql += "       \n";
                lsql += "   EXECUTE sp_executesql @sql  \n ";
                #endregion

                lsbdr.AppendFormat(lsql, car_no);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);

                ltb_vehicle = lds.Tables[0];
                ltb_gpsbase = lds.Tables[1];
                ltb_gpswarn = lds.Tables[2];

                if (ltb_vehicle.Rows.Count > 0)
                {
                    result.success=true;
                    ret = "1," + ((DateTime)ltb_vehicle.Rows[0]["InstallDate"]).ToString("yyyyMMdd");
                    if (ltb_gpsbase.Rows.Count > 0)
                    {
                        //返回百度地址,经纬度未纠偏
                        lng = ltb_gpsbase.Rows[0]["Lng"].ToString();
                        lat = ltb_gpsbase.Rows[0]["Lat"].ToString();
                        string pos_addr = dbhelper.GgpsTranslate2BaiduPoi(lng, lat);
                        DateTime lgpsbasetime = DateTime.Parse(ltb_gpsbase.Rows[0]["RecordTime"].ToString());
                        lasttime = lgpsbasetime.ToString("MM-dd HH:mm");
                        if (lgpsbasetime.AddMinutes(30) < DateTime.Now)
                            ret = ret + ",0,[" + pos_addr + "]";
                        else
                            ret = ret + ",1,[" + pos_addr + "]";
                    }
                    else
                    {
                        ret = ret + ",0";
                    }

                    string[] split = ret.Split(',');
                    if (split.Count() == 4)
                    {
                        msg += split[0] == "1" ? "GPS已安装" : "GPS未安装";
                        msg += " ";
                        msg += split[2] == "1" ? "信号正常" : "GPS失联超过30分";
                        msg += "<br>";
                        msg += "安装时间:" + split[1];
                        msg += "<br>";
                        msg += "位置:" + split[3];
                    }
                    else
                    {
                        throw new Exception("GPS资料异常，请检查！");
                    }
                    lsbdr.Clear();
                    Dictionary<string, string> lastPoi = new Dictionary<string, string>();
                    lastPoi.Add("lng", lng);
                    lastPoi.Add("lat", lat);
                    lastPoi.Add("msg", msg);
                    lastPoi.Add("lasttime", lasttime);
                    //lsbdr.AppendFormat("{{'lng':'{0}','lat':{1},'msg':'{2}','lasttime':'{3}'}}", lng, lat, msg, lasttime);
                    result.data = lastPoi;
                    lret = "";
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //实时数据查询
        private string realtime_pos(string last_poi_usr, string last_poi_pwd, string last_poi_car)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string car_no = last_poi_car;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                };
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                if (car_no == null)
                {
                    result.success = false;
                    result.message = "无车牌号";
                    return JsonConvert.SerializeObject(result);
                };
                if (!authority(usr, pwd, car_no))
                {
                    result.success = false;
                    result.message = "没有此权限";
                    return JsonConvert.SerializeObject(result);
                }

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string recordtime = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_gpswarn = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回车辆基础表infovehicle，业务表gpsbase,gpswarn信息
                lsql += " DECLARE @CurTime as DATETIME\n";
                lsql += " DECLARE @VehicleId VARCHAR(40)\n";
                lsql += " DECLARE @GPSBasicDb as VARCHAR(50)\n";
                lsql += " DECLARE @GPSHisDb as VARCHAR(50)\n";
                lsql += " DECLARE @CurDb as VARCHAR(50)\n";
                lsql += " DECLARE @SQL VARCHAR(1000)\n";
                lsql += "\n";
                lsql += " SET @GPSBasicDb = 'MspBase'\n";
                lsql += " SET @GPSHisDb = 'MspHistory'\n";
                lsql += " SET @VehicleId = '" + car_no + "'\n";
                lsql += " \n";
                lsql += " CREATE TABLE #T(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime varchar(20),direction int,lng float,lat float,mileage float)\n";
                lsql += "\n";
                lsql += " PRINT CONVERT(VARCHAR(6),@CurTime,112)\n";
                lsql += " SET @CurDb = @GPSHisDb + CONVERT(VARCHAR(6),GETDATE(),112)\n";
                lsql += "\n";
                lsql += " SET @SQL = N'INSERT INTO #T(id ,vehicleNum,speed ,recordtime ,direction,lng ,lat ,mileage)\n";
                lsql += " SELECT TOP 1 GB.Id,GB.VehicleNum,GB.Speed,convert(varchar(20),GB.RecordTime,120),GB.Direction,GB.Lng,GB.Lat,GB.Mileage\n";
                lsql += " FROM ' + @CurDb + '..GpsBase GB\n";
                lsql += " WHERE 1 = 1\n";
                lsql += "   AND GB.VehicleNum = (SELECT VehicleNum FROM ' + @GPSBasicDb + '..InfoVehicle WHERE VehicleId='''+@VehicleId+''' )\n";
                lsql += "   AND GB.Speed >= 0\n";
                lsql += "   AND GB.Id = (SELECT MAX(Id) FROM ' + @CurDb + '..GpsBase GB WHERE VehicleNum = \n";
                lsql += "   (SELECT VehicleNum FROM ' + @GPSBasicDb + '..InfoVehicle WHERE VehicleId='''+@VehicleId+''' ))'\n";
                lsql += " EXECUTE sp_sqlexec @SQL  \n";
                lsql += " SELECT it,speed,substring(recordtime,6,11) as recordtime,direction,lng,lat,mileage FROM #T\n";
                lsql += " \n";
                lsql += " DROP TABLE #T\n";

                #endregion

                lsbdr.AppendFormat(lsql, car_no);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_gpsbase);


                if (ltb_gpsbase.Rows.Count > 0)
                {
                    result.success = true;
                    //string json = JsonConvert.SerializeObject(ltb_gpsbase, Formatting.Indented);
                    result.data = ltb_gpsbase;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //历史数据查询
        private string history_pos(string last_poi_usr, string last_poi_pwd, string last_poi_car,string begin_time,string end_time)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string car_no = last_poi_car;
                try
                {
                    DateTime dtBegin_time = DateTime.Parse(begin_time);
                    DateTime dtEnd_time = DateTime.Parse(end_time);
                }
                catch (Exception)
                {
                    result.success = false;
                    result.message = "起始时间格式错误";
                    return JsonConvert.SerializeObject(result);
                }
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                if (car_no == null)
                {
                    result.success = false;
                    result.message = "无车牌号";
                    return JsonConvert.SerializeObject(result);

                }
                if (!authority(usr, pwd, car_no))
                {
                    result.success = false;
                    result.message = "没有此权限";
                    return JsonConvert.SerializeObject(result);
                }
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_gpswarn = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回车辆基础表infovehicle，业务表gpsbase,gpswarn信息
                lsql += " DECLARE @BeginTime as DATETIME\n";
                lsql += " DECLARE @EndTime as DATETIME\n";
                lsql += " DECLARE @sBeginTime as VARCHAR(21)\n";
                lsql += " DECLARE @sEndTime as VARCHAR(21)\n";
                lsql += " DECLARE @CurTime as DATETIME\n";
                lsql += " DECLARE @VehicleId VARCHAR(40)\n";
                lsql += " DECLARE @SaleReg as VARCHAR(50)\n";
                lsql += " DECLARE @GPSBasicDb as VARCHAR(50)\n";
                lsql += " DECLARE @GPSHisDb as VARCHAR(50)\n";
                lsql += " DECLARE @CurDb as VARCHAR(50)\n";
                lsql += " DECLARE @TaskId as VARCHAR(50)\n";
                lsql += " DECLARE @SQL VARCHAR(1000)\n";
                lsql += " DECLARE @SaleAddr VARCHAR(50)\n";
                lsql += " \n";
                lsql += " SET @GPSBasicDb = 'MspBase'\n";
                lsql += " SET @GPSHisDb = 'MspHistory'\n";
                lsql += " SET @BeginTime = '" + begin_time + "'\n";
                lsql += " SET @EndTime = '" + end_time + "'\n";
                lsql += " SET @sBeginTime = CONVERT(VARCHAR(21),@BeginTime,120)\n";
                lsql += " SET @sEndTime = CONVERT(VARCHAR(21),@EndTime,120)\n";
                lsql += " SET @VehicleId = '" + car_no + "'\n";
                lsql += " \n";
                lsql += " \n";
                lsql += " \n";
                lsql += " CREATE TABLE #T(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime varchar(20),direction float,lng float,lat float)\n";
                lsql += " CREATE TABLE #T1(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime varchar(20),direction float,lng float,lat float)\n";
                lsql += " \n";
                lsql += " SET @CurTime = @BeginTime\n";
                lsql += " PRINT 'NOW'\n";
                lsql += " WHILE CONVERT(VARCHAR(6),@CurTime,112) <= CONVERT(VARCHAR(6),@EndTime,112)\n";
                lsql += " BEGIN\n";
                lsql += " PRINT CONVERT(VARCHAR(6),@CurTime,112)\n";
                lsql += " SET @CurDb = @GPSHisDb + CONVERT(VARCHAR(6),@CurTime,112)\n";
                lsql += " \n";
                lsql += " SET @SQL = N'INSERT INTO #T1(id ,vehicleNum,speed ,recordtime ,direction,lng ,lat )\n";
                lsql += " SELECT GB.Id,GB.VehicleNum,GB.Speed,convert(varchar(20),GB.RecordTime,20),GB.Direction,GB.Lng,GB.Lat\n";
                lsql += " FROM ' + @CurDb + '..GpsBase GB\n";
                lsql += " WHERE 1 = 1\n";
                lsql += "   AND GB.VehicleNum = (SELECT VehicleNum FROM ' + @GPSBasicDb + '..InfoVehicle WHERE VehicleId='''+@VehicleId+''' )\n";
                lsql += "   AND GB.Speed >= 0\n";
                lsql += "   AND GB.Id BETWEEN ''' + SUBSTRING(@sBeginTime,3,2) + SUBSTRING(@sBeginTime,6,2) + SUBSTRING(@sBeginTime,9,2) + SUBSTRING(@sBeginTime,12,2) + SUBSTRING(@sBeginTime,15,2) + SUBSTRING(@sBeginTime,18,2) + '''\n";
                lsql += "                 AND ''' + SUBSTRING(@sEndTime,3,2) + SUBSTRING(@sEndTime,6,2) + SUBSTRING(@sEndTime,9,2) + SUBSTRING(@sEndTime,12,2) + SUBSTRING(@sEndTime,15,2) + SUBSTRING(@sEndTime,18,2) + '''\n";
                lsql += "   '\n";
                lsql += " PRINT @SQL\n";
                lsql += " EXECUTE sp_sqlexec @SQL\n";
                lsql += " SET @CurTime = DATEADD(MONTH,1,@CurTime)\n";
                lsql += " END\n";
                lsql += "     \n";
                lsql += " INSERT INTO #T(vehicleNum,speed ,recordtime ,direction ,lng ,lat)\n";
                lsql += " SELECT vehicleNum,speed ,SUBSTRING(recordtime,6,11),direction ,lng ,lat\n";
                lsql += " FROM #T1\n";
                lsql += " ORDER BY vehicleNum,recordtime\n";
                lsql += " SELECT it,speed,recordtime,direction,lng,lat FROM #T\n";
                lsql += " \n";
                lsql += " DROP TABLE #T\n";
                lsql += " DROP TABLE #T1\n";
                #endregion

                lsbdr.AppendFormat(lsql, car_no, begin_time, end_time);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_gpsbase);


                if (ltb_gpsbase.Rows.Count > 0)
                {
                    result.success = true;
                    //string json = JsonConvert.SerializeObject(ltb_gpsbase, Formatting.Indented);
                    result.data = ltb_gpsbase;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }
                    
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //历史停车查询
        private string history_park(string last_poi_usr, string last_poi_pwd, string last_poi_car, string begin_time, string end_time, string page, string rows)
        {
            string lret = "";
            classResult result=new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string car_no = last_poi_car;
                try{
                    DateTime dtBegin_time = DateTime.Parse(begin_time);
                    DateTime dtEnd_time = DateTime.Parse(end_time);
                }
                catch (Exception)
                {
                    result.success=false;
                    result.message="起始时间格式错误";
                    return JsonConvert.SerializeObject(result);
                }

                if (usr == null){
                  result.success=false;
                  result.message = "无用户名";
                  return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                if (car_no == null)
                {
                    result.success = false;
                    result.message = "无车牌号";
                    return JsonConvert.SerializeObject(result);

                }
                if (!authority(usr, pwd, car_no))
                {
                    result.success = false;
                    result.message = "没有此权限";
                    return JsonConvert.SerializeObject(result);
                }

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回车停车点信息
                lsql += "DECLARE @BeginTime as DATETIME\n";
                lsql += "DECLARE @EndTime as DATETIME\n";
                lsql += "DECLARE @sBeginTime as VARCHAR(21)\n";
                lsql += "DECLARE @sEndTime as VARCHAR(21)\n";
                lsql += "DECLARE @CurTime as DATETIME\n";
                lsql += "DECLARE @VehicleNum as VARCHAR(50)\n";
                lsql += "DECLARE @VehicleId as VARCHAR(50)\n";
                lsql += "DECLARE @SaleReg as VARCHAR(50)\n";
                lsql += "DECLARE @GPSBasicDb as VARCHAR(50)\n";
                lsql += "DECLARE @GPSHisDb as VARCHAR(50)\n";
                lsql += "DECLARE @CurDb as VARCHAR(50)\n";
                lsql += "DECLARE @TaskId as VARCHAR(50)\n";
                lsql += "DECLARE @SQL VARCHAR(1000)\n";
                lsql += "DECLARE @SaleAddr VARCHAR(50)\n";
                lsql += "DECLARE @Page INT\n";
                lsql += "DECLARE @Rows INT\n";
                lsql += "\n";
                lsql += "SET @GPSBasicDb = 'MspBase'\n";
                lsql += "SET @GPSHisDb = 'MspHistory'\n";
                lsql += "SET @BeginTime = '" + begin_time + "'\n";
                lsql += "SET @EndTime = '" + end_time + "'\n";
                lsql += "--SET @VehicleNum = 'VEHI20151025062459489604'\n";
                lsql += "SET @VehicleNum = '%'\n";
                lsql += "SET @VehicleId = '" + car_no + "'\n";
                lsql += "--SET @SaleAddr = '%'\n";
                lsql += "SET @Page = "+ page +"\n";
                lsql += "SET @Rows = " + rows + "\n";
                lsql += "\n";
                lsql += "\n";
                lsql += "CREATE TABLE #T(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime datetime,td_id varchar(40),lng float,lat float)\n";
                lsql += "CREATE TABLE #T1(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime datetime,td_id varchar(40),lng float,lat float)\n";
                lsql += "CREATE TABLE #Y(it INT IDENTITY,a DATETIME,b DATETIME,nMin INT,lng FLOAT,lat FLOAT)\n";
                lsql += "\n";
                lsql += "SET @CurTime = @BeginTime\n";
                lsql += "SET @sBeginTime = CONVERT(VARCHAR(21),@BeginTime,120)\n";
                lsql += "SET @sEndTime = CONVERT(VARCHAR(21),@EndTime,120)\n";
                lsql += "WHILE CONVERT(VARCHAR(6),@CurTime,112) <= CONVERT(VARCHAR(6),@EndTime,112)\n";
                lsql += "BEGIN\n";
                lsql += "PRINT CONVERT(VARCHAR(6),@CurTime,112)\n";
                lsql += "SET @CurDb = @GPSHisDb + CONVERT(VARCHAR(6),@CurTime,112)\n";
                lsql += "\n";
                lsql += "SET @SQL = N'INSERT INTO #T1(id ,vehicleNum,speed ,recordtime ,td_id ,lng ,lat )\n";
                lsql += "SELECT GB.Id,GB.VehicleNum,GB.Speed,GB.RecordTime,NULL,GB.Lng,GB.Lat\n";
                lsql += "FROM ' + @CurDb + '..GpsBase GB\n";
                lsql += "WHERE 1 = 1\n";
                lsql += "  AND GB.Speed > 0\n";
                lsql += "  AND GB.VehicleNum = (SELECT VehicleNum FROM ' + @GPSBasicDb + '..InfoVehicle WHERE VehicleId = '''+@VehicleId+''')\n";
                lsql += "  AND GB.Id BETWEEN ''' +  SUBSTRING(@sBeginTime,3,2)+SUBSTRING(@sBeginTime,6,2)+SUBSTRING(@sBeginTime,9,2)+ SUBSTRING(@sBeginTime,12,2)+SUBSTRING(@sBeginTime,15,2)+SUBSTRING(@sBeginTime,18,2) + '''\n";
                lsql += "  AND ''' +  SUBSTRING(@sEndTime,3,2)+SUBSTRING(@sEndTime,6,2)+SUBSTRING(@sEndTime,9,2)+ SUBSTRING(@sEndTime,12,2)+SUBSTRING(@sEndTime,15,2)+SUBSTRING(@sEndTime,18,2) + '''\n";
                lsql += "  '\n";
                lsql += "  \n";
                lsql += "PRINT @SQL\n";
                lsql += "PRINT 'OK1'\n";
                lsql += "EXECUTE sp_sqlexec @SQL\n";
                lsql += "SET @CurTime = DATEADD(MONTH,1,@CurTime)\n";
                lsql += "END\n";
                lsql += "    \n";
                lsql += "INSERT INTO #T(vehicleNum,speed ,recordtime ,td_id ,lng ,lat)\n";
                lsql += "SELECT vehicleNum,speed ,recordtime ,td_id ,lng ,lat\n";
                lsql += "FROM #T1\n";
                lsql += "ORDER BY vehicleNum,recordtime\n";
                lsql += "\n";
                lsql += "INSERT INTO #Y(a,b,nMin,lng,lat)\n";
                lsql += "SELECT A.recordtime a_recordtime,\n";
                lsql += "   B.recordtime b_recordtime,\n";
                lsql += "   DATEDIFF(MINUTE,A.recordtime,B.recordtime) park_minute,\n";
                lsql += "   B.lng,B.lat \n";
                lsql += "FROM #T A ,#T B\n";
                lsql += "WHERE A.it =B.it - 1\n";
                lsql += "  AND A.vehicleNum = B.vehicleNum\n";
                lsql += "  AND DATEDIFF(MINUTE,A.recordtime , B.recordtime) > 10\n";
                lsql += "\n";
                lsql += "DECLARE @SQL1 VARCHAR(1000)\n";
                lsql += "SET @SQL1 = '\n";
                lsql += "SELECT TOP '+CONVERT(VARCHAR(10),@Rows)+' it,SUBSTRING(CONVERT(VARCHAR(21),a,120),6,11) a,SUBSTRING(CONVERT(VARCHAR(21),b,120),6,11) b,nMin,lng,lat\n";
                lsql += "FROM #Y\n";
                lsql += "WHERE it > ' + CONVERT(VARCHAR(10),@Rows*(@Page-1))\n";
                lsql += "EXECUTE sp_sqlexec @SQL1\n";
                lsql += "SELECT count(*) FROM #Y\n";
                lsql += "\n";
                lsql += "DROP TABLE #T\n";
                lsql += "DROP TABLE #T1\n";
                lsql += "DROP TABLE #Y\n";

                #endregion

                lsbdr.AppendFormat(lsql, car_no, begin_time, end_time, page, rows);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);
                ltb_gpsbase = lds.Tables[0];
                ltb_rows = lds.Tables[1];

                if (ltb_gpsbase.Rows.Count > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    string lrows = ltb_rows.Rows[0][0] == null ? "0" : ltb_rows.Rows[0][0].ToString();
                    dics.Add("total", lrows);
                    dics.Add("rows", ltb_gpsbase);
                    result.data = dics;
                    result.message = "查询成功";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret= JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        ////区域查询
        //private string region(string region_usr, string region_pwd, string region_car, string begin_time, string end_time, string page, string rows,string crud)
        //{
        //    string lret = "";
        //    try
        //    {
        //        string usr = region_usr;
        //        string pwd = region_pwd;
        //        string car_no = region_car;
        //        try
        //        {
        //            DateTime dtBegin_time = DateTime.Parse(begin_time);
        //            DateTime dtEnd_time = DateTime.Parse(end_time);
        //        }
        //        catch (Exception)
        //        {
        //            return "{'err':'起始时间格式错误'}";
        //        }
        //        if (crud == null)
        //        {
        //            return "{'err':'没有操作产生'}"; ;
        //        }

        //        switch (crud)
        //        {
        //            case "q":
        //                lret = region_q(region_usr,region_pwd,region_car,begin_time,end_time,page,rows,crud);
        //                break;
        //            case "c":
        //                lret = region_c(region_usr,region_pwd,region_car,begin_time,end_time,page,rows,crud);
        //                break;
        //            case "e":
        //                lret = regfion_e(region_usr,region_pwd,region_car,begin_time,end_time,page,rows,crud);
        //                break;
        //            case "d":
        //                lret = region_d(region_usr,region_pwd,region_car,begin_time,end_time,page,rows,crud);
        //                break;
        //            default:
        //                break;
        //        }
        //        return lret;
        //      }
        //    }
        //     private string region_q(string region_usr, string region_pwd, string region_car, string begin_time, string end_time, string page, string rows,string crud)
        //     {
        //         string lret = "";
        //         try
        //         {
        //             string usr = region_usr;
        //             string pwd = region_pwd;
        //             string car_no = region_pwd;
        //             try
        //             {
        //                 DateTime dtBegin_time = DateTime.Parse(begin_time);
        //                 DateTime dtEnd_time = DateTime.Parse(end_time);
        //             }
        //             catch (Exception)
        //             {
        //                 return "{'err':'起始时间格式错误'}";
        //             }
        //        if (usr == null) return "{'err':'无用户名'}";
        //        if (pwd == null) return "{'err':'无密码'}";
        //        if (car_no == null) return "{'err':'无车牌号'}";
        //        if (!authority(usr, pwd, car_no))
        //        {
        //            return "{'err':'没有此权限'}";
        //        }
        //        string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
        //        string lsql = "";
        //        SqlDataAdapter ldap = new SqlDataAdapter();
        //        SqlConnection lcnn = new SqlConnection(cnnStr);
        //        SqlCommand lcmd = new SqlCommand();
        //        DataSet lds = new DataSet();
        //        DataTable ltb_gpsbase = new DataTable();
        //        DataTable ltb_rows = new DataTable();
        //        StringBuilder lsbdr = new StringBuilder();
        //        DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

        //        #region 返回车停车点信息
        //        lsql += "DECLARE @BeginTime as DATETIME\n";
        //        lsql += "DECLARE @EndTime as DATETIME\n";
        //        lsql += "DECLARE @sBeginTime as VARCHAR(21)\n";
        //        lsql += "DECLARE @sEndTime as VARCHAR(21)\n";
        //        lsql += "DECLARE @CurTime as DATETIME\n";
        //        lsql += "DECLARE @VehicleNum as VARCHAR(50)\n";
        //        lsql += "DECLARE @VehicleId as VARCHAR(50)\n";
        //        lsql += "DECLARE @SaleReg as VARCHAR(50)\n";
        //        lsql += "DECLARE @GPSBasicDb as VARCHAR(50)\n";
        //        lsql += "DECLARE @GPSHisDb as VARCHAR(50)\n";
        //        lsql += "DECLARE @CurDb as VARCHAR(50)\n";
        //        lsql += "DECLARE @TaskId as VARCHAR(50)\n";
        //        lsql += "DECLARE @SQL VARCHAR(1000)\n";
        //        lsql += "DECLARE @SaleAddr VARCHAR(50)\n";
        //        lsql += "DECLARE @Page INT\n";
        //        lsql += "DECLARE @Rows INT\n";
        //        lsql += "\n";
        //        lsql += "SET @GPSBasicDb = 'MspBase'\n";
        //        lsql += "SET @GPSHisDb = 'MspHistory'\n";
        //        lsql += "SET @BeginTime = '" + begin_time + "'\n";
        //        lsql += "SET @EndTime = '" + end_time + "'\n";
        //        lsql += "--SET @VehicleNum = 'VEHI20151025062459489604'\n";
        //        lsql += "SET @VehicleNum = '%'\n";
        //        lsql += "SET @VehicleId = '" + car_no + "'\n";
        //        lsql += "--SET @SaleAddr = '%'\n";
        //        lsql += "SET @Page = " + page + "\n";
        //        lsql += "SET @Rows = " + rows + "\n";
        //        lsql += "\n";
        //        lsql += "\n";
        //        lsql += "CREATE TABLE #T(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime datetime,td_id varchar(40),lng float,lat float)\n";
        //        lsql += "CREATE TABLE #T1(it INT IDENTITY,vehicleNum VARCHAR(40),id VARCHAR(40),speed float,recordtime datetime,td_id varchar(40),lng float,lat float)\n";
        //        lsql += "CREATE TABLE #Y(it INT IDENTITY,a DATETIME,b DATETIME,nMin INT,lng FLOAT,lat FLOAT)\n";
        //        lsql += "\n";
        //        lsql += "SET @CurTime = @BeginTime\n";
        //        lsql += "SET @sBeginTime = CONVERT(VARCHAR(21),@BeginTime,120)\n";
        //        lsql += "SET @sEndTime = CONVERT(VARCHAR(21),@EndTime,120)\n";
        //        lsql += "WHILE CONVERT(VARCHAR(6),@CurTime,112) <= CONVERT(VARCHAR(6),@EndTime,112)\n";
        //        lsql += "BEGIN\n";
        //        lsql += "PRINT CONVERT(VARCHAR(6),@CurTime,112)\n";
        //        lsql += "SET @CurDb = @GPSHisDb + CONVERT(VARCHAR(6),@CurTime,112)\n";
        //        lsql += "\n";
        //        lsql += "SET @SQL = N'INSERT INTO #T1(id ,vehicleNum,speed ,recordtime ,td_id ,lng ,lat )\n";
        //        lsql += "SELECT GB.Id,GB.VehicleNum,GB.Speed,GB.RecordTime,NULL,GB.Lng,GB.Lat\n";
        //        lsql += "FROM ' + @CurDb + '..GpsBase GB\n";
        //        lsql += "WHERE 1 = 1\n";
        //        lsql += "  AND GB.Speed > 0\n";
        //        lsql += "  AND GB.VehicleNum = (SELECT VehicleNum FROM ' + @GPSBasicDb + '..InfoVehicle WHERE VehicleId = '''+@VehicleId+''')\n";
        //        lsql += "  AND GB.Id BETWEEN ''' +  SUBSTRING(@sBeginTime,3,2)+SUBSTRING(@sBeginTime,6,2)+SUBSTRING(@sBeginTime,9,2)+ SUBSTRING(@sBeginTime,12,2)+SUBSTRING(@sBeginTime,15,2)+SUBSTRING(@sBeginTime,18,2) + '''\n";
        //        lsql += "  AND ''' +  SUBSTRING(@sEndTime,3,2)+SUBSTRING(@sEndTime,6,2)+SUBSTRING(@sEndTime,9,2)+ SUBSTRING(@sEndTime,12,2)+SUBSTRING(@sEndTime,15,2)+SUBSTRING(@sEndTime,18,2) + '''\n";
        //        lsql += "  '\n";
        //        lsql += "  \n";
        //        lsql += "PRINT @SQL\n";
        //        lsql += "PRINT 'OK1'\n";
        //        lsql += "EXECUTE sp_sqlexec @SQL\n";
        //        lsql += "SET @CurTime = DATEADD(MONTH,1,@CurTime)\n";
        //        lsql += "END\n";
        //        lsql += "    \n";
        //        lsql += "INSERT INTO #T(vehicleNum,speed ,recordtime ,td_id ,lng ,lat)\n";
        //        lsql += "SELECT vehicleNum,speed ,recordtime ,td_id ,lng ,lat\n";
        //        lsql += "FROM #T1\n";
        //        lsql += "ORDER BY vehicleNum,recordtime\n";
        //        lsql += "\n";
        //        lsql += "INSERT INTO #Y(a,b,nMin,lng,lat)\n";
        //        lsql += "SELECT A.recordtime a_recordtime,\n";
        //        lsql += "   B.recordtime b_recordtime,\n";
        //        lsql += "   DATEDIFF(MINUTE,A.recordtime,B.recordtime) park_minute,\n";
        //        lsql += "   B.lng,B.lat \n";
        //        lsql += "FROM #T A ,#T B\n";
        //        lsql += "WHERE A.it =B.it - 1\n";
        //        lsql += "  AND A.vehicleNum = B.vehicleNum\n";
        //        lsql += "  AND DATEDIFF(MINUTE,A.recordtime , B.recordtime) > 10\n";
        //        lsql += "\n";
        //        lsql += "DECLARE @SQL1 VARCHAR(1000)\n";
        //        lsql += "SET @SQL1 = '\n";
        //        lsql += "SELECT TOP '+CONVERT(VARCHAR(10),@Rows)+' it,SUBSTRING(CONVERT(VARCHAR(21),a,120),6,11) a,SUBSTRING(CONVERT(VARCHAR(21),b,120),6,11) b,nMin,lng,lat\n";
        //        lsql += "FROM #Y\n";
        //        lsql += "WHERE it > ' + CONVERT(VARCHAR(10),@Rows*(@Page-1))\n";
        //        lsql += "EXECUTE sp_sqlexec @SQL1\n";
        //        lsql += "SELECT count(*) FROM #Y\n";
        //        lsql += "\n";
        //        lsql += "DROP TABLE #T\n";
        //        lsql += "DROP TABLE #T1\n";
        //        lsql += "DROP TABLE #Y\n";

        //        #endregion

        //        lsbdr.AppendFormat(lsql, car_no, begin_time, end_time, page, rows);
        //        lcmd.CommandText = lsbdr.ToString();
        //        lcmd.Connection = lcnn;
        //        lcnn.Open();
        //        ldap.SelectCommand = lcmd;
        //        ldap.Fill(lds);
        //        ltb_gpsbase = lds.Tables[0];
        //        ltb_rows = lds.Tables[1];

        //        if (ltb_gpsbase.Rows.Count > 0)
        //        {
        //            string retrows = JsonConvert.SerializeObject(ltb_gpsbase, Formatting.Indented);
        //            //string json = @"{'total':'" + ltb_gpsbase.Rows.Count.ToString() + @"','rows':" + retrows + @"}";
        //            string lrows = ltb_rows.Rows[0][0] == null ? "0" : ltb_rows.Rows[0][0].ToString();
        //            string json = @"{'total':'" + lrows + "','rows':" + retrows + @"}";
        //            lret = json;
        //        }
        //        else
        //        {
        //            lret = "{'err':'无数据'}";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        lret = "{'err':'" + ex.Message + "'}";
        //        DoErr(ex);
        //        //throw;
        //    }
        //    return lret;
        //}
        //错误处理
        public string DoErr(Exception e)
        {

            StringBuilder sbdr = new StringBuilder();
            try
            {
                sbdr.AppendFormat("Error: Message {0} StackTrace {1} Source {2}", e.Message, e.StackTrace, e.Source);
                log(sbdr.ToString());
            }
            catch (Exception)
            {
                //throw;
            }
            return sbdr.ToString();
        }

        //模糊查找任务单单号
        private string getFilterTaskId(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_task = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回任务单信息

                // lsql += "DECLARE @TaskId as VARCHAR(50)\n";
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT TOP 10 Id,Client\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Task \n";
                lcmd.CommandText += "WHERE Id like '%" + keyWord + "%'";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_task);
                #endregion

                if (ltb_task.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_task, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //模糊查找客户名称
        private string getFilterClientId(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_task = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回客户名称信息
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT TOP 10 Id,Name\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Client\n";
                lcmd.CommandText += "WHERE Name like '%" + keyWord + "%' ORDER BY Id";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_task);
                #endregion

                if (ltb_task.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_task, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //根据客户编码获取客户名称
        private string getClientbyId(string keyWord)
        {
            string lret = "";
            string Id = keyWord;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_Client = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回客户名称信息
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT Id,Name\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Client\n";
                lcmd.CommandText += "WHERE Name like '%" + Id + "%'\n";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_Client);
                #endregion

                if (ltb_Client.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_Client, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //根据客户编码获取联系人信息
        private string getContactbyId(string keyWord)
        {
            string lret = "";
            string Id = keyWord;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_Client = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回客户名称信息
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT Id,Name,Contact master,ContactTel MasterTel\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Client\n";
                lcmd.CommandText += "WHERE Id='" + Id + "'\n";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_Client);
                #endregion

                if (ltb_Client.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_Client, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //模糊查找车辆
        private string getVehicleInfo(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_task = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回任务单信息
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT TOP 10 VehicleNum,VehicleId,VehicleType,UserDefine1,UserDefine2,UserDefine3 \n";
                lcmd.CommandText += "FROM MspBase..InfoVehicle \n";
                lcmd.CommandText += "WHERE VehicleNum like '%" + keyWord + "%' or VehicleId like '%" + keyWord + "%'";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_task);
                #endregion

                if (ltb_task.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_task, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //取得业务员权限
        public DataRow getRightDetailsbyId(string usr, string pwd)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
            string lsql = "";
            string Usr = usr;
            DataRow ret = null;
            SqlDataAdapter ldap = new SqlDataAdapter();
            SqlConnection lcnn = new SqlConnection(cnnStr);
            SqlCommand lcmd = new SqlCommand();
            DataSet lds = new DataSet();
            DataTable ltb_gpsbase = new DataTable();
            DataTable ltb_rows = new DataTable();
            StringBuilder lsbdr = new StringBuilder();
            DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
            //lsql += "select case when (UnitId='UN17030003') then '1' else '0' end as CRD  ,";   //业务部
            //lsql += "case when (UnitId='UN17030004') then '1' else '0' end as SRD, ";           //审核部     SRD
            //lsql += "case when (UnitId='UN17030005') then '1' else '0' end as CT, ";            //车队   CT
            //lsql += "case when (UnitId='UN17030006') then '1' else '0' end as CH ";             //调度    CH
            //lsql += "FROM [MspBase].[dbo].[LoginUsers] where NickName='" + Usr + "' \n";
            lsql += "SELECT UnitId FROM [MspBase].[dbo].[LoginUsers] WHERE NickName = '" + Usr + "'\n";
            lsbdr.AppendFormat(lsql);
            lcmd.CommandText = lsbdr.ToString();
            lcmd.Connection = lcnn;
            lcnn.Open();
            ldap.SelectCommand = lcmd;
            ldap.Fill(lds);
            //string.Format();
            DataTable dt = lds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ret = dt.Rows[0];
            }
            return ret;
        }

        //审核员修改关闭否状态
        public string approveClosedbyUsr(ref HttpContext context, string approveClosed_usr, string approveClosed_pwd)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
            string lsql = "";
            string Id = context.Request["taskId"];
            string usr = approveClosed_usr;
            int rowclosed = 0;
            Object ret = null;
            SqlDataAdapter ldap = new SqlDataAdapter();
            SqlConnection lcnn = new SqlConnection(cnnStr);
            SqlCommand lcmd = new SqlCommand();
            DataSet lds = new DataSet();
            StringBuilder lsbdr = new StringBuilder();
            DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
            lsql = "SELECT Valid,State,Closed FROM  MspBase..SYZG_Task WHERE Id = '" + Id + "'";
            lsbdr.AppendFormat(lsql);
            lcmd.CommandText = lsbdr.ToString();
            lcmd.Connection = lcnn;
            lcnn.Open();
            ldap.SelectCommand = lcmd;
            ldap.Fill(lds);
            DataTable dt = lds.Tables[0];
            bool valid = Convert.ToBoolean(dt.Rows[0][0].ToString());
            string state = dt.Rows[0][1].ToString();
            string closed = dt.Rows[0][2].ToString();
            if (valid && (state != "2") && (closed == "1"))
            {
                //接收申请关闭单，更改关闭否状态
                lsql = "UPDATE MspBase..SYZG_Task set  Closed ='2' where Id='" + Id + "'\n";
                lcnn.Close();
                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                rowclosed = lcmd.ExecuteNonQuery(); ;
                if (rowclosed > 0)
                {
                    ret = new { success = true, message = "批准" + rowclosed + "条关闭申请单" };
                }
                //修改成功后，给工作人员手机发短信  
                sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
                sms.send("请注意,订单" + Id + "已关闭!");
            }
            else
            {
                //无操作

            }
            return JsonConvert.SerializeObject(ret, Formatting.Indented);
        }
        //任务单新增（三一重工）
        private string SYZG_InsertTask(ref HttpContext context,string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
               
                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string ret = "";
               
                classSYZG_Task item = new classSYZG_Task();
                item.Id = context.Request["Id"];	//任务单号
                item.MixId = context.Request["MixId"];	//配比单号
                item.InnerId = context.Request["InnerId"];	//内部任务单号
                item.UerDefine = context.Request["UerDefine"];	//自定义
                item.Factory = context.Request["Factory"];	//生产厂区
                item.PlanBeginTime = Convert.ToDateTime(context.Request["PlanBeginTime"]);	//计划起运时间
                item.PlanEndTime = Convert.ToDateTime(context.Request["PlanEndTime"]);	//计划结束时间
                item.Grade = context.Request["Grade"];	//产品标号
                item.Position = context.Request["Position"];	//施工部位
                item.SlumpCone = Convert.ToInt32(context.Request["SlumpCone"]);	//坍落度
                item.Imper = context.Request["Imper"];	//抗渗等级
                item.Other = context.Request["Other"];	//其它要求
                item.PourType = context.Request["PourType"];	//浇注方式
                item.VehicleType = context.Request["VehicleType"];	//车类型
                item.Type1 = context.Request["Type1"];	//泵车属性
                item.VehicleNum = context.Request["VehicleNum"];	//默认车辆
                item.Driver = context.Request["Driver"];	//默认司机
                item.Distance = Convert.ToDecimal(context.Request["Distance"]);	//运输运距
                item.Memo = context.Request["Memo"];	//备注
                item.Contract = context.Request["Contract"];	//工程合同
                item.PlanProjTotal = Convert.ToInt32(context.Request["PlanProjTotal"]);	//工程预计方量
                item.PlanTaskTotal = Convert.ToInt32(context.Request["PlanTaskTotal"]);	//任务预计方量
                item.Client = context.Request["Client"];	//客户
                item.Site = context.Request["Site"];	//客户工地
                item.SiteName = context.Request["SiteName"];	//施工地
                item.Contact = context.Request["Contact"];	//联系人
                item.Tel = context.Request["Tel"];	//联系电话
                item.State = context.Request["State"];	//状态
                item.ShipCount = Convert.ToInt32(context.Request["ShipCount"]);	//运送次数
                item.ShipTime = Convert.ToInt32(context.Request["ShipTime"]);	//运送时间
                item.DeliveryQty = Convert.ToDecimal(context.Request["DeliveryQty"]);	//已送数量
                item.UnloadTime = Convert.ToInt32(context.Request["UnloadTime"]);	//卸料时间
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.RentType = context.Request["RentType"];//租赁方式
                item.RentUnitPrice = Convert.ToDecimal(context.Request["RentUnitPrice"]);//租赁单价
                item.Closed = context.Request["Closed"];//关闭否
                item.InsertDate = DateTime.Now.ToLocalTime();	//创建时间
                item.InsertId = context.Request["InsertId"];	//创建人
                item.ModiDate = DateTime.Now.ToLocalTime();	//修改时间
                item.ModiId = context.Request["usr"];	//修改人
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
            #region 取得最新编号
            lsql += " /*\n";
            lsql += " 计算当月基本资料表的ID号，递增加1，如果没有则从0001开始\n";
            lsql += " 参数\n";
            lsql += " @NO：序号\n";
            lsql += " @DC：单别\n";
            lsql += " @ID：资料编号，单别+YYMM+序号\n";
            lsql += " 使用时修改DC，表名，标识列\n";
            lsql += " */\n";
            lsql += " \n";
            lsql += " DECLARE @NO VARCHAR(10)\n";
            lsql += " DECLARE @DC VARCHAR(2)\n";
            lsql += " DECLARE @ID VARCHAR(10)\n";
            lsql += "\n";
            lsql += " SET @DC = 'ST'\n";
            lsql += " \n";
            //lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+(CONVERT(VARCHAR(4),(RIGHT(MAX(Id),4))+1))),4),'0001'))\n";//流水号升级16进制
            lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+RIGHT(CONVERT(VARCHAR(10),CONVERT(VARBINARY ,(CONVERT(VARBINARY ,'0x'+RIGHT(MAX(Id),4),1)) + 1,1),1),4)),4),'0001'))\n";
            lsql += " FROM MspBase..SYZG_Task \n";
            lsql += " WHERE Id LIKE @DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+'%'\n";
            lsql += " \n";
            lsql += " SET @ID=@DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+@NO\n";
            lsql += " \n";
            lsql += " SELECT @ID\n";
            #endregion
            #region 新增SQL
            lsql += "INSERT INTO MspBase..SYZG_Task(\n";
            lsql += "Id,\n";	//任务单号
            lsql += "MixId,\n";	//配比单号
            lsql += "InnerId,\n";	//内部任务单号
            lsql += "UerDefine,\n";	//自定义
            lsql += "Factory,\n";	//生产厂区
            lsql += "PlanBeginTime,\n";	//计划起运时间
            lsql += "PlanEndTime,\n";	//计划结束时间
            lsql += "Grade,\n";	//产品标号
            lsql += "Position,\n";	//施工部位
            lsql += "SlumpCone,\n";	//坍落度
            lsql += "Imper,\n";	//抗渗等级
            lsql += "Other,\n";	//其它要求
            lsql += "PourType,\n";	//浇注方式
            lsql += "VehicleType,\n";	//泵车类型
            lsql += "Type1,\n";	//泵车属性
            lsql += "VehicleNum,\n";	//默认车辆
            lsql += "Driver,\n";	//默认司机
            lsql += "Distance,\n";	//运输运距
            lsql += "Memo,\n";	//备注
            lsql += "Contract,\n";	//工程合同
            lsql += "PlanProjTotal,\n";	//工程预计方量
            lsql += "PlanTaskTotal,\n";	//任务预计方量
            lsql += "Client,\n";	//客户
            lsql += "Site,\n";	//客户工地
            lsql += "SiteName,\n";	//施工地
            lsql += "Contact,\n";	//联系人
            lsql += "Tel,\n";	//联系电话
            lsql += "State,\n";	//状态
            lsql += "ShipCount,\n";	//运送次数
            lsql += "ShipTime,\n";	//运送时间
            lsql += "DeliveryQty,\n";	//已送数量
            lsql += "UnloadTime,\n";	//卸料时间
            lsql += "Valid,\n";	//有效否
            lsql += "RentType,\n";	//租赁方式
            lsql += "RentUnitPrice,\n";	//租赁单价
            lsql += "Closed,\n";//关闭否
            lsql += "InsertDate,\n";	//创建时间
            lsql += "InsertId,\n";	//创建人
            lsql += "ModiDate,\n";	//修改时间
            lsql += "ModiId\n";	//修改人
            lsql += ") \n";
            lsql += " VALUES(";
            lsql += " @ID,";	//任务单号
            lsql += " '" + item.MixId + "',";	//配比单号
            lsql += " '" + item.InnerId + "',";	//内部任务单号
            lsql += " '" + item.UerDefine + "',";	//自定义
            lsql += " '" + item.Factory + "',";	//生产厂区
            lsql += " '" + item.PlanBeginTime + "',";	//计划起运时间
            lsql += " '" + item.PlanEndTime + "',";	//计划结束时间
            lsql += " '" + item.Grade + "',";	//产品标号
            lsql += " '" + item.Position + "',";	//施工部位
            lsql += " '" + item.SlumpCone + "',";	//坍落度
            lsql += " '" + item.Imper + "',";	//抗渗等级
            lsql += " '" + item.Other + "',";	//其它要求
            lsql += " '" + item.PourType + "',";	//浇注方式
            lsql += " '" + item.VehicleType + "',";	//泵车类型
            lsql += " '" + item.Type1 + "',";	//泵车属性
            lsql += " '" + item.VehicleNum + "',";	//默认车辆
            lsql += " '" + item.Driver + "',";	//默认司机
            lsql += " '" + item.Distance + "',";	//运输运距
            lsql += " '" + item.Memo + "',";	//备注
            lsql += " '" + item.Contract + "',";	//工程合同
            lsql += " '" + item.PlanProjTotal + "',";	//工程预计方量
            lsql += " '" + item.PlanTaskTotal + "',";	//任务预计方量
            lsql += " '" + item.Client + "',";	//客户
            lsql += " '" + item.Site + "',";	//客户工地
            lsql += " '" + item.SiteName + "',";	//施工地
            lsql += " '" + item.Contact + "',";	//联系人
            lsql += " '" + item.Tel + "',";	//联系电话
            lsql += " '" + item.State + "',";	//状态
            lsql += " '" + item.ShipCount + "',";	//运送次数
            lsql += " '" + item.ShipTime + "',";	//运送时间
            lsql += " '" + item.DeliveryQty + "',";	//已送数量
            lsql += " '" + item.UnloadTime + "',";	//卸料时间
            lsql += " '" + item.Valid + "',";	//有效否
            lsql += " '" + item.RentType + "',";	//租赁方式
            lsql += " '" + item.RentUnitPrice + "',";	//租赁单价
            lsql += " '" + item.Closed + "',";	//关闭否
            lsql += " '" + item.InsertDate == null ? "null" : "'" + item.InsertDate.ToString() + "',";	//创建时间
            lsql += " '" + item.InsertId + "',";	//创建人
            lsql += " '" + item.ModiDate == null ? "null" : "'" + item.ModiDate.ToString() + "',";	//修改时间
            lsql += " '" + item.ModiId + "'";	//修改人
            lsql += " )";
            lsql += " SELECT @@ROWCOUNT\n ";
            #endregion
            //取出审核员电话
            lsql += "select distinct Tel from MspBase..LoginUsers  \n";
            lsql += "where UnitId='UN17030004'\n";
            lsbdr.AppendFormat(lsql);
            lcmd.CommandText = lsbdr.ToString();
            lcmd.Connection = lcnn;
            lcnn.Open();
            ldap.SelectCommand = lcmd;
            ldap.Fill(lds);
            string id = lds.Tables[0].Rows[0][0].ToString();
            int rowcount =Convert.ToInt32(lds.Tables[1].Rows[0][0]);
            DataTable tb1 = lds.Tables[2];
            string ApproveTels = "";
            for (int i = 0; i < tb1.Rows.Count; i++)
            {
                ApproveTels += tb1.Rows[i][0] + ",";
            }
            ApproveTels = ApproveTels.Substring(0, ApproveTels.Length - 1);
            //提交成功后，给工作人员手机发短信  
            sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
            if (ApproveTels.Length > 0)
            {
                sms.mobile += "," + ApproveTels;
            }
            sms.send("业务单" + id + "已提交成功,请审核员审核!");
            if (rowcount > 0)
                {   
                    //dics.Add("total", lrows);
                    //dics.Add("rows", ltb_gpsbase);                  
                    result.message = id + "新增成功,新增" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        
        //任务单修改（三一重工）
        private string SYZG_UpdateTask(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string ret = "";

                classSYZG_Task item = new classSYZG_Task();
                item.Id = context.Request["Id"];	//任务单号
                item.MixId = context.Request["MixId"];	//配比单号
                item.InnerId = context.Request["InnerId"];	//内部任务单号
                item.UerDefine = context.Request["UerDefine"];	//自定义
                item.Factory = context.Request["Factory"];	//生产厂区
                item.PlanBeginTime = Convert.ToDateTime(context.Request["PlanBeginTime"]);	//计划起运时间
                item.PlanEndTime = Convert.ToDateTime(context.Request["PlanEndTime"]);	//计划结束时间
                item.Grade = context.Request["Grade"];	//产品标号
                item.Position = context.Request["Position"];	//施工部位
                item.SlumpCone = Convert.ToInt32(context.Request["SlumpCone"]);	//坍落度
                item.Imper = context.Request["Imper"];	//抗渗等级
                item.Other = context.Request["Other"];	//其它要求
                item.PourType = context.Request["PourType"];	//浇注方式
                item.VehicleType = context.Request["VehicleType"];	//泵车类型
                item.Type1 = context.Request["Type1"];	//泵车属性
                item.VehicleNum = context.Request["VehicleNum"];	//默认车辆
                item.Driver = context.Request["Driver"];	//默认司机
                item.Distance = Convert.ToDecimal(context.Request["Distance"]);	//运输运距
                item.Memo = context.Request["Memo"];	//备注
                item.Contract = context.Request["Contract"];	//工程合同
                item.PlanProjTotal = Convert.ToInt32(context.Request["PlanProjTotal"]);	//工程预计方量
                item.PlanTaskTotal = Convert.ToInt32(context.Request["PlanTaskTotal"]);	//任务预计方量
                item.Client = context.Request["Client"];	//客户
                item.Site = context.Request["Site"];	//客户工地
                item.SiteName = context.Request["SiteName"];	//施工地
                item.Contact = context.Request["Contact"];	//联系人
                item.Tel = context.Request["Tel"];	//联系电话
                item.State = context.Request["State"];	//状态
                item.ShipCount = Convert.ToInt32(context.Request["ShipCount"]);	//运送次数
                item.ShipTime = Convert.ToInt32(context.Request["ShipTime"]);	//运送时间
                item.DeliveryQty = Convert.ToDecimal(context.Request["DeliveryQty"]);	//已送数量
                item.UnloadTime = Convert.ToInt32(context.Request["UnloadTime"]);	//卸料时间
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.RentType = context.Request["RentType"];//租赁方式
                item.RentUnitPrice = Convert.ToDecimal(context.Request["RentUnitPrice"]);//租赁单价
                item.Closed = context.Request["Closed"];//租赁单价
                item.InsertId = context.Request["InsertId"];	//创建人
                item.ModiDate = DateTime.Now.ToLocalTime();	//修改时间
                item.ModiId = context.Request["usr"];	//修改人
                //int result = u(item);
                //var lret_c = new { rows = result, data = item, success = true, message = "成功更新" + result + "行" };
                //JsonSerializerSettings set = new JsonSerializerSettings();
                //ret = JsonConvert.SerializeObject(lret_c, Formatting.None, set);
               
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
               
                #region 修改SQL
                lsql += " UPDATE MspBase..SYZG_Task \n";
                lsql += " SET \n";
                lsql += " MixId = '" + item.MixId + "',\n";	//配比单号
                lsql += " InnerId = '" + item.InnerId + "',\n";	//内部任务单号
                lsql += " UerDefine = '" + item.UerDefine + "',\n";	//自定义
                lsql += " Factory = '" + item.Factory + "',\n";	//生产厂区          
                lsql += " PlanBeginTime = '" + item.PlanBeginTime + "',\n";	//计划起运时间
                lsql += " PlanEndTime = '" + item.PlanEndTime + "',\n";	//计划结束时间
                lsql += " Grade = '" + item.Grade + "',\n";	//产品标号
                lsql += " Position = '" + item.Position + "',\n";	//施工部位
                lsql += " SlumpCone = '" + item.SlumpCone + "',\n";	//坍落度
                lsql += " Imper = '" + item.Imper + "',\n";	//抗渗等级
                lsql += " Other = '" + item.Other + "',\n";	//其它要求
                lsql += " PourType = '" + item.PourType + "',\n";	//浇注方式
                lsql += " VehicleType = '" + item.VehicleType + "',\n";	//泵车类型
                lsql += " Type1 = '" + item.Type1 + "',\n";	//泵车属性
                lsql += " VehicleNum = '" + item.VehicleNum + "',\n";	//默认车辆
                lsql += " Driver = '" + item.Driver + "',\n";	//默认司机
                lsql += " Distance = '" + item.Distance + "',\n";	//运输运距
                lsql += " Memo = '" + item.Memo + "',\n";	//备注
                lsql += " Contract = '" + item.Contract + "',\n";	//工程合同
                lsql += " PlanProjTotal = '" + item.PlanProjTotal + "',\n";	//工程预计方量
                lsql += " PlanTaskTotal = '" + item.PlanTaskTotal + "',\n";	//任务预计方量
                lsql += " Client = '" + item.Client + "',\n";	//客户
                lsql += " Site = '" + item.Site + "',\n";	//施工地 
                lsql += " SiteName = '" + item.SiteName + "',\n";	//施工地 
                lsql += " Contact = '" + item.Contact + "',\n";	//联系人
                lsql += " Tel = '" + item.Tel + "',\n";	//联系电话
                lsql += " State = '" + item.State + "',\n";	//状态
                lsql += " ShipCount = '" + item.ShipCount + "',\n";	//运送次数
                lsql += " ShipTime = '" + item.ShipTime + "',\n";	//运送时间
                lsql += " DeliveryQty = '" + item.DeliveryQty + "',\n";	//已送数量
                lsql += " UnloadTime = '" + item.UnloadTime + "',\n";	//卸料时间
                lsql += " Valid='" + item.Valid + "',\n";	//有效否
                lsql += " RentType= '" + item.RentType + "',";	//租赁方式
                lsql += " RentUnitPrice='" + item.RentUnitPrice + "',";	//租赁单价
                lsql += " Closed='" + item.Closed + "',";//关闭否
                //lsql += " InsertDate,\n";	//创建时间
                //lsql += " InsertId,\n";	//创建人
                lsql += " ModiDate = " + (item.ModiDate == null ? "null" : "'" + item.ModiDate.ToString() + "',\n");	//修改时间
                lsql += " ModiId='" + item.ModiId + "'\n";	//修改人
                lsql += " WHERE Id = '" + item.Id + "'\n";

                #endregion

                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                int rowcount=lcmd.ExecuteNonQuery();
                bool valid = item.Valid;
                if (valid)
                {
                    String tsql = "";
                    string dispatcherTels = "";
                    //取出调度员电话
                    tsql += "select distinct l.Tel  from MspBase..LoginUsers l\n";
                    tsql += "where l.UnitId='UN17030006' \n";
                  
                    //审核通过后,任务单状态由0改为6(待派车)
                    tsql += "UPDATE MspBase..SYZG_Task SET State='6' where Id='" + item.Id + "'\n"; 
                    lcnn.Close();
                    lsbdr.AppendFormat(tsql);
                    lcmd.CommandText = lsbdr.ToString();
                    lcmd.Connection = lcnn;
                    lcnn.Open();
                    ldap.SelectCommand = lcmd;
                    ldap.Fill(lds);
                    int rowstate = lcmd.ExecuteNonQuery();
                    DataTable tb1 = lds.Tables[0];
                    for (int i = 0; i < tb1.Rows.Count; i++)
                    {
                        dispatcherTels += tb1.Rows[i][0] + ",";
                    }
                    dispatcherTels = dispatcherTels.Substring(0, dispatcherTels.Length - 1);
                    //修改成功后，给工作人员手机发短信  
                    sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
                    if (dispatcherTels.Length >0)
                    {
                      sms.mobile += "," + dispatcherTels;
                    }
                    sms.send("订单" + item.Id + "已审核成功!");
                }
                else
                {
                    String tsql = "";
                    string BusinessTel = "";
                    //若审核被驳回,任务单状态由0改为2(结束)
                    tsql += "UPDATE MspBase..SYZG_Task SET State='2' where Id='" + item.Id + "'\n";
                    //取出业务员电话
                    tsql += "select l.Tel  from MspBase..LoginUsers l\n";
                    tsql += "left join MspBase ..SYZG_Task t on l.UserId=t.InsertId\n";
                    tsql += "where l.UnitId='UN17030003' AND t.Id= '" + item.Id + "'\n";
                    lcnn.Close();
                    lsbdr.AppendFormat(tsql);
                    lcmd.CommandText = lsbdr.ToString();
                    lcmd.Connection = lcnn;
                    lcnn.Open();
                    ldap.SelectCommand = lcmd;
                    ldap.Fill(lds);
                    int rowstate = lcmd.ExecuteNonQuery();
                    DataTable tb2 = lds.Tables[0];
                    BusinessTel = tb2.Rows[0][0].ToString();
                    //修改成功后，给工作人员手机发短信  
                    sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
                    sms.mobile += "," + BusinessTel;
                    sms.send("订单" + item.Id + "被驳回!");
                }     

                if (rowcount > 0)
                {                
                    result.message ="成功修改" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        
        //任务单报表删除（三一重工）
        private string SYZG_DeleteTask(ref HttpContext context, string last_poi_usr, string last_poi_pwd, string task_Id)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string taskId = task_Id;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";

                classSYZG_Task item = new classSYZG_Task();
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
               
                #region 删除SQL
                lsql += " delete  MspBase..SYZG_Task\n";
                lsql += " WHERE Id = '" + taskId+ "'";
                #endregion

                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                int rowcount = lcmd.ExecuteNonQuery(); 

                if (rowcount > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    result.message = "成功删除" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        
        //任务单报表查询（三一重工）
        private string SYZG_Task(string last_poi_usr, string last_poi_pwd, string last_task_no, string last_task_client,string beginTime,string endTime,string page, string rows)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string task_Id = last_task_no;
                string task_client = last_task_client;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                //if (task_Id == null)
                //{
                //    result.success = false;
                //    result.message = "无任务单号";
                //    return JsonConvert.SerializeObject(result);

                //}
                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回任务单信息
                lsql += "DECLARE @SQL VARCHAR(1000)\n";
                lsql += "DECLARE @Page INT\n";
                lsql += "DECLARE @Rows INT\n";
                lsql += "SET @Page = " + page + "\n";
                lsql += "SET @Rows = " + rows + "\n";
                lsql += "CREATE TABLE #T(it INT IDENTITY,Id varchar(10),MixId varchar(10),InnerId	varchar(32),UerDefine varchar(32),\n";
                lsql += "Factory varchar(10),PlanBeginTime varchar(20),PlanEndTime	varchar(20),Grade varchar(10),Position varchar(32),\n";
                lsql += "SlumpCone varchar(50),Imper varchar(10),Other varchar(32),PourType	varchar(1),VehicleType varchar(20),\n";
                lsql += "Type1 varchar(1),VehicleNum varchar(16),Driver	varchar(16)	,Distance numeric(15,1),Memo varchar(32),\n";
                lsql += "Contract varchar(32),PlanProjTotal numeric(15,2),PlanTaskTotal	numeric(15,2),Client varchar(10),\n";
                lsql += "Site varchar(10),SiteName nvarchar(32),Contact varchar(20),Tel varchar(20),State varchar(1),Closed varchar(1),ShipCount int,ShipTime int,\n";
                lsql += "DeliveryQty numeric(15,2),UnloadTime int,RentType char(1),RentUnitPrice numeric(15,2),Valid bit,\n";
                lsql += "InsertDate varchar(20),InsertId varchar(16),ModiDate varchar(20),ModiId varchar(16))\n";

                lsql += "CREATE TABLE #T1(it INT IDENTITY,Id varchar(10),MixId varchar(10),InnerId	varchar(32),UerDefine varchar(32),\n";
                lsql += "Factory varchar(10),PlanBeginTime varchar(20),PlanEndTime	varchar(20),Grade varchar(10),Position varchar(32),\n";
                lsql += "SlumpCone varchar(50),Imper varchar(10),Other varchar(32),PourType	varchar(1),VehicleType varchar(20),\n";
                lsql += "Type1 varchar(1),VehicleNum varchar(16),Driver	varchar(16)	,Distance numeric(15,1),Memo varchar(32),\n";
                lsql += "Contract varchar(32),PlanProjTotal numeric(15,2),PlanTaskTotal	numeric(15,2),Client varchar(10),\n";
                lsql += "Site varchar(10),SiteName nvarchar(32),Contact varchar(20),Tel varchar(20),State varchar(1),Closed varchar(1),ShipCount int,ShipTime int,\n";
                lsql += "DeliveryQty numeric(15,2),UnloadTime int,RentType char(1),RentUnitPrice numeric(15,2),Valid bit,\n";
                lsql += "InsertDate varchar(20),InsertId varchar(16),ModiDate varchar(20),ModiId varchar(16))\n";

                lsql += " DECLARE @UnitId VARCHAR(30)  \n";
                lsql += "   -------判断使用者所在的部门\n";
                lsql += "  set @UnitId=(SELECT ml.UnitId  from MspBase..LoginUsers ml \n";
                lsql += "    WHERE     1 = 1    AND \n";
                lsql += "    ml.UserId = '" + usr + "')\n";
                lsql += "  if(@UnitId='UN17030003')\n";
                lsql += "   begin \n";
                lsql += "INSERT INTO #T\n";
                lsql += "SELECT mt.Id,mt.MixId,mt.InnerId,UerDefine,mt.Factory,CONVERT(varchar(100),mt.PlanBeginTime,20),CONVERT(varchar(100),mt.PlanEndTime,20),mt.Grade,mt.Position,mt.SlumpCone,mt.Imper,mt.Other,mt.PourType,\n";
                lsql += "mt.VehicleType,mt.Type1,mt.VehicleNum,mt.Driver,mt.Distance,mt.Memo,mt.Contract,mt.PlanProjTotal,mt.PlanTaskTotal,mt.Client,mt.Site,mt.SiteName,mt.Contact,mt.Tel,\n";
                lsql += "mt.State,mt.Closed,mt.ShipCount,mt.ShipTime,mt.DeliveryQty,mt.UnloadTime,mt.RentType,mt.RentUnitPrice,mt.Valid\n";
                lsql += ",CONVERT(varchar(100),mt.InsertDate,20),mt.InsertId,CONVERT(varchar(100),mt.ModiDate,20),mt.ModiId\n";
                lsql += "FROM MspBase..SYZG_Task  mt inner join MspBase..LoginUsers ml on mt.InsertId=ml.UserId \n";
                lsql += "where mt.InsertId='" + usr + "' and mt.Id like ('%" + task_Id + "%') and mt.Client like '%" + task_client + "'\n";
                lsql += "and mt.PlanBeginTime >= '" + beginTime + "' and mt.PlanBeginTime <= '" + endTime + "' \n";
                lsql += " ORDER BY Id DESC\n";

                lsql += "SET @SQL= 'SELECT TOP '+CONVERT(VARCHAR(10),@Rows)+' a.*,b.Name  \n";
                lsql += "FROM #T a LEFT JOIN MspBase..SYZG_Client b ON a.client=b.Id\n";
                lsql += "WHERE  a.it > ' + CONVERT(VARCHAR(10),@Rows*(@Page-1))\n";
                lsql += "EXECUTE sp_sqlexec @SQL\n";
                lsql += "SELECT count(*) FROM #T\n";
                lsql += "   end \n";
                lsql += "  else\n";
                lsql += "   begin \n";
                lsql += "   INSERT INTO #T1\n";
                lsql += "SELECT mt.Id,mt.MixId,mt.InnerId,UerDefine,mt.Factory,CONVERT(varchar(100),mt.PlanBeginTime,20),CONVERT(varchar(100),mt.PlanEndTime,20),mt.Grade,mt.Position,mt.SlumpCone,mt.Imper,mt.Other,mt.PourType,\n";
                lsql += "mt.VehicleType,mt.Type1,mt.VehicleNum,mt.Driver,mt.Distance,mt.Memo,mt.Contract,mt.PlanProjTotal,mt.PlanTaskTotal,mt.Client,mt.Site,mt.SiteName,mt.Contact,mt.Tel,\n";
                lsql += "mt.State,mt.Closed,mt.ShipCount,mt.ShipTime,mt.DeliveryQty,mt.UnloadTime,mt.RentType,mt.RentUnitPrice,mt.Valid\n";
                lsql += ",CONVERT(varchar(100),mt.InsertDate,20),mt.InsertId,CONVERT(varchar(100),mt.ModiDate,20),mt.ModiId\n";
                lsql += "FROM MspBase..SYZG_Task  mt inner join MspBase..LoginUsers ml on mt.InsertId=ml.UserId \n";

                lsql += "where mt.Id like ('%" + task_Id + "%') and mt.Client like ('%" + task_client + "%') and mt.Client like '%" + task_client + "'\n";
                lsql += "and mt.PlanBeginTime >= '" + beginTime + "' and mt.PlanBeginTime <= '" + endTime + "' \n";
                lsql += " ORDER BY Id DESC\n";

                lsql += "SET @SQL= 'SELECT TOP '+CONVERT(VARCHAR(10),@Rows)+' a.*,b.Name  \n";
                lsql += "FROM #T1 a LEFT JOIN MspBase..SYZG_Client b ON a.client=b.Id\n";
                lsql += "WHERE  a.it > ' + CONVERT(VARCHAR(10),@Rows*(@Page-1))\n";
                lsql += "print @SQL\n";
                lsql += "EXECUTE sp_sqlexec @SQL\n";
                lsql += "SELECT count(*) FROM #T1 \n";
                lsql += "   end\n";
                lsql += "DROP TABLE #T\n";
                lsql += "DROP TABLE #T1\n";
                lsql += "\n";

                #endregion

                lsbdr.AppendFormat(lsql, page, rows);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);
                ltb_gpsbase = lds.Tables[0];
                ltb_rows = lds.Tables[1];

                if (ltb_gpsbase.Rows.Count > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    string lrows = ltb_rows.Rows[0][0] == null ? "0" : ltb_rows.Rows[0][0].ToString();
                    dics.Add("total", lrows);
                    dics.Add("rows", ltb_gpsbase);
                    result.data = dics;
                    result.message = "查询成功";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);     
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
       
        //查询工地
        private string getSite(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_vehicle = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                lcmd.CommandText = "select top 10 t.Id,t.SiteName from [MspBase].[dbo].[SYZG_Task] t where t.State <> '2' and t.sitename like '%" + keyWord + "%'";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_vehicle);
                if (ltb_vehicle.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_vehicle, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }
        //模糊查找运输单单号
        private string getFilterShipId(string keyWord)
        {
            string lret = "";
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_task = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回任务单信息

                // lsql += "DECLARE @TaskId as VARCHAR(50)\n";
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT TOP 10 Id\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Ship\n";
                lcmd.CommandText += "WHERE Id like '%" + keyWord + "%'";
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_task);
                #endregion

                if (ltb_task.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_task, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }
        //运输单新增（三一重工）
        private string SYZG_InsertShip(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string ret = "";

                classSYZG_Ship item = new classSYZG_Ship();

                item.Id = context.Request["Id"];	//运单编号
                item.TaskId = context.Request["TaskId"];	//任务单编号
                item.VehicleNum = context.Request["VehicleNum"];	///车辆编号
                item.Rent = Convert.ToBoolean(context.Request["Rent"]);	//外租否
                item.Driver1 = context.Request["Driver1"];	//驾驶员1
                item.Driver2 = context.Request["Driver2"];	//驾驶员2
                item.Driver3 = context.Request["Driver3"];	//驾驶员3
                item.Qty = Convert.ToDecimal(context.Request["Qty"]);//送货数量
                item.Tower = context.Request["Tower"];	//塔楼编号
                item.DisTime = DateTime.Now.ToLocalTime();	//派车时间
                item.LeftFacTime = Convert.ToDateTime("1970-01-01"); ;//离厂时间
                item.RetFacTime = Convert.ToDateTime("1970-01-01"); ;//回厂时间	
                item.ArrSiteTime = Convert.ToDateTime("1970-01-01"); ;//到场时间	
                item.LeftSiteTime = Convert.ToDateTime("1970-01-01"); ;//离场时间	 
                item.BeginUnloadTime = Convert.ToDateTime("1970-01-01"); ;	//开始卸料时间
                item.EndUnloadTime = Convert.ToDateTime("1970-01-01"); ;	//结束卸料时间
                item.DistFactory = Convert.ToDecimal(context.Request["DistFactory"]);	//工厂距离
                item.DistSite = Convert.ToDecimal(context.Request["DistSite"]);	//工地距离
                item.State = context.Request["State"];	//运输状态
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.InsertDate = DateTime.Now.ToLocalTime();	//创建时间
                item.InsertId = context.Request["InsertId"];	//创建人
                item.ModiDate = DateTime.Now.ToLocalTime();	//修改时间
                item.ModiId = context.Request["usr"];	//修改人
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
                #region 取得最新编号
                lsql += " /*\n";
                lsql += " 计算当月基本资料表的ID号，递增加1，如果没有则从0001开始\n";
                lsql += " 参数\n";
                lsql += " @NO：序号\n";
                lsql += " @DC：单别\n";
                lsql += " @ID：资料编号，单别+YYMM+序号\n";
                lsql += " 使用时修改DC，表名，标识列\n";
                lsql += " */\n";
                lsql += " \n";
                lsql += " DECLARE @NO VARCHAR(10)\n";
                lsql += " DECLARE @DC VARCHAR(2)\n";
                lsql += " DECLARE @ID VARCHAR(10)\n";
                lsql += "\n";
                lsql += " SET @DC = 'SS'\n";
                lsql += " \n";
                //lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+(CONVERT(VARCHAR(4),(RIGHT(MAX(Id),4))+1))),4),'0001'))\n";//流水号升级16进制
                lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+RIGHT(CONVERT(VARCHAR(10),CONVERT(VARBINARY ,(CONVERT(VARBINARY ,'0x'+RIGHT(MAX(Id),4),1)) + 1,1),1),4)),4),'0001'))\n";
                lsql += " FROM MspBase..SYZG_Ship \n";
                lsql += " WHERE Id LIKE @DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+'%'\n";
                lsql += " \n";
                lsql += " SET @ID=@DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+@NO\n";
                lsql += " \n";
                lsql += " SELECT @ID\n";
                #endregion
                #region 新增SQL
                lsql += " DECLARE @ERROR INT\n";
                lsql += " SET @ERROR=0\n";
                lsql += " BEGIN TRAN \n";
                lsql += " IF not exists(select VehicleNum from MspBase..InfoVehicle where VehicleNum='" + item.VehicleNum + "')\n";
                lsql += " SET @ERROR=@ERROR+1        \n";
                lsql += " INSERT INTO [MspBase].[dbo].[SYZG_Ship]\n";
                lsql += "            ([Id]\n";
                lsql += "            ,[TaskId]\n";
                lsql += "            ,[VehicleNum]\n";
                lsql += "            ,[Rent]\n";
                lsql += "            ,[Driver]\n";
                lsql += "            ,[Qty]\n";
                lsql += "            ,[Tower]\n";
                lsql += "            ,[DisTime]\n";
                lsql += "            ,[LeftFacTime]\n";
                lsql += "            ,[RetFacTime]\n";
                lsql += "            ,[ArrSiteTime]\n";
                lsql += "            ,[LeftSiteTime]\n";
                lsql += "            ,[BeginUnloadTime]\n";
                lsql += "            ,[EndUnloadTime]\n";
                lsql += "            ,[DistFactory]\n";
                lsql += "            ,[DistSite]\n";
                lsql += "            ,[State]\n";
                lsql += "            ,[Valid]\n";
                lsql += "            ,[InsertDate]\n";
                lsql += "            ,[InsertId]\n";
                lsql += "            ,[ModiDate]\n";
                lsql += "            ,[ModiId])\n";
                lsql += " VALUES(";
                lsql += " @ID,";	//运单编号
                lsql += " '" + item.TaskId + "',";	//任务单编号
                lsql += " '" + item.VehicleNum + "',";	//车辆编号
                lsql += " '" + item.Rent + "',";	//外租否
                //lsql += " '" + item.Driver1 + "'+','+" + item.Driver2 + "'+','+" + item.Driver3+"'";	//派遣人员 
                lsql += " '" + item.Driver1 + "," + item.Driver2 + ";" + item.Driver3 + "',";	//派遣人员 
                lsql += " '" + item.Qty + "',";	//送货数量
                lsql += " '" + item.Tower + "',";	//塔楼编号
                lsql += " '" + item.DisTime.ToString() + "',";	//派车时间
                lsql += " '" + item.LeftFacTime.ToString() + "',";	//离厂时间
                lsql += " '" + item.RetFacTime.ToString() + "',";	//回厂时间
                lsql += " '" + item.ArrSiteTime.ToString() + "',";	//到场时间
                lsql += " '" + item.LeftSiteTime.ToString() + "',";	//离场时间
                lsql += " '" + item.BeginUnloadTime.ToString() + "',";	//开始卸料时间
                lsql += " '" + item.EndUnloadTime.ToString() + "',";	//结束卸料时间 
                lsql += " " + item.DistFactory + ",";	//工厂距离
                lsql += " " + item.DistSite + ",";	//工地距离
                lsql += " '" + item.State + "',";	//运输状态
                lsql += " '" + item.Valid + "',";	//有效否
                lsql += " '" + item.InsertDate == null ? "null" : "'" + item.InsertDate.ToString() + "',";	//创建时间
                lsql += " '" + item.InsertId + "',";	//创建人
                lsql += " '" + item.ModiDate == null ? "null" : "'" + item.ModiDate.ToString() + "',";	//修改时间
                lsql += " '" + item.ModiId + "'";	//修改人
                lsql += " )";
                lsql += " SELECT @@ROWCOUNT \n";
                //回写任务单信息,修改派单状态信息为“已派车”
                lsql += " UPDATE [MspBase].[dbo].[SYZG_Task] SET State='1' where Id='" + item.TaskId + "'\n";
                //回写任务单信息,修改已送数量,运送次数
                lsql += " UPDATE Mspbase..SYZG_Task \n";
                lsql += " SET ShipCount=(SELECT COUNT(*) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6'),\n";
                lsql += " DeliveryQty=(SELECT SUM(Qty) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6')\n";
                lsql += " where Id='" + item.TaskId + "'\n";
                lsql += " IF @ERROR=0 COMMIT ELSE \n";
                lsql += " BEGIN\n";
                lsql += " PRINT @ERROR\n";
                lsql += " ROLLBACK TRAN\n";
                lsql += " RAISERROR ('车辆不存在！', -- Message text.\n";
                lsql += "                16, -- Severity.\n";
                lsql += "                1 -- State.\n";
                lsql += "               );\n";
                lsql += " END \n";
                //取出车台长电话
                lsql += "select VehicleMobile from MspBase..InfoVehicle WHERE VehicleMobile<>'' and UserDefine1 = '" + item.Driver1 + "'\n";
                //取出业务员电话
                lsql += "select i.Tel from MspBase..LoginUsers  i\n";
                lsql += "left join MspBase..SYZG_Task t on i.UserId=t.InsertId\n";
                lsql += "left join MspBase..SYZG_Ship s on s.TaskId=t.Id\n";
                lsql += "WHERE s.Id=@ID\n";
                #endregion
                lcnn.Close();
                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);
                string id = lds.Tables[0].Rows[0][0].ToString();
                int rowcount = Convert.ToInt32(lds.Tables[1].Rows[0][0]);
                DataTable tb1=lds.Tables[2];
                DataTable tb2 = lds.Tables[3];
                
                string DriverTel =tb1.Rows[0][0].ToString();
                string BusinessTels = tb2.Rows[0][0].ToString();
                //提交成功后，给工作人员手机发短信  
                sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
                if (BusinessTels.Length > 0)
                {
                    sms.mobile += "," + BusinessTels;
                }
                if (DriverTel.Length > 0)
                {
                    sms.mobile += "," + DriverTel;
                }
                sms.send("派车单" + id + "已派车成功,请注意!");
                if (rowcount > 0)
                {
                    //dics.Add("total", lrows);
                    //dics.Add("rows", ltb_gpsbase);                  
                    result.message = id + "新增成功,新增" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //运输单修改（三一重工）
        private string SYZG_UpdateShip(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string ret = "";

                classSYZG_Ship item = new classSYZG_Ship();
                item.Id = context.Request["Id"];	//运单编号
                item.TaskId = context.Request["TaskId"];	//任务单编号
                item.VehicleNum = context.Request["VehicleNum"];	///车辆编号
                item.Rent = Convert.ToBoolean(context.Request["Rent"]);	//外租否
                item.Driver1 = context.Request["Driver1"];	//驾驶员1
                item.Driver2 = context.Request["Driver2"];	//驾驶员2
                item.Driver3 = context.Request["Driver3"];	//驾驶员3
                item.Qty = Convert.ToDecimal(context.Request["Qty"]);//送货数量
                item.Tower = context.Request["Tower"];	//塔楼编号
                item.DisTime = Convert.ToDateTime(context.Request["DisTime"]);	//派车时间
                item.LeftFacTime = Convert.ToDateTime(context.Request["LeftFacTime"]);//离厂时间
                item.RetFacTime = Convert.ToDateTime(context.Request["RetFacTime"]);//回厂时间	
                item.ArrSiteTime = Convert.ToDateTime(context.Request["ArrSiteTime"]);//到场时间	
                item.LeftSiteTime = Convert.ToDateTime(context.Request["LeftSiteTime"]);//离场时间	 
                item.BeginUnloadTime = Convert.ToDateTime(context.Request["BeginUnloadTime"]);	//开始卸料时间
                item.EndUnloadTime = Convert.ToDateTime(context.Request["EndUnloadTime"]);	//结束卸料时间
                item.DistFactory = Convert.ToDecimal(context.Request["DistFactory"]);	//工厂距离
                item.DistSite = Convert.ToDecimal(context.Request["DistSite"]);	//工地距离
                item.State = context.Request["State"];	//运输状态
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.InsertDate = DateTime.Now.ToLocalTime();	//创建时间
                item.InsertId = context.Request["usr"];	//创建人
                item.ModiDate = DateTime.Now.ToLocalTime();
                item.ModiId = context.Request["usr"];
                //int result = u(item);
                //var lret_c = new { rows = result, data = item, success = true, message = "成功更新" + result + "行" };
                //JsonSerializerSettings set = new JsonSerializerSettings();
                //ret = JsonConvert.SerializeObject(lret_c, Formatting.None, set);

                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 修改SQL
                lsql += " UPDATE MspBase..SYZG_Ship \n";
                lsql += " SET \n";
                lsql += " TaskId='" + item.TaskId + "',";	//任务单编号
                lsql += " VehicleNum='" + item.VehicleNum + "',";	//车辆编号
                lsql += " Rent='" + item.Rent + "',";	//外租否
                lsql += " Driver='" + item.Driver1 + "," + item.Driver2 + ";" + item.Driver3 + "',";	//派遣人员 
                lsql += " Qty='" + item.Qty + "',";	//送货数量
                lsql += " Tower='" + item.Tower + "',";	//塔楼编号
                lsql += " DisTime='" + item.DisTime + "',";	//派车时间
                lsql += " LeftFacTime='" + item.LeftFacTime + "',";	//离厂时间
                lsql += " RetFacTime='" + item.RetFacTime + "',";	//回厂时间
                lsql += " ArrSiteTime='" + item.ArrSiteTime + "',";	//到场时间
                lsql += " LeftSiteTime='" + item.LeftSiteTime + "',";	//离场时间
                lsql += " BeginUnloadTime='" + item.BeginUnloadTime + "',";	//开始卸料时间
                lsql += " EndUnloadTime='" + item.EndUnloadTime + "',";	//结束卸料时间 
                lsql += " DistFactory=" + item.DistFactory + ",";	//工厂距离
                lsql += " DistSite=" + item.DistSite + ",";	//工地距离
                lsql += " State='" + item.State + "',";	//运输状态
                lsql += " Valid='" + item.Valid + "',\n";	//有效否
                //lsql += " InsertDate,\n";	//创建时间
                //lsql += " InsertId,\n";	//创建人
                lsql += " ModiDate = " + (item.ModiDate == null ? "null" : "'" + DateTime.Now.ToLocalTime() + "',\n");	//修改时间
                lsql += " ModiId ='" + item.InsertId + "'\n";	//修改人
                lsql += " WHERE Id = '" + item.Id + "'\n";
                //回写任务单信息,修改已送数量,运送次数
                lsql += "UPDATE Mspbase..SYZG_Task \n";
                lsql += "SET ShipCount=(SELECT COUNT(*) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6'),\n";
                lsql += "DeliveryQty=(SELECT SUM(Qty) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6')\n";
                lsql += "where Id='" + item.TaskId + "'\n";
                #endregion

                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                int rowcount = lcmd.ExecuteNonQuery();
                if (rowcount > 0)
                {
                    //dics.Add("total", lrows);
                    //dics.Add("rows", ltb_gpsbase);                  
                    result.message = "成功修改" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        //运输单报表删除（三一重工）
        private string SYZG_DeleteShip(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";

                classSYZG_Ship item = new classSYZG_Ship();
                item.Id = context.Request["Id"];	//运输单编号
                item.TaskId = context.Request["TaskId"];	//任务单号
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 删除SQL
                lsql += " delete MspBase..SYZG_Ship\n";
                lsql += " WHERE Id = '" + item.Id + "'";
                //回写任务单信息,修改已送数量,运送次数
                lsql += "UPDATE Mspbase..SYZG_Task \n";
                lsql += "SET ShipCount=(SELECT COUNT(*) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6'),\n";
                lsql += "DeliveryQty=(SELECT SUM(Qty) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6')\n";
                lsql += "where Id='" + item.TaskId + "'\n";
                //回写任务单信息,修改派单状态信息为“待派车”
                lsql += " UPDATE Mspbase..SYZG_Task SET State='6' where Id='" + item.TaskId + "'\n";
                #endregion

                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                int rowcount = lcmd.ExecuteNonQuery();

                if (rowcount > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    result.message = "成功删除" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }

        //运输单报表查询（三一重工）
        private string SYZG_Ship(string last_poi_usr, string last_poi_pwd, string last_ship_no, string taskId, string beginTime, string endTime, string page, string rows)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string Id = last_ship_no;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                //if (task_Id == null)
                //{
                //    result.success = false;
                //    result.message = "无任务单号";
                //    return JsonConvert.SerializeObject(result);

                //}
                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回运输单信息
                lsql += "  DECLARE @rows INT   \n";
                lsql += "  DECLARE @page INT    \n";
                lsql += "  DECLARE @where NVARCHAR(100)   \n";
                lsql += "  DECLARE @sort NVARCHAR(100)    \n";
                lsql += "  DECLARE @sql NVARCHAR(2000)    \n";
                lsql += "  SET @rows = " + rows + "  \n";
                lsql += "  SET @page = " + page + "\n";
                lsql += "  SET @sql = ''    \n";
                lsql += "  SET @sql = ''  \n";
                lsql += "CREATE TABLE #T(it INT IDENTITY,Id varchar(10),\n";
                lsql += "TaskId  varchar(10),\n";
                lsql += "VehicleNum varchar(10),\n";
                lsql += "Rent bit,\n";
                lsql += "Driver varchar(24),\n";
                lsql += "Tower varchar(10),\n";
                lsql += "Qty numeric(15,2),\n";
                lsql += "DisTime datetime,\n";
                lsql += "LeftFacTime datetime,\n";
                lsql += "RetFacTime datetime,\n";
                lsql += "ArrSiteTime datetime,\n";
                lsql += "LeftSiteTime datetime,\n";
                lsql += "BeginUnloadTime datetime,\n";
                lsql += "EndUnloadTime datetime,\n";
                lsql += "DistFactory numeric(15,1),\n";
                lsql += "DistSite numeric(15,1),\n";
                lsql += "State varchar(1),\n";
                lsql += "Valid bit,\n";
                lsql += "InsertDate datetime,\n";
                lsql += "InsertId varchar(16),\n";
                lsql += "ModiDate datetime,\n";
                lsql += "ModiId varchar(16),\n";
                lsql += "InnerId varchar(32),\n";
                lsql += "Driver1 varchar(10),\n";
                lsql += "Driver2 varchar(10),\n";
                lsql += "Driver3 varchar(10),\n";
                lsql += "SiteName varchar(32),\n";
                lsql += "VehicleId varchar(32),\n";
                lsql += "VehicleType varchar(20),\n";
                lsql += ")\n";
                lsql += "\n";
                lsql += "  --总数  \n";
                lsql += " Insert into #T\n";
                lsql += " select  a.*,LEFT(a.Driver,charindex(',',a.driver)-1) as Driver1,\n";
                lsql += " substring(a.driver,charindex(',',a.driver)+1,charindex(';',a.driver)-charindex(',',a.driver)-1) as Driver2,\n";
                lsql += " RIGHT(a.driver,len(a.driver)-charindex(';',a.driver)) as Driver3 ,b.SiteName,c.VehicleId,c.VehicleType \n";
                lsql += " FROM MspBase..SYZG_Ship a  \n";
                lsql += " LEFT JOIN MspBase..SYZG_Task b on  a.TaskId=b.Id \n";
                lsql += " Left join MspBase..InfoVehicle c on a.VehicleNum=c.VehicleNum \n";
                lsql += " where  a.Id like '%"+ Id + "%'\n";//运单号
                lsql += " and b.Id like '%" + taskId + "%'\n";//任务单号
                lsql += " and a.InsertDate >= '" + beginTime + "'\n";//开单开始时间
                lsql += " and a.InsertDate <= '" + endTime + "'\n";//开单结束时间
                lsql += " order by a.Id desc\n";
                lsql += "SET @sql= 'SELECT TOP '+CONVERT(VARCHAR(10),@rows)+' * \n";
                lsql += "FROM #T \n";
                lsql += "WHERE  it > ' + CONVERT(VARCHAR(10),@rows*(@page-1))\n";
                lsql += "EXECUTE sp_sqlexec @SQL\n";
                lsql += "SELECT count(*) FROM #T\n";
                lsql += "Drop table #T \n";
                #endregion

                lsbdr.AppendFormat(lsql, page, rows);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);
                ltb_gpsbase = lds.Tables[0];
                ltb_rows = lds.Tables[1];

                if (ltb_gpsbase.Rows.Count > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    string lrows = ltb_rows.Rows[0][0] == null ? "0" : ltb_rows.Rows[0][0].ToString();
                    dics.Add("total", lrows);
                    dics.Add("rows", ltb_gpsbase);
                    result.data = dics;
                    result.message = "查询成功";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        
        //车台长报单新增（三一重工）
        private string SYZG_InsertReport(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                string ret = "";

                classSYZG_Report item = new classSYZG_Report();
                item.Id = context.Request["Id"];	//编号
                item.TaskId = context.Request["TaskId"];	//任务单号
                item.ShipId = context.Request["ShipId"];	//运输单号
                item.ReportTime = Convert.ToDateTime(context.Request["ReportTime"]);	//开单日期
                item.OrderId = context.Request["OrderId"];	//订单号
                item.Quantity = Convert.ToDecimal(context.Request["Quantity"]);	//施工量
                item.Oil = Convert.ToDecimal(context.Request["Oil"]);	//客户点加油量
                item.Memo = context.Request["Memo"];	//备注               
                if (context.Request.Files.Count != 0)
                {
                    item.Attach = new byte[context.Request.Files[0].InputStream.Length];//附件
                    context.Request.Files[0].InputStream.Read(item.Attach, 0, Convert.ToInt32(context.Request.Files[0].InputStream.Length));
                }
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.InsertDate = DateTime.Now.ToLocalTime();	//创建时间
                item.InsertId = context.Request["usr"];	//创建人
                item.ModiDate = Convert.ToDateTime("1970-01-01"); ;
                item.ModiId = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");
                #region 取得运单编号
                lsql += " /*\n";
                lsql += " 计算当月基本资料表的ID号，递增加1，如果没有则从0001开始\n";
                lsql += " 参数\n";
                lsql += " @NO：序号\n";
                lsql += " @DC：单别\n";
                lsql += " @ID：资料编号，单别+YYMM+序号\n";
                lsql += " 使用时修改DC，表名，标识列\n";
                lsql += " */\n";
                lsql += " \n";
                lsql += " DECLARE @NO VARCHAR(10)\n";
                lsql += " DECLARE @DC VARCHAR(2)\n";
                lsql += " DECLARE @ID VARCHAR(10)\n";
                lsql += "\n";
                lsql += " SET @DC = 'SR'\n";
                lsql += " \n";
                //lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+(CONVERT(VARCHAR(4),(RIGHT(MAX(Id),4))+1))),4),'0001'))\n";//流水号升级16进制
                lsql += " SELECT  @NO=(ISNULL(RIGHT(('0000'+RIGHT(CONVERT(VARCHAR(10),CONVERT(VARBINARY ,(CONVERT(VARBINARY ,'0x'+RIGHT(MAX(Id),4),1)) + 1,1),1),4)),4),'0001'))\n";
                lsql += " FROM MspBase..SYZG_Report\n";
                lsql += " WHERE Id LIKE @DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+'%'\n";
                lsql += " \n";
                lsql += " SET @ID=@DC+RIGHT(CONVERT(VARCHAR(6),GETDATE(),112),4)+@NO\n";
                lsql += " \n";
                lsql += " SELECT @ID\n";
                #endregion
                #region 新增SQL
                lsql += " INSERT INTO [MspBase].[dbo].[SYZG_Report]\n";
                lsql += "    ([Id]\n";
                lsql += "    ,[TaskId]\n";
                lsql += "    ,[ShipId]\n";
                lsql += "    ,[ReportTime]\n";
                lsql += "    ,[OrderId]\n";
                lsql += "    ,[Quantity]\n";
                lsql += "    ,[Oil]\n";
                lsql += "    ,[Memo]\n";
                //lsql += "    ,[Attach]\n";
                lsql += "    ,[Valid]\n";
                lsql += "    ,[InsertDate]\n";
                lsql += "    ,[InsertId]\n";
                lsql += "    ,[ModiDate]\n";
                lsql += "    ,[ModiId])\n";
                lsql += " VALUES(";
                lsql += " @ID,";	//编号
                lsql += " '" + item.TaskId + "',";	//任务单号
                lsql += " '" + item.ShipId + "',";	//任务单号
                lsql += " '" + item.ReportTime + "',";	//开单日期
                lsql += " '" + item.OrderId + "',";	//订单号
                lsql += " '" + item.Quantity + "',";	//施工量
                lsql += " '" + item.Oil + "',";	//客户点加油量
                lsql += " '" + item.Memo + "',";	//备注
                //lsql += " '" + item.Attach + "',";	//上传报单附件
                lsql += " '" + item.Valid + "',";	//有效否
                lsql += " '" + item.InsertDate == null ? "null" : "'" + item.InsertDate.ToString() + "',";	//创建时间
                lsql += " '" + item.InsertId + "',";	//创建人
                lsql += " '" + item.ModiDate == null ? "null" : "'" + item.ModiDate.ToString() + "',";	//修改时间
                lsql += " '" + item.ModiId + "'";	//修改人
                lsql += " )";
                lsql += " SELECT @@ROWCOUNT \n";
                lsql += "UPDATE [MspBase].[dbo].[SYZG_Ship] SET State='6' where Id='" + item.ShipId + "'\n";
                //回写任务单信息,修改已送数量,运送次数
                lsql += "UPDATE Mspbase..SYZG_Task \n";
                lsql += "SET ShipCount=(SELECT COUNT(*) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6'),\n";
                lsql += "DeliveryQty=(SELECT SUM(Qty) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6')\n";
                lsql += "where Id='" + item.TaskId + "'\n";
                lsql += "UPDATE MspBase..SYZG_Task SET State='2' where Id='" + item.TaskId + "' \n";
                #endregion
                if (item.Attach != null)
                {
                    //附件上传更新                
                    lsql += " UPDATE MspBase..SYZG_Report\n";
                    lsql += " SET \n";
                    lsql += " Attach =@Attach\n";	//附件
                    lsql += " WHERE Id = @ID\n";
                    SqlParameter para = new SqlParameter("@Attach", SqlDbType.Image);
                    para.Value = item.Attach;
                    SqlParameter[] paras = new SqlParameter[1];
                    paras[0] = para;

                    //取出业务员电话
                    lsql += "select i.Tel from MspBase..LoginUsers  i\n";
                    lsql += "left join MspBase..SYZG_Task t on i.UserId=t.InsertId\n";
                    lsql += "left join MspBase..SYZG_Ship s on s.TaskId=t.Id \n";
                    lsql += "WHERE t.Id='" + item.TaskId + "' and i.UnitId='UN17030003'\n";

                    lsbdr.AppendFormat(lsql);
                    lcmd.CommandText = lsbdr.ToString();
                    lcmd.Connection = lcnn;
                    lcnn.Open();
                    ldap.SelectCommand = lcmd;
                    ldap.SelectCommand.Parameters.Add(para);
                    ldap.Fill(lds);
                }

                DataTable tb1 = lds.Tables[0];
                DataTable tb2 = lds.Tables[1];
                DataTable tb3 = lds.Tables[2];
                string Id = tb1.Rows[0][0].ToString();
                string BusinessTel = tb3.Rows[0][0].ToString();
                //提交成功后，给工作人员手机发短信  
                sms.mobile = ConfigurationManager.AppSettings["SYZG_WorkTel"].ToString();
                sms.mobile += "," + BusinessTel;
                sms.send("派车单" + Id + "已派车成功,请注意!");
                int rowcount = Convert.ToInt32(tb2.Rows[0][0]);
                if (rowcount > 0)
                {
                    //dics.Add("total", lrows);
                    //dics.Add("rows", ltb_gpsbase);                  
                    result.message = Id + "新增成功,新增" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }

        //车台长报单修改（三一重工）
        private string SYZG_UpdateReport(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";

                classSYZG_Report item = new classSYZG_Report();
                item.Id = context.Request["Id"];	//编号
                item.TaskId = context.Request["TaskId"];	//任务单号
                item.ShipId = context.Request["ShipId"];	//运输单号
                item.ReportTime = Convert.ToDateTime(context.Request["ReportTime"]);	//开单日期
                item.OrderId = context.Request["OrderId"];	//订单号
                item.Quantity = Convert.ToDecimal(context.Request["Quantity"]);	//施工量
                item.Oil = Convert.ToDecimal(context.Request["Oil"]);	//客户点加油量
                item.Memo = context.Request["Memo"];	//备注
                //item.Attach = System.Text.Encoding.Default.GetBytes(context.Request["Attach"]);	//上传报单附件
                if (context.Request.Files.Count != 0)
                {
                    item.Attach = new byte[context.Request.Files[0].InputStream.Length];//附件
                    context.Request.Files[0].InputStream.Read(item.Attach, 0, Convert.ToInt32(context.Request.Files[0].InputStream.Length));
                }
                item.Valid = Convert.ToBoolean(context.Request["Valid"]);	//有效否
                item.InsertDate = DateTime.Now.ToLocalTime();	//创建时间
                item.InsertId = context.Request["usr"];	//创建人
                item.ModiDate = DateTime.Now.ToLocalTime();
                item.ModiId = context.Request["usr"];
                //int result = u(item);
                //var lret_c = new { rows = result, data = item, success = true, message = "成功更新" + result + "行" };
                //JsonSerializerSettings set = new JsonSerializerSettings();
                //ret = JsonConvert.SerializeObject(lret_c, Formatting.None, set);

                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 修改SQL
                lsql += " UPDATE MspBase..SYZG_Report \n";
                lsql += " SET \n";
                lsql += "TaskId='" + item.TaskId + "',";	//任务单号
                lsql += "ShipId='" + item.ShipId + "',";	//运输单号
                lsql += "ReportTime='" + item.ReportTime + "',";	//开单日期
                lsql += "OrderId='" + item.OrderId + "',";	//订单号
                lsql += "Quantity='" + item.Quantity + "',";	//施工量
                lsql += "Oil='" + item.Oil + "',";	//客户点加油量
                lsql += "Memo='" + item.Memo + "',";	//备注
                //lsql += "Attach='" + item.Attach + "',";	//上传报单附件
                lsql += " Valid='" + item.Valid + "',\n";	//有效否
                //lsql += " InsertDate,\n";	//创建时间
                //lsql += " InsertId,\n";	//创建人
                lsql += " ModiDate = " + (item.ModiDate == null ? "null" : "'" + DateTime.Now.ToLocalTime() + "',\n");	//修改时间
                lsql += " ModiId ='" + item.InsertId + "'\n";	//修改人
                lsql += " WHERE Id = '" + item.Id + "'\n";
                #endregion                         
                
                if ((context.Request.Files.Count > 0 )&&(item.Attach.Length>8))
                {
                    //附件上传更新
                    lsql += " UPDATE MspBase..SYZG_Report\n";
                    lsql += " SET \n";
                    lsql += " Attach =@Attach\n";	//附件
                    lsql += " WHERE Id = '" + item.Id + "'\n";
                    SqlParameter para = new SqlParameter("@Attach", SqlDbType.Image);
                    para.Value = item.Attach;
                    SqlParameter[] paras = new SqlParameter[1];
                    paras[0] = para;
                    lsbdr.AppendFormat(lsql);
                    lcmd.CommandText = lsbdr.ToString();
                    lcmd.Connection = lcnn;
                    lcnn.Open();
                    ldap.SelectCommand = lcmd;
                    ldap.SelectCommand.Parameters.Add(para);
                }
                else
                {
                    lsbdr.AppendFormat(lsql);
                    lcmd.CommandText = lsbdr.ToString();
                    lcmd.Connection = lcnn;
                    lcnn.Open();
                    ldap.SelectCommand = lcmd;
                }

                ldap.Fill(lds);
                result.message = "修改成功" ;
                result.success = true;
                lret = JsonConvert.SerializeObject(result);
                //int rowcount = lcmd.ExecuteNonQuery();
                //if (rowcount > 0)
                //{
                //    //dics.Add("total", lrows);
                //    //dics.Add("rows", ltb_gpsbase);                  
                //    result.message = "成功修改" + rowcount + "行";
                //    result.success = true;
                //    lret = JsonConvert.SerializeObject(result);
                //}
                //else
                //{
                //    result.success = false;
                //    result.message = "无数据";
                //    lret = JsonConvert.SerializeObject(result);
                //}

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }

        //车台长报单删除（三一重工）
        private string SYZG_DeleteReport(ref HttpContext context, string last_poi_usr, string last_poi_pwd)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;             
                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }

                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";               

                classSYZG_Report item = new classSYZG_Report();
                item.Id = context.Request["Id"];	//编号
                item.TaskId = context.Request["TaskId"];	//任务单号
                item.ShipId = context.Request["ShipId"];	//运输单号

                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 删除SQL
                lsql += " delete MspBase..SYZG_Report WHERE Id = '" + item.Id + "'\n";           
                //回写任务单信息,修改已送数量,运送次数
                lsql += "UPDATE Mspbase..SYZG_Ship SET State='5' WHERE Id = '" + item.ShipId + "'\n";
                lsql += "UPDATE Mspbase..SYZG_Task SET \n";
                lsql += "ShipCount=(SELECT COUNT(*) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6' and  Valid=1),\n";
                lsql += "DeliveryQty=(SELECT SUM(Qty) from Mspbase..SYZG_Ship where TaskId='" + item.TaskId + "' AND State='6' and  Valid=1)\n";
                lsql += "where Id='" + item.TaskId + "'\n";
                lsql += "UPDATE Mspbase..SYZG_Task SET State='1' where Id='" + item.TaskId + "' \n";
                #endregion

                lsbdr.AppendFormat(lsql);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                int rowcount = lcmd.ExecuteNonQuery();

                if (rowcount > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    result.message = "成功删除" + rowcount + "行";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }

        //车台长报单查询（三一重工）
        private string SYZG_Report(ref HttpContext context, string last_poi_usr, string last_poi_pwd, string last_report_taskno, string last_report_client, string last_report_orderno, string last_report_begintime, string last_report_endtime, string page, string rows)
        {
            string lret = "";
            classResult result = new classResult();
            try
            {
                string usr = last_poi_usr;
                string pwd = last_poi_pwd;
                string task_Id = last_report_taskno;//TakId
                string task_client = last_report_client;//Client
                string order_Id = last_report_orderno;//OrderId
                string begintime = last_report_begintime;//ReportTime
                string endtime = last_report_endtime;//ReportTime

                if (usr == null)
                {
                    result.success = false;
                    result.message = "无用户名";
                    return JsonConvert.SerializeObject(result);
                }
                if (pwd == null)
                {
                    result.success = false;
                    result.message = "无密码";
                    return JsonConvert.SerializeObject(result);
                }
                //if (task_Id == null)
                //{
                //    result.success = false;
                //    result.message = "无任务单号";
                //    return JsonConvert.SerializeObject(result);

                //}
                //if (!authority(usr, pwd, task_Id))
                //{
                //    result.success = false;
                //    result.message = "没有此权限";
                //    return JsonConvert.SerializeObject(result);
                //}

                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                string lsql = "";
                string msg = "";
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_gpsbase = new DataTable();
                DataTable ltb_rows = new DataTable();
                StringBuilder lsbdr = new StringBuilder();
                DBHelper.DBHelperClient dbhelper = new DBHelper.DBHelperClient("BasicHttpBinding_IDBHelper");

                #region 返回车台长保单信息
                lsql += "  DECLARE @rows INT   \n";
                lsql += "  DECLARE @page INT    \n";
                lsql += "  DECLARE @where NVARCHAR(100)   \n";
                lsql += "  DECLARE @sort NVARCHAR(100)    \n";
                lsql += "  DECLARE @sql NVARCHAR(2000)    \n";
                lsql += "  SET @rows = " + rows + "  \n";
                lsql += "  SET @page = " + page + "\n";
                lsql += "  SET @sql = ''    \n";
                lsql += "  --总数   \n";
                lsql += " CREATE TABLE #T(it INT IDENTITY,Client varchar(10),Name varchar(32),VehicleId varchar(32),Id varchar(10),TaskId varchar(10),ShipId varchar(10),\n";
                //lsql += " ReportTime datetime,OrderId	varchar(32),Quantity numeric(15,1),Oil	numeric(15,1),Memo varchar(64),Attach image,Valid bit,\n";
                //查询模块,删除附件列
                lsql += " ReportTime varchar(20),OrderId	varchar(32),Quantity numeric(15,1),Oil	numeric(15,1),Memo varchar(64),Valid bit,\n";
                lsql += " InsertDate varchar(20),InsertId varchar(16),ModiDate varchar(20),ModiId	varchar(16))\n";
                lsql += " Insert into #T\n";
                lsql += " select b.Client,c.Name,d.VehicleId,a.Id ,a.TaskId ,a.ShipId, CONVERT(varchar(30),a.ReportTime,20),a.OrderId,a.Quantity,a.Oil,a.Memo ,a.Valid ,\n";
                lsql += "CONVERT(varchar(30),a.InsertDate,20),a.InsertId,CONVERT(varchar(30),a.ModiDate,20),a.ModiId  from MspBase..SYZG_Report a \n";
                lsql += "  left join MspBase..SYZG_Task b on a.TaskId=b.Id\n";
                lsql += " left join MspBase..SYZG_Client c on b.Client=c.Id \n";
                lsql += " left join MspBase..SYZG_Ship f on f.TaskId = b.Id\n";
                lsql += " left join MspBase..InfoVehicle d on d.VehicleNum=f.VehicleNum\n";
                lsql += " where  OrderId like '%" + order_Id + "%'\n";//订单号
                lsql += " and a.TaskId like '%" + task_Id + "%'\n";//任务单号
                lsql += " and Client like '%" + task_client + "%'\n"; //客户编号
                lsql += " and ReportTime >= '"+begintime+"'\n";//开单开始时间
                lsql += " and ReportTime <= '"+endtime+"'\n";//开单结束时间
                lsql += " and a.InsertId= '" + usr + "'\n";//业务代表权限设置
                lsql += " order by a.Id desc \n";
                lsql += "SET @sql= 'SELECT TOP '+CONVERT(VARCHAR(10),@rows)+' * \n";
                lsql += "FROM #T \n";
                lsql += "WHERE  it > ' + CONVERT(VARCHAR(10),@rows*(@page-1))\n";
                lsql += "EXECUTE sp_sqlexec @SQL\n";
                lsql += "SELECT count(*) FROM #T\n";
                lsql += "Drop table #T \n";
                #endregion

                lsbdr.AppendFormat(lsql, page, rows);
                lcmd.CommandText = lsbdr.ToString();
                lcmd.Connection = lcnn;
                lcnn.Open();
                ldap.SelectCommand = lcmd;
                ldap.Fill(lds);
                ltb_gpsbase = lds.Tables[0];
                ltb_rows = lds.Tables[1];

                if (ltb_gpsbase.Rows.Count > 0)
                {
                    Dictionary<String, Object> dics = new Dictionary<String, Object>();
                    string lrows = ltb_rows.Rows[0][0] == null ? "0" : ltb_rows.Rows[0][0].ToString();
                    dics.Add("total", lrows);
                    dics.Add("rows", ltb_gpsbase);
                    result.data = dics;
                    result.message = "查询成功";
                    result.success = true;
                    lret = JsonConvert.SerializeObject(result);
                }
                else
                {
                    result.success = false;
                    result.message = "无数据";
                    lret = JsonConvert.SerializeObject(result);
                }

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = ex.Message;
                lret = JsonConvert.SerializeObject(result);
                DoErr(ex);
                //throw;
            }
            return lret;
        }
        
        //车台长
        private string getSiteInfo(ref HttpContext context)
        {
            string lret = "";
            string key = context.Request["q"]; ;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();                
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_Site = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回客户名称信息
                lcmd.CommandText = "";
                lcmd.CommandText += "select a.Id,a.TaskId,b.SiteName+';'+c.VehicleId+';'+a.Driver as SiteInfo from MspBase..SYZG_Ship a inner join MspBase..SYZG_Task b\n";
                lcmd.CommandText += "on a.TaskId=b.Id inner join MspBase..InfoVehicle c on a.vehicleNum=c.vehicleNum \n";
                lcmd.CommandText += " where (a.Id like '%" + key + "%' or c.FInnerId like '%" + key + "%' or b.SiteName like '%" + key + "%') and b.SiteName<>'' and a.State<>6 order by a.Id\n";
                #endregion
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_Site);
                if (ltb_Site.Rows.Count > 0)
                {
                    lret = JsonConvert.SerializeObject(ltb_Site, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }
        
        //根据报单号获取附件图片
        private string getAttachbyId(ref HttpContext context, string keyWord)
        {
            string lret = "";
            string Id = keyWord;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                byte[] imgbytes=null;
                SqlDataAdapter ldap = new SqlDataAdapter();
                SqlConnection lcnn = new SqlConnection(cnnStr);
                SqlCommand lcmd = new SqlCommand();
                DataSet lds = new DataSet();
                DataTable ltb_Attach = new DataTable();
                lcmd.Connection = lcnn;
                lcnn.Open();
                #region 返回客户名称信息
                lcmd.CommandText = "";
                lcmd.CommandText += "SELECT Attach\n";
                lcmd.CommandText += "FROM MspBase..SYZG_Report\n";
                lcmd.CommandText += "WHERE Id='" + Id + "'\n";
                #endregion
                ldap.SelectCommand = lcmd;
                ldap.Fill(ltb_Attach);
                lcmd.Connection = lcnn;
                SqlDataReader dr = lcmd.ExecuteReader();
                while (dr.Read())
                {

                    imgbytes = (byte[])dr.GetValue(0);

                }
                //Byte[] imgbyte = File.ReadAllBytes(dt.Rows[0][0].ToString());
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(imgbytes);
                //context.Response.OutputStream.Write(imgbytes, 0, imgbytes.Length);      
                context.Response.End();              
            }
            catch (Exception)
            {
                //throw;
            }

            return lret;
        }

        //日志处理
        public void log(string sMsg)
        {
            try
            {
                FileInfo fi = new FileInfo(logFileLog);
                if (fi.Exists)
                {
                    if (fi.Length > 1024 * 1024 * 50)
                    {
                        fi.Delete();
                    }
                }
                if (!fi.Exists)
                {
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine(DateTime.Now + ":" + sMsg + "");
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = fi.AppendText())
                    {
                        sw.WriteLine(DateTime.Now + ":" + sMsg + "");
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }

        }

        //加密
        public string md5(string t)
        {
            StringBuilder buf;
            try
            {
                HashAlgorithm m = SHA1CryptoServiceProvider.Create();
                //HashAlgorithm ha = SHA1CryptoServiceProvider.Create();
                byte[] c = m.ComputeHash(Encoding.UTF8.GetBytes(t));
                buf = new StringBuilder();
                foreach (byte b in c)
                {
                    buf.Append(b.ToString("X2"));

                }
            }
            catch (Exception)
            {
                throw;
            }

            return buf.ToString();
        }
        public class classResult
        {
            public bool success;
            public string message;
            public object data;
          
        }
    }
}