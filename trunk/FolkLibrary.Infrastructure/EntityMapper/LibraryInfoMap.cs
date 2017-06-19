using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class LibraryInfoMap : EntityTypeConfiguration<LibraryInfoEntity>
    {
        public LibraryInfoMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Address).IsRequired().HasColumnName("Address").HasMaxLength(200);
            Property(x => x.BuildUserName).IsRequired().HasColumnName("BuildUserName").HasMaxLength(50);
            Property(x => x.InformationFrom).IsRequired().HasColumnName("InformationFrom").HasMaxLength(50);
            Property(x => x.LibraryDescription).IsRequired().HasColumnName("LibraryDescription");
            Property(x => x.LibraryName).IsRequired().HasColumnName("LibraryName").HasMaxLength(50);
            Property(x => x.StaticPageUrl).IsRequired().HasColumnName("StaticPageUrl").HasMaxLength(50);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("LibraryInfoes");
        }
    }
}
