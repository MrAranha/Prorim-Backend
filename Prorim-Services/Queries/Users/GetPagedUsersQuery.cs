using Dapper;
using DbExtensions;
using DevExpress.Mvvm.Native;
using Prorim_Services.Services;
using Prorim_MediatrHandling.EntityRequests.Users.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Users.Requests;
using Prorim_MediatrHandling.EntityRequests.Users.Results;
using Prorim_MediatrHandling.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http.Headers;

namespace Prorim_Services.Queries.Users
{
    public class GetPagedUsersQuery : IGetPagedUsersQuery
    {
        private DbSession _session;
        public GetPagedUsersQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetUserPagedResult>> Get(GetUserPagedRequest request)
        {
            if (!request.Nome.IsNullOrEmpty())
            {
                request.Nome = "%" + request.Nome + "%";
            }
            if (!request.Email.IsNullOrEmpty())
            {
                request.Email = "%" + request.Email + "%";
            }
            var query = new SqlBuilder().SELECT("*").FROM("TB_Users")
                .WHERE()
                ._If(!request.Nome.IsNullOrEmpty(), "displayName LIKE @Nome")
                ._If(!request.Email.IsNullOrEmpty(), "email LIKE @Email")
                ._If(!request.id.IsNullOrEmpty(), "id = @id")
                ._If(!request.Empresa.IsNullOrEmpty(), "Empresa = @Empresa");

            return await _session.Connection.QueryAsync<GetUserPagedResult>(query.ToString(),
                new { Nome = request.Nome, Email = request.Email, Empresa = request.Empresa, id = request.id },
                _session.Transaction);
        }
    }
}
