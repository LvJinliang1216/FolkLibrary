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
    public class ModuleController : BaseController
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public ActionResult ModuleList()
        {
            return View();
        }

        /// <summary>
        /// 查询模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult Search(ModuleView moduleView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var dataList = _moduleService.Search(moduleView, page.Value, rows.Value, out total).ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyModule(ModuleView moduleView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            if (moduleView.ModuleId == 0)
            {
                moduleView.UserInfoId = 1;
                bool flag = await _moduleService.CreateModule(moduleView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "添加成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "添加失败");
                }
            }
            else
            {
                moduleView.UserInfoId = 1;
                bool flag = await _moduleService.ModifyModule(moduleView);
                if (flag)
                {
                    dicMsg.Add("Flag", "true");
                    dicMsg.Add("Msg", "修改成功");
                }
                else
                {
                    dicMsg.Add("Flag", "false");
                    dicMsg.Add("Msg", "修改失败");
                }
            }
            return Json(dicMsg, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 删除模块信息【同时删除包含的页面信息】
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteModule(ModuleView moduleView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            var flag = await _moduleService.DeleteModule(moduleView.ModuleId);
            if (flag)
            {
                dicMsg.Add("Flag", "true");
                dicMsg.Add("Msg", "删除成功");
            }
            else
            {
                dicMsg.Add("Flag", "false");
                dicMsg.Add("Msg", "删除失败");
            }
            return Json(dicMsg, JsonRequestBehavior.DenyGet);
        }
    }
}
