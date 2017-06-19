using FolkLibrary.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;

namespace FolkLibrary.Web.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly IProvinceService _provinceService;
        private readonly IWebSitInfoService _webSitInfoService;
        private readonly IProjectService _projectService;
        private readonly IDonationInformationServer _donationInformationServer;
        private readonly ILibraryInfoService _libraryInfoService;
        private readonly IFriendDepartmentService _friendDepartmentService;
        public WelcomeController(IProvinceService provinceService,
            IWebSitInfoService webSitInfoService,
            IProjectService projectService, IDonationInformationServer donationInformationServer, ILibraryInfoService libraryInfoService, IFriendDepartmentService friendDepartmentService)
        {
            _provinceService = provinceService;
            _webSitInfoService = webSitInfoService;
            _projectService = projectService;
            _donationInformationServer = donationInformationServer;
            _libraryInfoService = libraryInfoService;
            _friendDepartmentService = friendDepartmentService;
        }

        public ActionResult Index()
        {
            int total=0;
            var provinceModelList = _provinceService.GetAll();
            var webSiteInfo = _webSitInfoService.GetAll(1,1,out total).FirstOrDefault();
            var projectList = _projectService.Search(new ProjectQuery(), 1, 5, out total);
            var donationList = _donationInformationServer.Search(new DonationInformationView(), 1, 1, out total);
            var libraryInfoList = _libraryInfoService.Search(new LibraryInfoQueryView(), 1, 5, out total);
            var friendDepartmentList = _friendDepartmentService.Search(new FriendDepartmentView(), 1, 5, out total);
            Dictionary<string,object> dicData=new Dictionary<string, object>()
            {
                {"ProjectView",projectList},
                {"WebSiteInfoView",webSiteInfo},
                {"DonationInformationView",donationList},
                {"LibraryInfoView",libraryInfoList},
                {"FriendDepartmentView",friendDepartmentList}
            };
            return View(dicData);
        }

    }
}
