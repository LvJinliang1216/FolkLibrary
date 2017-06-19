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
    public class FriendDepartmentMap : EntityTypeConfiguration<FriendDepartmentEntity>
    {
        public FriendDepartmentMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DepartmentDescn).IsRequired().HasColumnName("DepartmentDescn");
            Property(x => x.FriendDepartmentUrl).IsRequired().HasColumnName("FriendDepartmentUrl").HasMaxLength(200);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            ToTable("FriendDepartments");
        }
    }
}
