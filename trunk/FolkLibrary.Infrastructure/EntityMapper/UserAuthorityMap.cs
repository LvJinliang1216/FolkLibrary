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
    public class UserAuthorityMap : EntityTypeConfiguration<UserAuthorityEntity>
    {
        public UserAuthorityMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("UserAuthorityID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserInfoId).IsRequired().HasColumnName("UserInfoId");
            Property(x => x.ProgramId).IsRequired().HasColumnName("ProgramId");
            ToTable("UserAuthorities");
        }
    }
}
