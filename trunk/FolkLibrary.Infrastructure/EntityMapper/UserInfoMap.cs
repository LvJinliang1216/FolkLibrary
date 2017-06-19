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
    public class UserInfoMap : EntityTypeConfiguration<UserInfoEntity>
    {
        public UserInfoMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("UserInfoID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName("UserName ").IsRequired().HasMaxLength(20);
            Property(x => x.AccountName).HasColumnName("AccountName").IsRequired().HasMaxLength(20);
            Property(x => x.Password).HasColumnName("UserPwd").IsRequired().HasMaxLength(32);
            ToTable("UserInfos");
        }
    }
}
