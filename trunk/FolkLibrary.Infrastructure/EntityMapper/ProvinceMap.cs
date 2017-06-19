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
    public class ProvinceMap : EntityTypeConfiguration<ProvinceEntity>
    {
        public ProvinceMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("ProvinceId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProvinceCode).HasColumnName("ProvinceCode").IsRequired().HasMaxLength(20);
            Property(x => x.ProvinceName).HasColumnName("ProvinceName").IsRequired().HasMaxLength(20);
            HasMany(x => x.Cities).WithRequired(x=>x.Province).HasForeignKey(x=>x.ProvinceId);
            HasMany(x => x.ProjectClasses).WithRequired(x => x.Province).HasForeignKey(x => x.ProvinceId);
            ToTable("Provinces");
        }
    }
}
