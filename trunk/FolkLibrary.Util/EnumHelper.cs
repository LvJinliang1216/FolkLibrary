using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Util
{
    public class EnumHelper
    {
        /// <summary>  
        /// 枚举转字典集合[Key:枚举的字段值；Value：枚举的值]
        /// </summary>  
        /// <typeparam name="T">枚举类名称</typeparam>  
        /// <param name="keyDefault">默认key值</param>  
        /// <param name="valueDefault">默认value值</param>  
        /// <returns>返回生成的字典集合</returns>  
        public static Dictionary<string, string> EnumToDictionary<T>(string keyDefault, string valueDefault = "")
        {
            Dictionary<string, string> dicEnum = new Dictionary<string, string>();
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                return dicEnum;
            }
            if (!string.IsNullOrEmpty(keyDefault)) //判断是否添加默认选项  
            {
                dicEnum.Add(keyDefault, valueDefault);
            }
            string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组  
            foreach (var item in fieldstrs)
            {
                dicEnum.Add(item, Enum.Parse(enumType, item).ToString());
                //不用枚举的value值作为字典key值的原因从枚举例子能看出来，其实这边应该判断他的值不存在，默认取字段名称  
            }
            return dicEnum;
        }

        /// <summary>  
        /// 枚举转字典集合[Key:枚举的描述DescriptionAttribute；Value：枚举的值]
        /// </summary>  
        /// <typeparam name="T">枚举类名称</typeparam>  
        /// <param name="keyDefault">默认key值</param>  
        /// <param name="valueDefault">默认value值</param>  
        /// <returns>返回生成的字典集合</returns>  
        public static Dictionary<string, string> EnumToDictionaryTwo<T>(string keyDefault, string valueDefault = "")
        {
            Dictionary<string, string> dicEnum = new Dictionary<string, string>();
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                return dicEnum;
            }
            if (!string.IsNullOrEmpty(keyDefault)) //判断是否添加默认选项  
            {
                dicEnum.Add(keyDefault, valueDefault);
            }
            string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组  
            foreach (var item in fieldstrs)
            {
                var field = enumType.GetField(item);
                object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组  
                var description = arr.Length > 0 ? ((DescriptionAttribute)arr[0]).Description : item;
                dicEnum.Add(description, Enum.Parse(enumType, item).ToString());
                //不用枚举的value值作为字典key值的原因从枚举例子能看出来，其实这边应该判断他的值不存在，默认取字段名称  
            }
            return dicEnum;
        }
    }
}
