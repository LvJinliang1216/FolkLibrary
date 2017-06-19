using AutoMapper;
using FolkLibrary.Configuration.AutoMapperProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Configuration.Initialization
{
    public class Initialization
    {
        public static List<Type> _typeList { get; private set; }
        public static void AutoMapperInitialization()
        {
            Configuration();
            Mapper.Initialize(conf =>
            {
                foreach (var itemType in _typeList)
                {
                    if (itemType.IsAbstract || itemType.IsInterface)
                    {
                        continue;
                    }
                    if (typeof(Profile).IsAssignableFrom(itemType))
                    {
                        conf.AddProfile(itemType);
                    }
                }
            });
        }
        private static void Configuration()
        {
            _typeList = new List<Type>();
            _typeList.AddRange(Assembly.GetAssembly(typeof(UserInfoProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(ProvinceProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(ProjectProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(DonationInformationProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(ModuleProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(ProgramProfile)).GetTypes());
            _typeList.AddRange(Assembly.GetAssembly(typeof(WebSiteInfoProfile)).GetTypes());
        }
    }
}
