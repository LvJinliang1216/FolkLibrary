﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Repository.Repository
{
    public class ClueLibraryInfoRepository :BaseRepository<ClueLibraryInfoEntity> ,IClueLibraryInfoRepository
    {
        public ClueLibraryInfoRepository(IDbContext _dbContext)
            : base(_dbContext)
        {

        }
    }
}
