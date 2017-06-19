using Microsoft.Practices.Unity;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace FolkLibrary.Configuration.ControllerConfiguration
{
    public class UnityControllerFactory: DefaultControllerFactory
    {
        private IUnityContainer container;
        public UnityControllerFactory(IUnityContainer container)
        {
           this.container = container;
        }
       
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return null == controllerType ? null : (IController)this.container.Resolve(controllerType);
            //return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}