using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
  public  interface IProjectService
  {
      ProjectView Get(int id);
      IList<ProjectView> GetAll();

      /// <summary>
      /// 查询项目信息
      /// </summary>
      /// <param name="query"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <param name="total"></param>
      /// <returns></returns>
      IList<ProjectView> Search(ProjectQuery query, int pageIndex, int pageSize,out  int total);

      /// <summary>
      /// 添加项目信息
      /// </summary>
      /// <param name="projectView"></param>
      /// <returns></returns>
      Task<bool> CreateProject(ProjectView projectView);

      /// <summary>
      /// 修改项目信息
      /// </summary>
      /// <param name="projectView"></param>
      /// <returns></returns>
      Task<bool> ModifyProject(ProjectView projectView);

      /// <summary>
      /// 删除项目信息
      /// </summary>
      /// <param name="projectClassId"></param>
      /// <returns></returns>
      Task<bool> DeleteProject(int projectClassId);
  }
}
