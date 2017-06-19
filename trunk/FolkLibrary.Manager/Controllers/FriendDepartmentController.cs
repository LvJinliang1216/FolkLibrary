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
    public class FriendDepartmentController : BaseController
    {
        private readonly IFriendDepartmentService _friendDepartmentService;
        public FriendDepartmentController(IFriendDepartmentService friendDepartmentService)
        {
            _friendDepartmentService = friendDepartmentService;
        }

        public ActionResult FriendDepartment()
        {
            return View();
        }

        /// <summary>
        /// 查询相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult Search(FriendDepartmentView friendDepartmentView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var tempData = _friendDepartmentService.Search(friendDepartmentView, page.Value, rows.Value, out total);
            var data = tempData.ToEasyuiPageList(total);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑主办单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyFriendDepartment(FriendDepartmentView friendDepartmentView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            friendDepartmentView.WebSitInfoId = 1;
            friendDepartmentView.UserInfoId = 1;
            if (friendDepartmentView.Id == 0)
            {
                var flag = await _friendDepartmentService.CreateFriendDepartment(friendDepartmentView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "添加信息成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "添加信息失败");
                }
            }
            else
            {
                var flag = await _friendDepartmentService.ModifyFriendDepartment(friendDepartmentView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "修改信息成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "修改信息失败");
                }
            }
            return Json(dicMsg);
        }

        /// <summary>
        /// 删除主办单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteFriendDepartment(FriendDepartmentView friendDepartmentView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            var flag = await _friendDepartmentService.DeleteFriendDepartment(friendDepartmentView.Id);
            if (flag)
            {
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "删除信息成功");
            }
            else
            {
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "删除信息失败");
            }
            return Json(dicMsg);
        }
    }
}
