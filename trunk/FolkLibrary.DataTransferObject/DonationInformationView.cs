using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class DonationInformationView
    {
        /// <summary>
        /// 捐赠信息Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 捐赠人
        /// </summary>
        public string DonationUserName { get; set; }

        /// <summary>
        /// 捐赠金额
        /// </summary>
        public decimal DonationAmount { get; set; }

        /// <summary>
        /// 捐赠说明
        /// </summary>
        public string DonationInstruction { get; set; }

        /// <summary>
        /// 资助时间
        /// </summary>
        public string DonationDatetime { get; set; }

        /// <summary>
        /// 资助明细
        /// </summary>
        public string DonationDetail { get; set; }

        /// <summary>
        /// 资助项目
        /// </summary>
        public List<ProjectView> ProjectViews { get; set; }
    }
}
