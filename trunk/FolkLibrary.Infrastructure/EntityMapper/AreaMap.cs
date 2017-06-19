using FolkLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class AreaMap : EntityTypeConfiguration<AreaEntity>
    {
        public AreaMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("AreaId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.AreaName).IsRequired().HasMaxLength(20).HasColumnName("AreaName");
            Property(x => x.AreaCode).IsRequired().HasMaxLength(20).HasColumnName("AreaCode");
            HasMany(x => x.LibraryInfo).WithRequired(x => x.Area).HasForeignKey(x => x.AreaId);
            ToTable("Areas");
        }
    }
}
