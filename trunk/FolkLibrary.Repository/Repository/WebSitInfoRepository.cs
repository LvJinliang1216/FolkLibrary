using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Repository
{
    public class WebSitInfoRepository : BaseRepository<WebSiteInfoEntity>, IWebSitInfoRepository
    {
        public WebSitInfoRepository(IDbContext _dbContext)
            : base(_dbContext)
        {
 
        }
    }
}
