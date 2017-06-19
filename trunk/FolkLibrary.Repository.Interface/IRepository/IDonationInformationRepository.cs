using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Repository.Interface.IRepository
{
    public interface IDonationInformationRepository
    {
        IQueryable<DonationInformationEntity> Get(int id);

        IQueryable<DonationInformationEntity> GetAll();

    }
}
