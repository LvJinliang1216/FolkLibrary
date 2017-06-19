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
    public class CityMap : EntityTypeConfiguration<CityEntity>
    {
        public CityMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("CityId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CityName).HasColumnName("CityName").IsRequired().HasMaxLength(20);
            Property(x => x.CityCode).HasColumnName("CityCode").IsRequired().HasMaxLength(20);
            HasMany(x => x.Areas).WithRequired(x => x.City).HasForeignKey(x => x.CityId);
            ToTable("Cities");
        }
    }
}
