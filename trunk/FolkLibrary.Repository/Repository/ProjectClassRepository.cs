using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Repository.Repository
{
    public class ProjectClassRepository : BaseRepository<ProjectClassEntity>, IProjectClassRepository
    {
        public ProjectClassRepository(IDbContext _dbContext)
            : base(_dbContext)
        {

        }
        public IQueryable<ProjectClassEntity> Search(string provinceCode)
        {
            if (!string.IsNullOrEmpty(provinceCode))
            {
                return _entities.Where(x => x.Province.ProvinceCode == provinceCode);
            }
            else
            {
                return _entities;
            }
            
        }
        public IQueryable<ProjectClassEntity> Search(string provinceCode, int pageIndex, int pageSize, out int total)
        {
            if (!string.IsNullOrEmpty(provinceCode))
            {
                var tempData = _entities.Where(x => x.Province.ProvinceCode == provinceCode);
                total = tempData.Count();
                return tempData.OrderBy(x => x.SortCode).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                total = _entities.Count();
                return _entities.OrderBy(x=>x.SortCode).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

        }
    }
}
