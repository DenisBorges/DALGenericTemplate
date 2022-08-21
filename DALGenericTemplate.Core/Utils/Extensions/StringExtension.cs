using DALGenericTemplate.Core.Utils.Attributes;
using DALGenericTemplate.Core.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.Utils.Extensions
{
    public static class StringExtension
    {
        public static EnumProvider GetDBProvider(this string providerName)
        {
            var provider = EnumProvider.Oracle;

            if (providerName.ToLower() == EnumProvider.Oracle.GetAttribute<ProviderAttribute>().Name)
                provider = EnumProvider.Oracle;

            return provider;
        }

        public static string GetSettings(this string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
