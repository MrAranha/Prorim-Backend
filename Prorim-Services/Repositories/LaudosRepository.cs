using Dapper;
using DbExtensions;
using Prorim_MediatrHandling.Entities;
using Prorim_Services.Services;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;

namespace Prorim_Services.Repositories
{
    public class LaudosRepository : ILaudosRepository
    {
        private readonly DbSession _session;

        public LaudosRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<TB_Laudos> GetByID(int id)
        {
            var result = await _session.Connection.QueryFirstOrDefaultAsync<TB_Laudos>(
                "SELECT * FROM TB_Laudos WHERE id = @id",
                new { id },
                _session.Transaction);
            return result;
        }

        public async Task<IEnumerable<TB_Laudos>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Laudos>(
                "SELECT * FROM TB_Laudos",
                null,
                _session.Transaction);
            return result;
        }

        public async Task<int> Add(TB_Laudos laudo)
        {
            var sql = @"INSERT INTO TB_Laudos (nomeMedico, pdf, nomeArquivo, idPaciente)
                        VALUES (@nomeMedico, @pdf, @nomeArquivo, @idPaciente);
                        SELECT LAST_INSERT_ID();";

            var id = await _session.Connection.ExecuteScalarAsync<int>(
                sql,
                laudo,
                _session.Transaction);
            return id;
        }

        public async Task<bool> Edit(TB_Laudos laudo)
        {
            var query = new SqlBuilder()
                .UPDATE("TB_Laudos")
                .SET("nomeMedico = @nomeMedico")
                .SET("pdf = @pdf")
                .SET("nomeArquivo = @nomeArquivo")
                .SET("idPaciente = @idPaciente")
                .WHERE("id = @id")
                .ToString();

            var affectedRows = await _session.Connection.ExecuteAsync(
                query,
                laudo,
                _session.Transaction);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _session.Connection.ExecuteAsync(
                "DELETE FROM TB_Laudos WHERE id = @id",
                new { id },
                _session.Transaction);
            return result > 0;
        }
    }
}
