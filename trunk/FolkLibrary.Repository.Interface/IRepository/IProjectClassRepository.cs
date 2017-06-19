using System.Linq;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Repository.Interface.IRepository
{
    public interface IProjectClassRepository: IRepository<ProjectClassEntity>
    {
        IQueryable<ProjectClassEntity> Search(string provinceCode);
        IQueryable<ProjectClassEntity> Search(string provinceCode, int pageIndex, int pageSize, out int total);
    }
}
