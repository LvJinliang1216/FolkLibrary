using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util.MvcPager;

namespace FolkLibrary.Web.Controllers
{
    public class DonationInformationController : Controller
    {
        private readonly IDonationInformationServer _donationInformationServer;
        public DonationInformationController(IDonationInformationServer donationInformationServer)
        {
            this._donationInformationServer = donationInformationServer;
        }

        /// <summary>
        /// 捐赠信息列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult DonationInformationList(DonationInformationView query, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;
            int total = 0;
            var dataList = _donationInformationServer.Search(query, pageIndex.Value, pageSize.Value, out total).ToPagedList(pageIndex.Value, pageSize.Value, total);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_DonationInfoList", dataList);
            }
            else
            {
                var hotData = _donationInformationServer.GetHot(8);

                Dictionary<string, object> dicData = new Dictionary<string, object>();
                dicData.Add("DonationInfoList", dataList);
                dicData.Add("HotData", hotData);
                return View(dicData);
            }

        }

        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="donationInfoId"></param>
        /// <returns></returns>
        public ActionResult DonationInfoDetail(int? donationInfoId)
        {
            if (donationInfoId.HasValue)
            {
                var modelData = _donationInformationServer.Get(donationInfoId.Value);
                return View(modelData);
            }
            else
            {
                return View(new DonationInformationView());
            }
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
