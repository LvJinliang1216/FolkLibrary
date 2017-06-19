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
    public class ProgramController : BaseController
    {
        private readonly IProgramService _programService;
        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="programView">查询条件</param>
        /// <param name="page">页码</param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult Search(ProgramView programView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var tempData = _programService.Search(programView, page.Value, rows.Value, out total);
            var dataList = tempData.ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加模块信息
        /// </summary>
        /// <param name="programView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyProgram(ProgramView programView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            if (programView.ProgramId == 0)
            {
                programView.UserInfoId = 1;
                bool flag = await _programService.CreateProgram(programView);
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
                programView.UserInfoId = 1;
                bool flag = await _programService.ModifyProgram(programView);
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
        /// 删除模块信息
        /// </summary>
        /// <param name="programView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteProgram(ProgramView programView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            var flag = await _programService.DeleteProgram(programView.ProgramId);
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
