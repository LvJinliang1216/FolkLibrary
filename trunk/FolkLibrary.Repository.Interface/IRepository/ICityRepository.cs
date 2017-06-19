using System.Linq;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Repository.Interface.IRepository
{
    public interface ICityRepository:IRepository<CityEntity>
    {
        IQueryable<CityEntity> Search(string provinceId);
    }
}
