using Dapper;
using DbExtensions;
using Prorim_Services.Services;
using Prorim_MediatrHandling.EntityRequests.Laudos.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;

namespace Prorim_Services.Queries.Laudos
{
    public class GetPagedLaudosQuery : IGetPagedLaudosQuery
    {
        private readonly DbSession _session;

        public GetPagedLaudosQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetLaudosPagedResult>> Get(GetLaudosPagedRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.nomeMedico))
            {
                request.nomeMedico = "%" + request.nomeMedico + "%";
            }


            var query = new SqlBuilder()
                .SELECT("*")
                .FROM("TB_Laudos")
                .WHERE()
                ._If(!string.IsNullOrWhiteSpace(request.nomeMedico), "nomeMedico LIKE @nomeLembrete")
                ._If(!string.IsNullOrWhiteSpace(request.idPaciente), "idPaciente = @idPaciente")
                ._If(request.id is > 0, "id = @ID");

            return await _session.Connection.QueryAsync<GetLaudosPagedResult>(
                query.ToString(),
                new
                {
                    nomeLembrete = request.nomeMedico,
                    clienteID = request.idPaciente,
                    ID = request.id
                },
                _session.Transaction);
        }
    }
}