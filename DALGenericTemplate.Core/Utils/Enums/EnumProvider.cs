using DALGenericTemplate.Core.Utils.Attributes;

namespace DALGenericTemplate.Core.Utils.Enums
{
    public enum EnumProvider
    {
        [Provider("Oracle.DataAccess.Client")]
        Oracle = 1,
        [Provider("System.Data.SqlClient")]
        SqlServer = 2
    }
}
