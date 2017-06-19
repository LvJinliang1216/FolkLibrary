using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IWebSitInfoService
    {
        List<WebSiteInfoView> GetAll(int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 获取网站信息
        /// </summary>
        /// <param name="webSiteInfoId"></param>
        /// <returns></returns>
        WebSiteInfoView Get(int webSiteInfoId);

        /// <summary>
        /// 添加网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        Task<bool> CreateWebSiteInfo(WebSiteInfoView webSiteInfoView);

        /// <summary>
        /// 删除网站信息
        /// </summary>
        /// <param name="webSiteInfoId"></param>
        /// <returns></returns>
        Task<bool> DeleteWebSiteInfo(int webSiteInfoId);

        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        Task<bool> ModifyWebSiteInfo(WebSiteInfoView webSiteInfoView);
    }
}
