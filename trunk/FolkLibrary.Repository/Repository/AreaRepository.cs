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
    public class AreaRepository : BaseRepository<AreaEntity>, IAreaRepository
    {
        public AreaRepository(IDbContext _dbContext)
            : base(_dbContext)
        {

        }

        public IQueryable<AreaEntity> Search(string cityId)
        {
            return _entities.Where(x => x.CityId.ToString() == cityId);
        }
    }
}
