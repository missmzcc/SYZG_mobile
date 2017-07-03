using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace _01
{
    public partial class last_poi : System.Web.UI.Page
    {
        public string lng = "";
        public string lat = "";
        public string car_no = "";
        public string lasttime = "";
        public string logFileLog = "";
        public string msg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usr = Request["usr"];
                string pwd = Request["pwd"];
                car_no = Request["car"];
                if (usr == null) return;
                if (pwd == null) return;
                if (car_no == null) return;
                if (!authority(usr,pwd,car_no))
                {
                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('用户名、密码或车牌不正确，请检查');");
                    Response.Write("</script>");
                    Response.End();
                }
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
                logFileLog = Request.PhysicalApplicationPath + "request.log";
                string lsql = "";
                string lret = "";
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
                lsql += "   declare @dbbase varchar(100)   ";
                lsql += "   declare @dbgps varchar(100)   ";
                lsql += "   declare @ParaDef varchar(1000)   ";
                lsql += "   declare @sql Nvarchar(1000)   ";
                lsql += "   declare @vehicleIdVar varchar(100)   ";
                lsql += "      ";
                lsql += "   set @dbbase = N'MinistryStandardPlatform'   ";
                lsql += "   set @dbgps = N'MinistryStandardPlatformGPS' + CONVERT(varchar(6),getdate(),112)   ";
                lsql += "      ";
                lsql += "   set @sql = N'   ";
                lsql += "   declare @vehicleNum varchar(40)   ";
                lsql += "   declare @simId varchar(40)   ";
                lsql += "   declare @lRetSetUp bit   ";
                lsql += "   declare @lSetupDate Datetime   ";
                lsql += "   declare @lWorkOK bit   ";
                lsql += "   declare @vehicleId varchar(100)   ";
                lsql += "   set @vehicleId = ''{0}''   ";
                lsql += "   select @vehicleNum = Vehiclenum,   ";
                lsql += "      @simId = SIM   ";
                lsql += "      from ' + @dbbase + '..InfoVehicle    ";
                lsql += "      where vehicleId = @vehicleId   ";
                lsql += "      ";
                lsql += "   select * from ' + @dbbase + '..InfoVehicle where vehicleId = @vehicleId   ";
                lsql += "   select * from ' + @dbgps + '..GpsBasic   ";
                lsql += "   where id in   ";
                lsql += "   (   ";
                lsql += "   select MAX(id) from ' + @dbgps + '..GpsBasic where vehicleNum=@vehicleNum   ";
                lsql += "   )   ";
                lsql += "      ";
                lsql += "   select * from ' + @dbgps + '..GpsWarn   ";
                lsql += "   where simId = @simId and warnstarttime =    ";
                lsql += "   (   ";
                lsql += "   select MAX(warnstarttime) from ' + @dbgps + '..GpsWarn   ";
                lsql += "   where simId = @simId   ";
                lsql += "   )";
                //lsql += "   select * from ' + @dbbase + '..TranTaskList where 1 = 0   ";
                lsql += "'   ";
                lsql += "      ";
                lsql += "   print @sql   ";
                lsql += "       ";
                lsql += "   EXECUTE sp_executesql @sql   ";
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
                    lret = "1," + ((DateTime)ltb_vehicle.Rows[0]["InstallDate"]).ToString("yyyyMMdd");
                    if (ltb_gpsbase.Rows.Count > 0)
                    {
                        //返回百度地址
                        string longitudeoffset = ltb_gpsbase.Rows[0]["longitudeoffset"].ToString();
                        string latitudeoffset = ltb_gpsbase.Rows[0]["latitudeoffset"].ToString();
                        lng = longitudeoffset;
                        lat = latitudeoffset;
                        string pos_addr = dbhelper.GgpsTranslate2BaiduPoi(longitudeoffset, latitudeoffset);
                        DateTime lgpsbasetime = DateTime.Parse(ltb_gpsbase.Rows[0]["recordtime"].ToString());
                        lasttime = lgpsbasetime.ToString("MM-dd HH:mm");
                        if (lgpsbasetime.AddMinutes(30) < DateTime.Now)
                            lret = lret + ",0,[" + pos_addr + "]";
                        else
                            lret = lret + ",1,[" + pos_addr + "]";
                    }
                    else
                    {
                        lret = lret + ",0";
                    }

                    string[] split = lret.Split(',');
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
                }
                else
                {
                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('没有安装GPS或异常，请检查');");
                    Response.Write("window.history.back(-1);");
                    Response.Write("</script>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Message:" + ex.Message + "');");
                Response.Write("window.history.back(-1);");
                Response.Write("</script>");
                Response.End();
                DoErr(ex);
                //throw;
            }
            
        }

        //权限检查
        public bool authority(string usr, string pwd, string car)
        {
            bool lret = false;
            try
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["MinistryStandardSqlBsCon"].ToString();
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
                lsql += "SET @PWD = '" + md5(pwd) + "'\n";
                lsql += "SET @CAR = '" + car + "'\n";
                lsql += "\n";
                lsql += "SELECT @UNIT = CustomerID FROM MinistryStandardPlatform..LoginUsers\n";
                lsql += "WHERE UserId = @USR\n";
                lsql += "  AND LoginPassword = @PWD  \n";
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
                lsql += "SELECT * FROM MinistryStandardPlatform..InfoUnit \n";
                lsql += " WHERE PARTENTUNITID IN\n";
                lsql += " (SELECT UNITID FROM #T WHERE nLEVEL = @nLEVEL)\n";
                lsql += " )\n";
                lsql += " BEGIN\n";
                lsql += "INSERT INTO #T \n";
                lsql += "SELECT UNITID,@nLEVEL + 1\n";
                lsql += "  FROM MinistryStandardPlatform..InfoUnit \n";
                lsql += " WHERE PARTENTUNITID IN\n";
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
                lsql += "SELECT Vehiclenum FROM MinistryStandardPlatform..InfoVehicle\n";
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
    }
}