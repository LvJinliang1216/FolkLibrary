using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Application.Interface
{
    public interface IClueLibraryInfoServer
    {
        /// <summary>
        /// 添加图书馆信息
        /// </summary>
        /// <param name="leaveWord"></param>
        /// <returns></returns>
        Task<bool> Save(ClueView clue);
    }
}
