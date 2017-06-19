using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Util.EasyuiPager
{
    public static class ListExtension
    {
        public static EasyuiPager<T> ToEasyuiPageList<T>(this IList<T> items, int total)
        {
            return new EasyuiPager<T>(items, total);
        }
    }
}
