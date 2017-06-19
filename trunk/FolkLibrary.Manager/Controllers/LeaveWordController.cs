using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.DataTransferObject.QueryModels;
using FolkLibrary.Util.BaseController;
using FolkLibrary.Util.EasyuiPager;

namespace FolkLibrary.Manager.Controllers
{
    public class LeaveWordController : BaseController
    {
        // GET: /LeaveWord/
        private readonly ILeaveWordService _leaveWordService;
        public LeaveWordController(ILeaveWordService leaveWordService)
        {
         
            _leaveWordService = leaveWordService;
        }

        public ActionResult LeaveWordIndex()
        {
            return View();
        }

        /// <summary>
        /// 分页获取留言信息
        /// </summary>
        /// <param name="leaveWordQueryView"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult LeaveWordList(LeaveWordQueryView leaveWordQueryView, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var dataList = _leaveWordService.SearchLeaveWord(leaveWordQueryView, page.Value, rows.Value, out total).ToEasyuiPageList(total);
            return Json(dataList,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除留言信息
        /// </summary>
        /// <param name="leaveWordId"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteLeaveWord(string leaveWordId)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            try
            {
                var flag = await _leaveWordService.DeleteLeaveWord(leaveWordId);
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
