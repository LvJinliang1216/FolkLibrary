using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Repository
{
    public class UserInfoRepository : BaseRepository<UserInfoEntity>, IUserInfoRepository
    {
        public UserInfoRepository(IDbContext _dbContext)
            : base(_dbContext)
        {
 
        }
    }
}
