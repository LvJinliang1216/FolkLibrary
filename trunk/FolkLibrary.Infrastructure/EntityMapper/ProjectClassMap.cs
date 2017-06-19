using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class ProjectClassMap : EntityTypeConfiguration<ProjectClassEntity>
    {
        public ProjectClassMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).IsRequired().HasColumnName("Title").HasMaxLength(50);
            Property(x => x.Description).IsRequired().HasColumnName("Description").HasMaxLength(200);
            HasMany(x => x.Projects).WithRequired(x => x.ProjectClass).HasForeignKey(x => x.ProjectClassId);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("ProjectClasses");
        }
    }
}
