using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject.QueryModels
{
   public  class LeaveWordQueryView
    {
       /// <summary>
       /// 开始时间
       /// </summary>
        public DateTime? StarTime { get; set; }
       /// <summary>
       /// 结束时间
       /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
