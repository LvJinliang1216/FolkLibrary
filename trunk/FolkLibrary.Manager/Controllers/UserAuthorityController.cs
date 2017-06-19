using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util.BaseController;
using FolkLibrary.Util.EasyuiPager;

namespace FolkLibrary.Manager.Controllers
{
    public class UserAuthorityController : BaseController
    {
        private readonly IUserAuthorityService _userAuthorityService;
        public UserAuthorityController(IUserAuthorityService userAuthorityService)
        {
            _userAuthorityService = userAuthorityService;
        }

        public ActionResult UserAuthority()
        {
            return View();
        }

        public JsonResult Search(UserAuthorityView userAuthorityView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var dataList = _userAuthorityService.Search(userAuthorityView, page.Value, rows.Value, out total).ToEasyuiPageList(total);
            return Json(dataList);
        }

        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <param name="userAuthorityView"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> SaveUserAuthority(UserAuthorityView userAuthorityView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                bool flag = await _userAuthorityService.CreateUserAuthority(userAuthorityView);
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "操作成功");
                return Json(dicMsg);
            }
            catch (Exception ex)
            {
                dicMsg.Add("Flag", "false");
                dicMsg.Add("Msg", ex.Message);
                return Json(dicMsg);
            }
        }

        /// <summary>
        /// 删除用户权限
        /// </summary>
        /// <param name="userAuthorityId"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteUserAuthority(int userAuthorityId)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                var flag = await _userAuthorityService.DeleteUserAuthority(userAuthorityId);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "操作成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "操作失败");
                }
                return Json(dicMsg);
            }
            catch (Exception ex)
            {
                dicMsg.Add("Flag", "false");
                dicMsg.Add("Msg", ex.Message);
                return Json(dicMsg);
            }
        }
    }
}
