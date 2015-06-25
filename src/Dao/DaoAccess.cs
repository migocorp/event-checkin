using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Com.Migocorp.BJRD.Event.CheckIn.Util;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Com.Migocorp.BJRD.Event.CheckIn.Dao
{
    public class DaoAccess
    {

        private Common.Logging.ILog log;

        public DaoAccess()
        {
            log = Common.Logging.LogManager.GetLogger(this.GetType());
        }

        public enum FILTER_TYPE
        {
            FILTER_CHECKED_IN,
            FILTER_NOT_CHECKED_IN,
            FILTER_ALL
        };

        public enum LOG_TYPE
        {
            CHECK_IN = 0,
            RETURN_SURVEY = 1
        };

        private string getSqlConnStr()
        {
            return KitConfig.GetKeyStr(KitConst.CONFIG_DB_CONN_STR, "");
        }

        public bool MakeActionLog(LOG_TYPE typeLog, string guestId)
        {
            string sql = "INSERT INTO [t_log] (logtime, guest_id, log_type) VALUES (getdate(), @guestId, @typeLog);";

            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("guestId", SqlDbType.NVarChar);
            parms[0].Value = guestId;
            parms[1] = new SqlParameter("typeLog", SqlDbType.SmallInt);
            parms[1].Value = (int)typeLog;

            int iInserted = SqlHelper.ExecuteNonQuery(getSqlConnStr(), CommandType.Text, sql, parms);

            if (iInserted == 1)
                return true;
            else
                return false;
        }



        public DataTable GetGuests(FILTER_TYPE typeFilter, String searchWord)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT t.*, c.time_checkin ");
            sbSql.Append("FROM t_guest t ");
            sbSql.Append("LEFT OUTER JOIN ");
            sbSql.Append("( ");
            sbSql.Append("  SELECT ");
            sbSql.Append("    MIN(logtime) AS time_checkin, ");
            sbSql.Append("    guest_id ");
            sbSql.Append("  FROM t_log ");
            sbSql.Append("  WHERE log_type = @logType ");
            sbSql.Append("  GROUP BY guest_id ");
            sbSql.Append(") c ON c.guest_id = t.guest_id ");
            sbSql.Append("WHERE  ");

            if (typeFilter == FILTER_TYPE.FILTER_ALL)
                sbSql.Append(" 0=0 AND ( ");
            else if (typeFilter == FILTER_TYPE.FILTER_NOT_CHECKED_IN)
                sbSql.Append("  c.time_checkin IS NULL AND ( ");
            else
                sbSql.Append("  c.time_checkin IS NOT NULL AND ( ");

            if (searchWord != null && searchWord.Length > 0)
            {
                sbSql.Append("  t.guest_id LIKE @searchWord OR ");
                sbSql.Append("  t.name LIKE @searchWord OR ");
                sbSql.Append("  t.company LIKE @searchWord OR ");
                sbSql.Append("  t.email LIKE @searchWord OR ");
                sbSql.Append("  t.department LIKE @searchWord OR ");
                sbSql.Append("  t.phone LIKE @searchWord OR ");
                sbSql.Append("  t.weibo LIKE @searchWord); ");
            }
            else
            {
                sbSql.Append(" 1=1 ); ");
            
            }

            SqlParameter[] parms = new SqlParameter[2];
            
            parms[0] = new SqlParameter("logType", SqlDbType.SmallInt);
            parms[0].Value = (int)LOG_TYPE.CHECK_IN;
            parms[1] = new SqlParameter("searchWord", SqlDbType.NVarChar);
            parms[1].Value = "%" + searchWord + "%";

            DataTable result = SqlHelper.ExecuteDataTable(getSqlConnStr(), CommandType.Text, sbSql.ToString(), parms);

            return result;
            //return null;
        }




        public FileInfo DoExportLogExcel()
        {

            //string saveFilename = String.Format("black_{0}_{1}_{2}{3}", "exp",
            //   KitStr.formatDate(DateTime.Now, "yyyyMMddHHmmss"),
            //   KitStr.randomString(3), ".xlsx");
            //string strFilePath = KitConfig.GetPathSaveContactList() + saveFilename;
            //FileInfo fileExcel = new FileInfo(strFilePath);
            

            string filename = String.Format("exp_log_{0}.xlsx",
                KitStr.formatDate(DateTime.Now, "yyyyMMddHHmmss")
                );

            string path = KitConfig.GetKeyStr(KitConst.CONFIG_EXPORT_DIR, "C:\\") + filename;

            FileInfo outFile = new FileInfo(path);

            if (outFile.Directory != null && !outFile.Directory.Exists)
            {
                log.Info("output log report dir not exist, create: " + outFile.Directory.FullName);
                outFile.Directory.Create();
            }

            if (outFile.Exists)
            {
                log.Info("export filename exists, delete existing file: " + outFile.FullName);
                outFile.Delete(); // ensures we create a new workbook
            }

            string sql = "SELECT guest_id, log_type, MIN(logtime) AS logtime FROM t_log GROUP BY guest_id, log_type";


            DataTable dtLogs = SqlHelper.ExecuteDataTable(getSqlConnStr(), CommandType.Text, sql);

            using (ExcelPackage package = new ExcelPackage(outFile))
            {

                // add a new worksheet to the empty workbook
                ExcelWorksheet excel = package.Workbook.Worksheets.Add("data_logs");

                #region [Excel Style]

                int maxRowNum = dtLogs.Rows.Count + 1;
                excel.Column(1).Width = 20;
                excel.Column(2).Width = 15;
                excel.Column(3).Width = 30;
                excel.Cells["A1:C1"].Style.Font.Bold = true;
                excel.Cells["A1:C1"].Style.Font.Size = 12;
                excel.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                excel.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                excel.Cells["A1:C1"].Style.Font.Color.SetColor(Color.Black);

                #endregion

                excel.Cells[1, 1].Value = "guest_id";
                excel.Cells[1, 2].Value = "type_log";
                excel.Cells[1, 3].Value = "time_log";

                int i = 2;
                foreach (DataRow r in dtLogs.Rows)
                {
                    string strGuestId = r["guest_id"].ToString();

                    int iType = Convert.ToInt32(r["log_type"]);
                    DateTime dtTime = Convert.ToDateTime(r["logtime"]);
                    string strType = iType == (int)LOG_TYPE.CHECK_IN ? "CHECK_IN" : iType == (int)LOG_TYPE.RETURN_SURVEY ? "SURVEY_LEAVE" : "UNKNOWN";
                    string strTime = KitStr.formatDate(dtTime, "yyyy-MM-dd HH:mm:ss");


                    excel.Cells[i, 1].Value = strGuestId;
                    excel.Cells[i, 2].Value = strType;
                    excel.Cells[i, 3].Value = strTime;
                    i++;
                }
                package.Save();
            }

            return outFile;

        }
    }
}
