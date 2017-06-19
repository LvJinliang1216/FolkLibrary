using System.Linq;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Repository.Interface.IRepository
{
    public interface IAreaRepository : IRepository<AreaEntity>
    {
        IQueryable<AreaEntity> Search(string cityId);
    }
}
