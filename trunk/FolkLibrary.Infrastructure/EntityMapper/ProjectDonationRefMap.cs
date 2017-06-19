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
    public class ProjectDonationRefMap: EntityTypeConfiguration<ProjectDonationRefEntity>
    {
        public ProjectDonationRefMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("ProjectDonationRefId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.DonationInfoId).HasColumnName("DonationInfoId").IsRequired();
            ToTable("Areas");
        }
    }
}