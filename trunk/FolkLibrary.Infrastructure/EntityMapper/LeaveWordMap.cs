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
    public class LeaveWordMap : EntityTypeConfiguration<LeaveWordEntity>
    {
        public LeaveWordMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).IsRequired().HasColumnName("Email").HasMaxLength(50);
            Property(x => x.LeaveWordContent).HasColumnName("LeaveWordContent").HasMaxLength(200);
            Property(x => x.LeaveWordTitle).HasColumnName("LeaveWordTitle").HasMaxLength(50);
            Property(x => x.Telephone).HasColumnName("Telephone").HasMaxLength(15);
            ToTable("LeaveWordes");
        }
    }
}
