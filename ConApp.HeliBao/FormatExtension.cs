using System;
using System.Collections.Generic;
using System.Text;

namespace ConApp.HeliBao
{
    public sealed class FormatExtension
    {
        public static Dictionary<string, string> ToDictionary<T>(T c, bool isIgnoreNull = false) where T : class
        {
            var map = new Dictionary<string, string>();
            var t = typeof(T);
            var pi = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var item in pi)
            {
                var m = item.GetGetMethod();
                if (m != null && m.IsPublic)
                {
                    if (m.Invoke(c, new object[] { }) != null || !isIgnoreNull)
                    {
                        map.Add(item.Name, m.Invoke(c, new object[] { }) + ""); // 向字典添加元素
                    }
                }
            }
            return map;   
        }

    }
}
