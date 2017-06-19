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
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ActionResult ProjectList()
        {
            return View();
        }

        /// <summary>
        /// 查询项目信息
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
            var dataList = _projectService.Search(projectQuery, page.Value, rows.Value, out total).ToEasyuiPageList(total);
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑项目信息
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns></returns>
        public async Task<JsonResult> CreateOrModifyProject(ProjectView projectView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            if (projectView.ProjectId == 0)
            {
                projectView.StaticPageUrl = "";
                projectView.UserInfoId = 1;
                bool flag = await _projectService.CreateProject(projectView);
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
                projectView.UserInfoId = 1;
                projectView.StaticPageUrl = "";
                bool flag = await _projectService.ModifyProject(projectView);
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
        /// 删除项目信息
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns></returns>
        public async Task<JsonResult> DeleteProject(ProjectView projectView)
        {
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            var flag = await _projectService.DeleteProject(projectView.ProjectId);
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
