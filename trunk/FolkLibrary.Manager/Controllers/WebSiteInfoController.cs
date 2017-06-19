using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util.BaseController;
using FolkLibrary.Util.EasyuiPager;

namespace FolkLibrary.Manager.Controllers
{
    public class WebSiteInfoController : BaseController
    {
        private readonly IWebSitInfoService _webSitInfoService;
        public WebSiteInfoController(IWebSitInfoService webSitInfoService)
        {
            _webSitInfoService = webSitInfoService;
        }

        public ActionResult WebSitInfoIndex()
        {
            return View();
        }

        /// <summary>
        /// 获取网站信息
        /// </summary>
        /// <returns></returns>
        public JsonResult Search()
        {
            int pageIndex = 1;
            int pageSize = 10;
            int total = 0;
            var dataList = _webSitInfoService.GetAll(pageIndex, pageSize, out total).ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyWebSitInfo(WebSiteInfoView webSiteInfoView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            if (webSiteInfoView.WebSiteInfoId == 0)
            {

                bool flag = await _webSitInfoService.CreateWebSiteInfo(webSiteInfoView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "添加信息成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "添加信息失败");
                }
            }
            else
            {
                bool flag = await _webSitInfoService.ModifyWebSiteInfo(webSiteInfoView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "修改信息成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "修改信息失败");
                }
            }
            return Json(dicMsg, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 获取网站信息
        /// </summary>
        /// <param name="webSiteInfoId"></param>
        /// <returns></returns>
        public JsonResult GetWebSiteInfo(int webSiteInfoId)
        {
            var data = _webSitInfoService.Get(webSiteInfoId);
            return Json(data);
        }

        /// <summary>
        /// 删除网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteWebSiteInfo(WebSiteInfoView webSiteInfoView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            var flag = await _webSitInfoService.DeleteWebSiteInfo(webSiteInfoView.WebSiteInfoId);
            if (flag)
            {
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "删除信息成功");
            }
            else
            {
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "删除信息失败");
            }
            return Json(dicMsg, JsonRequestBehavior.DenyGet);
        }
    }
}
