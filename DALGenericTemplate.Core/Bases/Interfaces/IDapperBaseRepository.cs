using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.Bases.Interfaces
{
    public interface IDapperBaseRepository
    {
        IEnumerable<T> GetList<T>(string query);
        T Get<T>(string query);
    }
}
