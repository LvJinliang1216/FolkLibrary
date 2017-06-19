using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using FolkLibrary.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolkLibrary.Infrastructure.EntityMapper
{
    public class AttachmentMap : EntityTypeConfiguration<AttachmentEntity>
    {
        public AttachmentMap()
        {
            HasKey<int>(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FileName).IsRequired().HasColumnName("FileName").HasMaxLength(50);
            Property(x => x.FileAddress).IsRequired().HasColumnName("FileAddress").HasMaxLength(200);
            ToTable("Attachments");
        }
    }
}
