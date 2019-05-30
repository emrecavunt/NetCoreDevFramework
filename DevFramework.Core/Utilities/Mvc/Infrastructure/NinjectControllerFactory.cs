//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Internal;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DevFramework.Core.Utilities.Mvc.Infrastructure
//{
//    public class NinjectControllerFactory : DefaultControllerFactory
//    {
//        private IKernel _kernel;
//        public NinjectControllerFactory(INinjectModule module)
//        {
//            _kernel = new StandartKernel();
//        }

//        protected override IController GetControllerInsantance(RequestContext requestContext,
//            Type controllerType)
//        {
//            return controllerType == null ? null : (IController) ? _kernel.Get(controllerType);
//        }
//    }
//}
