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
    public class WebSiteInfoMap : EntityTypeConfiguration<WebSiteInfoEntity>
    {
        public WebSiteInfoMap()
        {
            HasKey<int>(t => t.Id);
            Property(x => x.Id).HasColumnName("WebSiteInfoId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Introduction).HasColumnName("Introduction");
            Property(x => x.WebSiteName).HasColumnName("WebSiteName").HasMaxLength(100);
            Property(x => x.WebSiteBrief).HasColumnName("WebSiteBrief");
            HasMany(x => x.FriendDepartments).WithRequired(x => x.WebSitInfo).HasForeignKey(x => x.WebSitInfoId);
            HasMany(x => x.FriendNewsInfoes).WithRequired(x => x.WebSitInfo).HasForeignKey(x => x.WebSitInfoId);
            ToTable("WebSiteInfoes");
        }

    }
}
