using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Repository
{
    public class ProvinceRepository : BaseRepository<ProvinceEntity>, IProvinceRepository
    {
        public ProvinceRepository(IDbContext _dbContext)
            : base(_dbContext)
        {
        }
    }
}
