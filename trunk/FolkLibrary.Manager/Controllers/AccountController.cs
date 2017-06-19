using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util.EasyuiPager;

namespace FolkLibrary.Manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        public AccountController(IUserInfoService userInfoService)
        {
            this._userInfoService = userInfoService;
        }

        public ActionResult UserInfo()
        {
            return View();
        }

        public JsonResult UserInfoList(UserInfoView userInfo, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var dataList = _userInfoService.SearchUserInfo(userInfo, page.Value, rows.Value, out total).ToEasyuiPageList(total);
            return Json(dataList);
        }

        [HttpPost]
        public async Task<JsonResult> SaveUserInfo(UserInfoView userInfo)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                bool flag = await _userInfoService.SaveUserInfo(userInfo);
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
        /// 重置密码
        /// </summary>
        /// <param name="userInfoId">用户Id</param>
        /// <returns></returns>
        public async Task<JsonResult> ResetPassword(string userInfoId)
        {

            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                var flag = await _userInfoService.ResetPassword(userInfoId);
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

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteUserInfo(string userInfoId)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                var flag = await _userInfoService.DeleteUserInfo(userInfoId);
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
