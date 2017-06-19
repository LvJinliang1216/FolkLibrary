using FolkLibrary.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Util.MvcPager;

namespace FolkLibrary.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProjectClassService _projectClassService;
        private readonly IProvinceService _provinceService;
        public ProjectController(IProjectClassService projectClassService, IProvinceService provinceService, IProjectService projectService)
        {
            this._projectService = projectService;
            this._projectClassService = projectClassService;
            this._provinceService = provinceService;
        }

        /// <summary>
        /// 获取项目分类列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult ProjectClassList(ProjectQuery query, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;
            int total = 0;
            var projectClassList = _projectClassService.Search(query, pageIndex.Value, pageSize.Value, out total).ToList()
                .ToPagedList(pageIndex.Value, pageSize.Value, total);
            var provinceList = _projectClassService.GroupByProvince();
            Dictionary<string, object> dicData = new Dictionary<string, object>();
            dicData.Add("ProjectClassList", projectClassList);
            dicData.Add("ProvinceList", provinceList);
            ViewBag.ProvinceCode = query.ProvinceId;
            ViewBag.PageIndex = pageIndex.Value;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProjectClassListView", dicData);
            }
            return View(dicData);
        }

        /// <summary>
        /// 获取项目列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult ProjectList(ProjectQuery query, int? pageIndex, int? pageSize)
        {
            pageIndex = pageIndex ?? 1;
            pageSize = pageSize ?? 10;
            int total = 0;
            var projectList = _projectService.Search(query, pageIndex.Value, pageSize.Value, out total).ToPagedList(pageIndex.Value, pageSize.Value, total);
            var provinceList = _projectClassService.GroupByProvince();
            Dictionary<string, object> dicData = new Dictionary<string, object>();
            dicData.Add("ProjectList", projectList);
            dicData.Add("ProvinceList", provinceList);
            return View(dicData);
        }

        public ActionResult ProjectDeatil(int? projectId)
        {
            if (projectId.HasValue)
            {
                return View(_projectService.Get(projectId.Value));
            }
            else
            {
                return View();
            }
            
        }
    }
}
