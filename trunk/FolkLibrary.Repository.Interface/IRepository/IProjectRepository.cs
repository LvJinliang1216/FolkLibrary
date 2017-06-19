using System.Linq;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Repository.Interface.IRepository
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        IQueryable<ProjectEntity> Search(string ProjectClassId);
    }
}
