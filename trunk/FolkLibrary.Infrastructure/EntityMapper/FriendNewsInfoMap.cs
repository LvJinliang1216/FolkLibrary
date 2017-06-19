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
    public class FriendNewsInfoMap : EntityTypeConfiguration<FriendNewsInfoEntity>
    {
        public FriendNewsInfoMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FrindNewsUrl).IsRequired().HasColumnName("FriendUrl").HasMaxLength(200);
            Property(x => x.Title).IsRequired().HasColumnName("Title").HasMaxLength(50);
            Property(x => x.Content).IsRequired().HasColumnName("Content");
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("FriendNewsInfoes");
        }
    }
}
