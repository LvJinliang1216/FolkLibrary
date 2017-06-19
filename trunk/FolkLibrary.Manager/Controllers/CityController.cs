using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.Util.BaseController;

namespace FolkLibrary.Manager.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCity(int provinceId)
        {
            var dataList = _cityService.GetAll().Where(x => x.ProvinceId == provinceId).ToList();
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

    }
}
