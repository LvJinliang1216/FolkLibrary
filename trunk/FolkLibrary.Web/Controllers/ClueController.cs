using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;


namespace FolkLibrary.Web.Controllers
{
    public class ClueController : Controller
    {
        //
        // GET: /FolkLibray/Clue/

        private readonly IClueLibraryInfoServer _clueLibraryInfoServer;
        private readonly IProvinceService _provinceService;
        private readonly ICityService _cityService;
        private readonly IAreaService _areaService;

        public ClueController(IClueLibraryInfoServer clueLibraryInfoServer, IProvinceService provinceService, ICityService cityService, IAreaService areaService)
        {

            _clueLibraryInfoServer = clueLibraryInfoServer;
            _provinceService = provinceService;
            _cityService = cityService;
            _areaService = areaService;
        }

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProvinceList()
        {
            var provinceList = _provinceService.GetAll();
            return View(provinceList);
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns>所属省份</returns>
        public ActionResult CityList(string provinceId)
        {
            var cityList = _cityService.Search(provinceId);
            return Json(cityList);
        }
        /// <summary>
        /// 获取区县列表
        /// </summary>
        /// <param name="cityId">所属区县</param>
        /// <returns></returns>
        public ActionResult AreaList(string cityId)
        {
            var areaList = _areaService.Search(cityId);
            return Json(areaList);
        }
        /// <summary>
        /// 加载填写图书馆信息视图
        /// </summary>
        /// <returns></returns>
        public ActionResult LibraryInfo()
        {
            return PartialView("LibraryInfo");
        }

        [HttpPost]
        public ActionResult SaveLibraryInfo(ClueView clue)
        {
            clue.CreateTime = DateTime.Now;
            _clueLibraryInfoServer.Save(clue);
            return RedirectToAction("Index", "Clue");
        }
        public ActionResult Index()
        {
            var provinceList = _provinceService.GetAll();
            return View(provinceList);
        }

    }
}
