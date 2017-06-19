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
    public class CityRepository : BaseRepository<CityEntity>, ICityRepository
    {
        public CityRepository(IDbContext _dbContext)
            : base(_dbContext)
        {

        }

        public IQueryable<CityEntity> Search(string provinceId)
        {
            return _entities.Where(x => x.Province.Id.ToString() == provinceId);
        }
    }
}
