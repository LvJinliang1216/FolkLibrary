using AutoMapper;
using FolkLibrary.Application;
using FolkLibrary.Application.Interface;
using FolkLibrary.Infrastructure;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Infrastructure.SqlServerDbContext;
using FolkLibrary.Repository;
using FolkLibrary.Repository.Interface;
using FolkLibrary.Repository.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Configuration.UnityConfiguration
{
    public class UnityConfig
    {
        public IUnityContainer _container { get; private set; }
        public UnityConfig()
        {
            _container = new UnityContainer();
            _container.RegisterInstance(typeof(IMapper), Mapper.Instance);
            _container.RegisterType<IDbContext, FolkLibraryDbContext>();//要进行LifetimeManager配置
            _container.RegisterType<IUnitOfWork, UnitOfWork>();
            #region 数据持久化映射关系
            _container.RegisterType<IUserInfoRepository, UserInfoRepository>();
            _container.RegisterType<IProvinceRepository, ProvinceRepository>();
            _container.RegisterType<IWebSitInfoRepository, WebSitInfoRepository>();
            _container.RegisterType<ICityRepository, CityRepository>();
            _container.RegisterType<IAreaRepository, AreaRepository>();
            _container.RegisterType<IProjectClassRepository, ProjectClassRepository>();
            _container.RegisterType<IProjectRepository, ProjectRepository>();
            _container.RegisterType<IDonationInformationRepository, DonationInformationRepository>();
            _container.RegisterType<IClueLibraryInfoRepository, ClueLibraryInfoRepository>();
            _container.RegisterType<ILeaveWordRepository, LeaveWordRepository>();
            _container.RegisterType<IModuleRepository, ModuleRepository>();
            _container.RegisterType<IProgramRepository, ProgramRepository>();
            _container.RegisterType<IUserAuthorityRepository, UserAuthorityRepository>();
            _container.RegisterType<IFriendDepartmentRepository, FriendDepartmentRepository>();
            _container.RegisterType<IProjectDonationRefRespository, ProjectDonationRefRespository>();
            _container.RegisterType<IProjectRepository, ProjectRepository>();
            _container.RegisterType<ILibraryInfoRepository, LibraryInfoRepository>();
            _container.RegisterType<IAttachmentRepository, AttachmentRepository>();

            #endregion

            #region 服务映射关系
            _container.RegisterType<IUserInfoService, UserInfoService>();
            _container.RegisterType<IProvinceService, ProvinceService>();
            _container.RegisterType<IWebSitInfoService, WebSitInfoService>();
            _container.RegisterType<ICityService, CityService>();
            _container.RegisterType<IAreaService, AreaService>();
            _container.RegisterType<IProjectClassService, ProjectClassService>();
            _container.RegisterType<IProjectService, ProjectService>();
            _container.RegisterType<IDonationInformationServer, DonationInformationServer>();
            _container.RegisterType<IClueLibraryInfoServer, ClueLibraryInfoServer>();
            _container.RegisterType<ILeaveWordService, LeaveWordService>();
            _container.RegisterType<IModuleService, ModuleService>();
            _container.RegisterType<IProgramService, ProgramService>();
            _container.RegisterType<IUserAuthorityService, UserAuthorityService>();
            _container.RegisterType<IFriendDepartmentService, FriendDepartmentService>();
            _container.RegisterType<IProjectService, ProjectService>();
            _container.RegisterType<ILibraryInfoService, LibraryInfoService>();
            #endregion
        }
    }
}
