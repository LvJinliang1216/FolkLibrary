using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IDonationInformationServer
    {

        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="donationInfoId"></param>
        /// <returns></returns>
        DonationInformationView Get(int donationInfoId);

        /// <summary>
        /// 获取排名靠前的捐赠信息
        /// </summary>
        /// <param name="topAmount"></param>
        /// <returns></returns>
        IList<DonationInformationView> GetHot(int topAmount);

        /// <summary>
        /// 捐赠信息列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        IList<DonationInformationView> Search(DonationInformationView query, int pageIndex, int pageSize, out int total);
    }
}
