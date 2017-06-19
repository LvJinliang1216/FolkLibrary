using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace FolkLibrary.Util
{
    public static class StringHelper
    {
        public static string Md5Encode(this string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            foreach (byte t in targetData)
            {
                byte2String += t.ToString("x");
            }

            return byte2String;
        }

        /// <summary>
        /// 转换成Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return ToJson(obj, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="jsonConverters"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, IEnumerable<JavaScriptConverter> jsonConverters)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (jsonConverters != null) serializer.RegisterConverters(jsonConverters ?? new JavaScriptConverter[0]);
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// 将字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object value) { return value.ConvertTo(default(T)); }

        public static T ConvertTo<T>(this object value, T defaultValue)
        {
            if (value != null)
            {
                var targetType = typeof(T);

                var converter = TypeDescriptor.GetConverter(value);
                if (converter.CanConvertTo(targetType)) return (T)converter.ConvertTo(value, targetType);

                converter = TypeDescriptor.GetConverter(targetType);
                try { if (converter.CanConvertFrom(value.GetType())) return (T)converter.ConvertFrom(value); }
                catch
                {
                    // ignored
                }
            }
            return defaultValue;
        }
        public static T ConvertTo<T>(this object value, T defaultValue, bool ignoreException)
        {
            if (ignoreException)
            {
                try
                {
                    return value.ConvertTo<T>();
                }
                catch
                {
                    return defaultValue;
                }
            }
            return value.ConvertTo<T>();
        }

        // <summary>
        /// 将html文本转化为 文本内容方法NoHTML
        /// <summary/>
        /// <param name="htmlString">HTML文本值</param>
        /// <returns></returns>
        public static string RemoveHtml(this string htmlString)
        {
            //删除脚本   
            htmlString = Regex.Replace(htmlString, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            htmlString = Regex.Replace(htmlString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"-->", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(quot|#34);", "/", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);
            htmlString = Regex.Replace(htmlString, @"&#(/d+);", "", RegexOptions.IgnoreCase);
            //替换掉 < 和 > 标记
            htmlString = htmlString.Replace("<", "");
            htmlString = htmlString.Replace(">", "");
            htmlString = htmlString.Replace("/r/n", "");
            //返回去掉html标记的字符串
            return htmlString;
        }

        /// <summary>
        /// 解码html字符串
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static string DecodeHtml(this string htmlString)
        {
            htmlString = htmlString.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&#39;", "'");
            htmlString = HttpContext.Current.Server.UrlDecode(htmlString);
            return htmlString;
        }
    }
}
