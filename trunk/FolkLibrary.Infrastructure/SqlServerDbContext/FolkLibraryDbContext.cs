using FolkLibrary.Infrastructure.EntityMapper;
using FolkLibrary.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Infrastructure.SqlServerDbContext
{
    public class FolkLibraryDbContext : DbContext, IDbContext
    {
        public FolkLibraryDbContext()
            : base("FolkLibrary")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WebSiteInfoMap());
            modelBuilder.Configurations.Add(new ProvinceMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new ProjectClassMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new AttachmentMap());
            modelBuilder.Configurations.Add(new DonationInformationMap());
            modelBuilder.Configurations.Add(new FriendDepartmentMap());
            modelBuilder.Configurations.Add(new FriendNewsInfoMap());
            modelBuilder.Configurations.Add(new LeaveWordMap());
            modelBuilder.Configurations.Add(new LibraryInfoMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new ClueLibraryInfoMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ProgramMap());
            modelBuilder.Configurations.Add(new UserAuthorityMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
