using Dapper;
using FbSoft_Services.Interfaces;

namespace FbSoft_Services.Services
{
    public class DottaQuery : IFbSoftQuery
    {
        private DbSession _session;

        public DottaQuery(DbSession session)
        {
            _session = session;
        }
        public async Task<T> GetFirstAsync<T>(string query, object?[] parameters)
        {
            return await _session.Connection.QueryFirstAsync<T>(query, parameters, _session.Transaction);
        }
        public async Task<List<T>> GetListAsync<T>(string query, object?[] parameters)
        {
            return (await _session.Connection.QueryAsync<T>(query, parameters, _session.Transaction)).ToList();
        }

        //TODO
        // FAZER PAGESIZE E PAGECOUNT ALTERAREM A QUERY COM OFFSET E OFFROW
        // SE FODA :D
        public async Task<IEnumerable<T>> GetPagedAsync<T>(string query, object?[] parameters)
        {
            return await _session.Connection.QueryAsync<T>(query, parameters, _session.Transaction);
        }
    }
}