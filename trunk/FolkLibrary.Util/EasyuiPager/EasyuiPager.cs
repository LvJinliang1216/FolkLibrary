using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Util.EasyuiPager
{
    public class EasyuiPager<T>
    {
        public int total { get; set; }
        public IList<T> rows { get; set; }

        public EasyuiPager(IList<T> items,int count )
        {
            rows = items;
            total = count;
        }
    }
}
