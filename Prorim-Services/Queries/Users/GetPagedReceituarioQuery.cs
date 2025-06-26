using Dapper;
using DbExtensions;
using Prorim_Services.Services;
using Prorim_MediatrHandling.EntityRequests.Receituario.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;

namespace Prorim_Services.Queries.Receituario
{
    public class GetPagedReceituarioQuery : IGetPagedReceituarioQuery
    {
        private readonly DbSession _session;

        public GetPagedReceituarioQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetReceituarioPagedResult>> Get(GetReceituarioPagedRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.nomeMedico))
            {
                request.nomeMedico = "%" + request.nomeMedico + "%";
            }

            if (!string.IsNullOrWhiteSpace(request.idPaciente))
            {
                request.idPaciente = "%" + request.idPaciente + "%";
            }

            if (!string.IsNullOrWhiteSpace(request.nomeReceita))
            {
                request.nomeReceita = "%" + request.nomeReceita + "%";
            }
            var query = new SqlBuilder()
                .SELECT("*")
                .FROM("TB_Receituario")
                .WHERE()
                ._If(!string.IsNullOrWhiteSpace(request.nomeMedico), "nomeMedico LIKE @nomeMedico")
                ._If(!string.IsNullOrWhiteSpace(request.nomeReceita), "nomeReceita LIKE @nomeReceita")
                ._If(!string.IsNullOrWhiteSpace(request.idPaciente), "idPaciente = @idPaciente")
                ._If(request.id is > 0, "id = @ID");

            return await _session.Connection.QueryAsync<GetReceituarioPagedResult>(
                query.ToString(),
                new
                {
                    nomeMedico = request.nomeMedico,
                    idPaciente = request.idPaciente,
                    nomeReceita = request.nomeReceita,
                    ID = request.id
                },
                _session.Transaction);
        }
    }
}