using System;
using System.Security.Policy;

namespace NFabric.Host
{
    public class AppDomainFactory
    {
        public AppDomainFactory()
        {

        }

        public static AppDomain CreateDomain(string bcAssembly, string nFabricBCAssembly) {
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;

            var domain = AppDomain.CreateDomain("BC", adevidence, domaininfo);

            return domain;
        }
    }
}