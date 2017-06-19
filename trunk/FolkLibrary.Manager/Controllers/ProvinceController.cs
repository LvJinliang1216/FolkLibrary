using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.Util.BaseController;

namespace FolkLibrary.Manager.Controllers
{
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProvince()
        {
            var dataList = _provinceService.GetAll();
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

    }
}
