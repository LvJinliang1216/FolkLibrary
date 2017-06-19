using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class UserInfoEntity : IAggregateRoot
    {

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名【昵称】
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public IsAdministrator IsAdministrator { get; set; }

        //public IList<DonationInformationEntity> DonationInformationEntities { get; set; }

        //public IList<FriendDepartmentEntity> FriendDepartmentEntities { get; set; }

        //public IList<FriendNewsInfoEntity> FriendNewsInfoEntities { get; set; }

        //public IList<LibraryInfoEntity> LibraryInfoEntities { get; set; }

        //public IList<ModuleEntity> ModelEntities { get; set; }

        //public IList<ProgramEntity> ProgramEntities { get; set; }

        //public IList<ProjectClassEntity> ProjectClassEntities { get; set; }

        //public IList<ProjectEntity> ProjectEntities { get; set; }

        public IList<UserAuthorityEntity> UserAuthorityEntities { get; set; }
    }
}
