using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;

namespace FolkLibrary.Application.Interface
{
    public interface ILeaveWordService
    {
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="leaveWord"></param>
        /// <returns></returns>
        Task<bool> Save(LeaveWordView leaveWord);

        Task<IList<LeaveWordView>> GetAll();
        /// <summary>
        /// 分页获取留言信息
        /// </summary>
        /// <returns></returns>
        IList<LeaveWordView> SearchLeaveWord(LeaveWordQueryView leaveWordQueryView, int pageIndex, int pageSize, out  int total);

        /// <summary>
        /// 删除留言信息
        /// </summary>
        /// <param name="leaveWordId"></param>
        /// <returns></returns>
        Task<bool> DeleteLeaveWord(string leaveWordId);
    }
}
