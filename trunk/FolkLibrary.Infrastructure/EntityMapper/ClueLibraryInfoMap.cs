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
    public class ClueLibraryInfoMap : EntityTypeConfiguration<ClueLibraryInfoEntity>
    {
        public ClueLibraryInfoMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("ClueLibraryInfoId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Address).IsRequired().HasMaxLength(500).HasColumnName("Address");
            HasRequired(x => x.AreaEntity).WithMany(x => x.ClueLibraryInfoEntities).HasForeignKey(x => x.AreaId);
            Property(x => x.Brief).IsRequired().HasMaxLength(200).HasColumnName("Brief");
            Property(x => x.BuilDateTime).HasColumnName("BuilDateTime");
            Property(x => x.CreateTime).IsRequired().HasColumnName("CreateTime");
            Property(x => x.LibrarianName).HasMaxLength(20).HasColumnName("LibrarianName");
            Property(x => x.LibraryName).IsRequired().HasMaxLength(50).HasColumnName("LibraryName");
            ToTable("ClueLibraryInfoes");
        }
    }
}
