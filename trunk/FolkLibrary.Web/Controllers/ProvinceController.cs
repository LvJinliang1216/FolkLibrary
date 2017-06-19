using FolkLibrary.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FolkLibrary.Web.Controllers
{
    public class ProvinceController : Controller
    {
         private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        public ActionResult Index(string provinceCode)
        {

            var provinceModelList = _provinceService.GetAll();
            return PartialView("ProvinceIndexWithProgress", provinceModelList);
        }
    }
}
