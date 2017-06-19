using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Application.Interface
{
    public interface ICityService
    {
        IList<CityView> GetAll();

        IList<CityView> Search(string provinceId);
    }
}
