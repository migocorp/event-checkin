using System;
using System.Drawing;
using System.Text; 
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Com.Migocorp.BJRD.Event.CheckIn.Util
{
    public class KitStr
    {
        public static string GetCorrectedContent(object obj)
        {
            string str = "";
            if (obj != null)
            {
                str = obj.ToString().Trim().Replace("\r", " ").Replace("\n", " ").Replace('　', ' ').Replace("  ", " ");
            }
            return str;
        }

        public static int parseInt(string strInt, int failValue)
        {
            int succValue = failValue;
            return (Int32.TryParse(strInt, out succValue)) ? succValue : failValue;
        }


        public static DateTime parseDate(string strDate, string format, DateTime failValue)
        {
            DateTime succValue = failValue;
            if (
                !DateTime.TryParseExact(strDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
                                        out succValue))
            {
                succValue = failValue;
            }
            return succValue;
        }

        public static decimal parseDecimal(string strInt, decimal failValue)
        {
            decimal succValue = failValue;
            return (Decimal.TryParse(strInt, out succValue)) ? succValue : failValue;
        }

        /// <summary>
        /// 检验Email是否正确
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool isValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
        }

        /// <summary>
        /// 密码6~12位, 至少包含一个英文字母，一个数字，一个特殊符号
        /// </summary>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static bool isValidPassword(string strPassword)
        {
            return Regex.IsMatch(strPassword,
                                 @"^(?=.*[\x21-\x2F\x3A-\x40\x5B-\x60\x7B-\x7E])(?=.*[0-9])(?=.*[a-zA-Z]).{6,}$");


        }

        public static string randomString(int length)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString().Replace("-", "");
            str = str.Substring(3, length);
            return str;
        }


        /// <summary>
        /// 判断字符串能否转换成正整数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool isValidNumber(string num)
        {
            num = num.Trim().TrimStart('0');
            return Regex.IsMatch(num, @"^[1-9]*$");
        }

        /// <summary>
        /// 判断字符串能否转换成日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetValidDateTime(int year, string month, string date)
        {

            string strYYYY = year.ToString();
            string strMM = month.Length == 1 ? "0" + month : month;
            string strDD = date.Length == 1 ? "0" + date : date;

            string strDate = strYYYY + "-" + strMM + "-" + strDD;

            DateTime result = DateTime.MinValue;
            try
            {
                result = DateTime.ParseExact(strDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                result = DateTime.MinValue;
            }
            return result;
            /*
            DateTime value=new DateTime();
            try
            {
                value = DateTime.Parse(date);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            */
        }

        /// <summary>  
        /// 取得某月的第一天  
        /// </summary>  
        /// <param name="datetime">要取得月份第一天的时间</param>  
        /// <returns></returns>  
        public static string FirstDayOfMonth(object datetime)
        {
            DateTime dt = Convert.ToDateTime(datetime);
            return dt.AddDays(1 - dt.Day).ToString("yyyy-MM-dd");
        }


        /// <summary>  
        /// 取得某月的最后一天  
        /// </summary>  
        /// <param name="datetime">要取得月份最后一天的时间</param>  
        /// <returns></returns>  
        public static string LastDayOfMonth(object datetime)
        {
            DateTime dt = Convert.ToDateTime(datetime);
            return dt.AddDays(1 - dt.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime">起算日起</param>
        /// <param name="preQuarter">从起算日起算起的第几季度</param>
        /// <returns></returns>
        public static string StrGetQuarterOfYear(object datetime,int preQuarter,out int year)
        {
            DateTime dt = Convert.ToDateTime(datetime);
            dt = dt.AddMonths(-(3*(preQuarter-1))).Date;

            DateTime preStart = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day).Date; //季度初
            year = preStart.Year;
            int month = preStart.Month;
            string quarter = "";

            if (month == 1)
            {
                quarter = "first";
            }
            else if (month == 4)
            {
                quarter = "second";
            }
            else if (month == 7)
            {
                quarter = "third";
            }
            else if (month == 10)
            {
                quarter = "fourth";
            }

            return quarter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime">起算日起</param>
        /// <param name="preQuarter">从起算日起算起的第几季度</param>
        /// <returns></returns>
        public static int IntGetQuarterOfYear(object datetime, int preQuarter, out int year)
        {
            DateTime dt = Convert.ToDateTime(datetime);
            dt = dt.AddMonths(-(3 * (preQuarter-1))).Date;

            DateTime preStart = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day).Date; //季度初
            year = preStart.Year;
            int month = preStart.Month;
            int quarter = 0;

            if (month == 1)
            {
                quarter = 1;
            }
            else if (month == 4)
            {
                quarter = 2;
            }
            else if (month == 7)
            {
                quarter = 3;
            }
            else if (month == 10)
            {
                quarter = 4;
            }

            return quarter;
        }

        public static string Substring(string str, int iStart, int iLength)
        {
            if (str == null) return null;
            int iLen = iLength;
            if ((iStart + iLength) > str.Length) {
                iLen = str.Length - iStart;
            }
            string strOut = str.Substring(iStart, iLen);
            return strOut;
        }

        public static string substringLeft(string str, int size, string trimSign)
        {
            if (str.Length < size)
            {
                return str;
            }
            return str.Substring(0, size) + trimSign;
        }

        public static string formatInt(int i, string format)
        {
            return i.ToString(format);
        }

        public static string formatInt(int i)
        {
            return formatInt(i, "#,##0");
        }

        public static string formatDate(DateTime date)
        {
            return formatDate(date, "yyyy-MM-dd");
        }

        public static string formatDate(DateTime date, string format)
        {
            
            if (date == DateTime.MinValue) return "";
            return date.ToString(format, CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static string GetEnumDescription(object obj)
        {
            return GetEnumDescription(obj, false);
        }

        public static string GetEnumDescription(object obj, bool isTop)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            try
            {
                Type _enumType = obj.GetType();
                DescriptionAttribute dna = null;
                if (isTop)
                {
                    dna = (DescriptionAttribute) Attribute.GetCustomAttribute(_enumType, typeof (DescriptionAttribute));
                }
                else
                {
                    FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                    dna = (DescriptionAttribute) Attribute.GetCustomAttribute(
                        fi, typeof (DescriptionAttribute));
                }
                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                    return dna.Description;
            }
            catch
            {
            }
            return obj.ToString();
        }

        public static string GetIntOrdinal(int num)
        {
            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num.ToString() + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num.ToString() + "st";
                case 2:
                    return num.ToString() + "nd";
                case 3:
                    return num.ToString() + "rd";
                default:
                    return num.ToString() + "th";
            }

        }
        public static string EscapeJsonStr(string str)
        {
            str = str.Replace("'", "’");
            return str.Replace("\"", "\\\"");
        }
        /// <summary>
        /// 获得一个随机的颜色值
        /// </summary>
        /// <returns></returns>
        public static string GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  C#的随机数
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);


            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = RandomNum_Sencond.Next(256);
            //  为了在白色背景上显示，尽量生成深色 
            //int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            //int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            Color c=Color.FromArgb(int_Red, int_Green, int_Blue);

            return "#"+Convert.ToString(c.R, 16) + Convert.ToString(c.G, 16) + Convert.ToString(c.B, 16);
        }
    }
}


