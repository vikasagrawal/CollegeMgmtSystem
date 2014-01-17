using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace College.UserProfile.Ux.App_Start
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            try
            {
                if ((requestContext == null) || (controllerType == null))
                    return null;

                return (Controller)ObjectFactory.GetInstance(controllerType);
            }
            catch (StructureMapException ex)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw new Exception(ObjectFactory.WhatDoIHave());
            }
        }
    }

    public static class Bootstrapper
    {
        public static void Run()
        {
            ControllerBuilder.Current
                .SetControllerFactory(new StructureMapControllerFactory());

            
            ObjectFactory.Initialize(x =>
            {
               
                x.AddRegistry(new ServiceRegistry());
            });
        }
    }
}