using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject.QueryModels;

namespace FolkLibrary.Web.Controllers
{
    public class LibraryInfoController : Controller
    {
        private readonly ILibraryInfoService _libraryInfoService;

        public LibraryInfoController(ILibraryInfoService libraryInfoService)
        {
            _libraryInfoService = libraryInfoService;
        }

        /// <summary>
        /// 获取图书馆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetData()
        {
            int total = 0;
            var libraryInfoList = _libraryInfoService.Search(new LibraryInfoQueryView(), 1, 5, out total);
            return Json(libraryInfoList, JsonRequestBehavior.AllowGet);
        }
    }
}
