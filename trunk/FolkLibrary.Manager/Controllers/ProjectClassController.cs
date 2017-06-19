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
    public class ProjectClassController : BaseController
    {
        private readonly IProjectClassService _projectClassService;
        public ProjectClassController(IProjectClassService projectClassService)
        {
            _projectClassService = projectClassService;
        }

        public ActionResult ProjectClassList()
        {
            return View();
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAll()
        {
            var dataList = _projectClassService.GetAll().OrderByDescending(x=>x.ModifyDateTime).ToList();
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询项目分类
        /// </summary>
        /// <param name="projectQuery"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult Search(ProjectQuery projectQuery, int? page, int? rows)
        {
            page = page ?? 1;
            rows = rows ?? 10;
            int total = 0;
            var tempData = _projectClassService.Search(projectQuery, page.Value, rows.Value, out total);
            var dataList = tempData.ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 编辑项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyProjectClass(ProjectClassView projectClassView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            projectClassView.UserInfoId = 1;
            if (projectClassView.ProjectClassId == 0)
            {
                bool flag = await _projectClassService.CreateProjectClass(projectClassView);
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
                bool flag = await _projectClassService.ModifyProjectClass(projectClassView);
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
        /// 删除项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteProjectClass(ProjectClassView projectClassView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            bool flag = await _projectClassService.DeleteProjectClass(projectClassView.ProjectClassId);
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
