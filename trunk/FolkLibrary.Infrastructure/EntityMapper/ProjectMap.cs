using System.Data.Entity.ModelConfiguration;
using FolkLibrary.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class ProjectMap : EntityTypeConfiguration<ProjectEntity>
    {
        public ProjectMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectContent).IsRequired().HasColumnName("ProjectContent");
            Property(x => x.StaticPageUrl).IsRequired().HasColumnName("StaticPageUrl").HasMaxLength(32);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("Projects");
        }
    }
}
