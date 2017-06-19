using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Application.Interface
{
    public interface IAreaService
    {
        IList<AreaView> GetAll();

        IList<AreaView> Search(string cityId);
    }
}
