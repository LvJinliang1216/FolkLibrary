using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FolkLibrary.Application.Interface
{
    public interface IProjectClassService
    {
        IList<ProjectClassView> GetAll();

        /// <summary>
        /// 按照省份进行查询获取数据
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        IList<ProjectClassView> Search(string provinceCode);

        /// <summary>
        /// 查询项目分类信息
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IList<ProjectClassView> Search(ProjectQuery query, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 获取项目分类信息【按照省份进行分组】
        /// </summary>
        /// <returns></returns>
        IList<ProvinceWithProjectClassView> GroupByProvince();

        /// <summary>
        /// 添加项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        Task<bool> CreateProjectClass(ProjectClassView projectClassView);

        /// <summary>
        /// 修改项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        Task<bool> ModifyProjectClass(ProjectClassView projectClassView);

        /// <summary>
        /// 删除项目分类信息
        /// </summary>
        /// <param name="projectClassId"></param>
        /// <returns></returns>
        Task<bool> DeleteProjectClass(int projectClassId);
    }
}
