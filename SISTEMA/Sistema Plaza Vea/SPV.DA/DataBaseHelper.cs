using System;
using System.Data;
using System.Configuration;

namespace SPV.DA
{
    public static class DataBaseHelper
    {
        public static string GetDbProvider()
        {
            //return ConfigurationManager.ConnectionStrings["SERVER=(local);DATABASE=BD_SPV;USER=JuniorJava;PASSWORD=Sulca@8524"].ProviderName;
            return ConfigurationManager.ConnectionStrings["SPVConecctionString"].ProviderName;
        }

        public static string GetDbConnectionString()
        {
            //return ConfigurationManager.ConnectionStrings["SERVER=(local);DATABASE=BD_SPV;USER=JuniorJava;PASSWORD=Sulca@8524"].ConnectionString;
            return ConfigurationManager.ConnectionStrings["SPVConecctionString"].ConnectionString;
        }
    }
}