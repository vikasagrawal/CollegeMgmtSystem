using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Core.DataManagers;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College.UserProfile.Ux
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            Scan(x =>
                {
                    x.AssembliesFromApplicationBaseDirectory();
                    x.WithDefaultConventions();
                });

            //For<ICodeLookupReader>().Use<CodeLookupReader>();
        }
    }
}