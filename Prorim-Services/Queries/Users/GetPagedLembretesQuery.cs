using Dapper;
using DbExtensions;
using Prorim_Services.Services;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;

namespace Prorim_Services.Queries.Lembretes
{
    public class GetPagedLembretesQuery : IGetPagedLembretesQuery
    {
        private readonly DbSession _session;

        public GetPagedLembretesQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetLembretesPagedResult>> Get(GetLembretesPagedRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.nomeLembrete))
            {
                request.nomeLembrete = "%" + request.nomeLembrete + "%";
            }

            if (!string.IsNullOrWhiteSpace(request.clienteID))
            {
                request.clienteID = "%" + request.clienteID + "%";
            }

            var query = new SqlBuilder()
                .SELECT("*")
                .FROM("TB_Lembretes")
                .WHERE()
                ._If(!string.IsNullOrWhiteSpace(request.nomeLembrete), "nomeLembrete LIKE @nomeLembrete")
                ._If(!string.IsNullOrWhiteSpace(request.clienteID), "clienteID LIKE @clienteID")
                ._If(request.id is > 0, "id = @ID");

            return await _session.Connection.QueryAsync<GetLembretesPagedResult>(
                query.ToString(),
                new
                {
                    nomeLembrete = request.nomeLembrete,
                    clienteID = request.clienteID,
                    ID = request.id
                },
                _session.Transaction);
        }
    }
}