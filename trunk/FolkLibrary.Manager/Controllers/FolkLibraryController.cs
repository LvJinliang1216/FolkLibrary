using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util;
using FolkLibrary.Util.EasyuiPager;


namespace FolkLibrary.Manager.Controllers
{
    public class FolkLibraryController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IUserAuthorityService _userAuthorityService;
        public FolkLibraryController(IUserInfoService userInfoService, IUserAuthorityService userAuthorityService)
        {
            _userInfoService = userInfoService;
            _userAuthorityService = userAuthorityService;
        }

        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 验证用户的登录
        /// </summary>
        /// <param name="userInfoView"></param>
        /// <returns></returns>
        public ActionResult ValidateLogin(UserInfoView userInfoView)
        {
            var userInfo = _userInfoService.ValidateLogin(userInfoView);
            if (userInfo != null)
            {
                CookieHelper.WriteCookie("UserInfo", userInfo.ToJson());
                return RedirectToAction("FolkLibraryIndex");
            }
            return View("Login");
        }

        public ActionResult FolkLibraryIndex()
        {
            int total;
            var moduleList = new List<ModuleView>();
            var userAuthorities = _userAuthorityService.Search(new UserAuthorityView()
              {
                  UserInfoId = 1
              }, 1, 999, out total);
            foreach (var programItem in userAuthorities)
            {
                if (moduleList.Count(x => x.ModuleId == programItem.ProgramView.ModuleView.ModuleId) == 0)
                {
                    moduleList.Add(programItem.ProgramView.ModuleView);

                }
                var item = programItem;
                var moduleItem = moduleList.FirstOrDefault(x => x.ModuleId == item.ProgramView.ModuleView.ModuleId);
                if (moduleItem != null && moduleItem.ProgramViews == null)
                {
                    moduleItem.ProgramViews = new List<ProgramView>();
                }
                if (moduleItem != null) moduleItem.ProgramViews.Add(programItem.ProgramView);
            }
            return View(moduleList);
        }

        /// <summary>
        /// 用户退出
        /// </summary>
        /// <returns></returns>
        public ActionResult UserSignOut()
        {
            CookieHelper.ClearCookie("UserInfo");
            return RedirectToAction("Login", "FolkLibrary");
        }
    }
}
