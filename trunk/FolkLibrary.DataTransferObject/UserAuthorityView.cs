using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class UserAuthorityView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int UserAuthorityId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsAuthority { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public UserInfoView UserInfoView { get; set; }

        /// <summary>
        ///页面Id
        /// </summary>
        public int ProgramId { get; set; }

        /// <summary>
        /// 页面信息
        /// </summary>
        public ProgramView ProgramView { get; set; }
    }
}
