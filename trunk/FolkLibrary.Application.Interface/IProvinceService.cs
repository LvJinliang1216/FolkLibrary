﻿using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Application.Interface
{
    public interface IProvinceService
    {
        List<ProvinceView> GetAll();
    }
}
