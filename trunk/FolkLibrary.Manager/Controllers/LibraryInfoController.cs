using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;
using FolkLibrary.Util.BaseController;
using FolkLibrary.Util.EasyuiPager;

namespace FolkLibrary.Manager.Controllers
{
    public class LibraryInfoController : BaseController
    {
        private readonly ILibraryInfoService _libraryInfoService;
        public LibraryInfoController(ILibraryInfoService libraryInfoService)
        {
            _libraryInfoService = libraryInfoService;
        }

        public ActionResult LibraryInfoList()
        {
            return View();
        }

        /// <summary>
        /// 查询项目分类
        /// </summary>
        /// <param name="queryView"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult Search(LibraryInfoQueryView queryView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var tempData = _libraryInfoService.Search(queryView, page.Value, rows.Value, out total);
            var dataList = tempData.ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 编辑图书馆信息
        /// </summary>
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyLibraryInfo(LibraryInfoView libraryInfoView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            libraryInfoView.UserInfoId = 1;
            libraryInfoView.StaticPageUrl = "";
            if (libraryInfoView.LibraryInfoId == 0)
            {
                bool flag = await _libraryInfoService.CreateLibraryInfo(libraryInfoView);
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
                bool flag = await _libraryInfoService.ModifyLibraryInfo(libraryInfoView);
                libraryInfoView.UserInfoId = 1;
                libraryInfoView.StaticPageUrl = "";
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
        /// 删除图书馆信息
        /// </summary>
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteLibraryInfo(LibraryInfoView libraryInfoView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            bool flag = await _libraryInfoService.DeleteLibraryInfo(libraryInfoView.LibraryInfoId);
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
