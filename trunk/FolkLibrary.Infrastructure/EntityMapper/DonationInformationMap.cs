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
    public class DonationInformationMap : EntityTypeConfiguration<DonationInformationEntity>
    {
        public DonationInformationMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DonationDetail).HasColumnName("DonationDetail").IsRequired().HasMaxLength(200);
            Property(x => x.DonationInstruction).HasColumnName("DonationInstruction").IsRequired();
            Property(x => x.DonationUserName).HasColumnName("DonationUserName").IsRequired().HasMaxLength(50);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("DonationInformations");
        }
    }
}
