using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_Services.Interfaces
{
    public interface IFbSoftQuery
    {
        Task<T> GetFirstAsync<T>(string query, object?[] parameters);
        Task<List<T>> GetListAsync<T>(string query, object?[] parameters);
        Task<IEnumerable<T>> GetPagedAsync<T>(string query, object?[] parameters);
    }
}
