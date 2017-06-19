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
    public class ProgramMap : EntityTypeConfiguration<ProgramEntity>
    {
        public ProgramMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("ProgramId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PageIcon).IsRequired().HasMaxLength(50).HasColumnName("PageIcon");
            Property(x => x.PageUrl).IsRequired().HasMaxLength(100).HasColumnName("PageUrl");
            Property(x => x.ProgramName).IsRequired().HasMaxLength(100).HasColumnName("ProgramName");
            HasRequired(x => x.ModuleEntity).WithMany(x => x.ProgramEntities).HasForeignKey(x => x.ModuleId);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("Programs");
        }
    }
}
