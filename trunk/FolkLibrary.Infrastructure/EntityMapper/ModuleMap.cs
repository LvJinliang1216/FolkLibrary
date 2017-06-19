using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class ModuleMap : EntityTypeConfiguration<ModuleEntity>
    {
        public ModuleMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("ModuleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ModuleName).IsRequired().HasMaxLength(100).HasColumnName("ModuleName");
            Property(x => x.ModuleIcon).IsRequired().HasMaxLength(100).HasColumnName("ModuleIcon");
            Property(x => x.ModuleIcon).HasMaxLength(50).HasColumnName("ModuleIcon");
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("Modules");
        }
    }
}
