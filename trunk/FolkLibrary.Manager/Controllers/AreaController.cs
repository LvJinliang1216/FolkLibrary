using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.Util.BaseController;

namespace FolkLibrary.Manager.Controllers
{
    public class AreaController : BaseController
    {
        public readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        /// <summary>
        /// 获取区县信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetArea(int cityId)
        {
            var dataList = _areaService.GetAll().Where(x => x.CityId == cityId).ToList();
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
    }
}
