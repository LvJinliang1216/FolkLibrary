using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;

namespace FolkLibrary.Web.Controllers
{
    public class FolkLibraryController : Controller
    {
        private readonly IFriendDepartmentService _friendDepartmentService;
        private readonly ILibraryInfoService _libraryInfoService;
        private readonly IProvinceService _provinceService;
        public FolkLibraryController(ILibraryInfoService libraryInfoService,
            IFriendDepartmentService friendDepartmentService, IProvinceService provinceService)
        {
            _libraryInfoService = libraryInfoService;
            _friendDepartmentService = friendDepartmentService;
            _provinceService = provinceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int total = 0;
            var friendDeparmentList = _friendDepartmentService.Search(new FriendDepartmentView(), 1, 10, out total);
            var libraryInfoList = _libraryInfoService.Search(new LibraryInfoQueryView(), 1, 10, out total);
            var provinceList = _provinceService.GetAll();
            Dictionary<string, object> dicData = new Dictionary<string, object>
            {
                {"FriendDepartmentView", friendDeparmentList},
                {"LibraryInfoView", libraryInfoList},
                {"ProvinceView",provinceList}
            };
            return View(dicData);
        }

    }
}
