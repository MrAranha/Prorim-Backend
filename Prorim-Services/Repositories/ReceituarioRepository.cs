using Dapper;
using DbExtensions;
using Prorim_MediatrHandling.Entities;
using Prorim_Services.Services;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;

namespace Prorim_Services.Repositories
{
    public class ReceituarioRepository : IReceituarioRepository
    {
        private readonly DbSession _session;

        public ReceituarioRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<TB_Receituario> GetByID(int id)
        {
            var result = await _session.Connection.QueryFirstOrDefaultAsync<TB_Receituario>(
                "SELECT * FROM TB_Receituario WHERE id = @id",
                new { id },
                _session.Transaction);
            return result;
        }

        public async Task<IEnumerable<TB_Receituario>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Receituario>(
                "SELECT * FROM TB_Receituario",
                null,
                _session.Transaction);
            return result;
        }

        public async Task<int> Add(TB_Receituario receita)
        {
            var sql = @"INSERT INTO TB_Receituario (nomeMedico, nomeReceita, pdf, nomeArquivo, idPaciente)
                        VALUES (@nomeMedico, @nomeReceita, @pdf, @nomeArquivo, @idPaciente);
                        SELECT LAST_INSERT_ID();";

            var id = await _session.Connection.ExecuteScalarAsync<int>(
                sql,
                receita,
                _session.Transaction);
            return id;
        }

        public async Task<bool> Edit(TB_Receituario receita)
        {
            var query = new SqlBuilder()
                .UPDATE("TB_Receituario")
                .SET("nomeMedico = @nomeMedico")
                .SET("nomeReceita = @nomeReceita")
                .SET("pdf = @pdf")
                .SET("nomeArquivo = @nomeArquivo")
                .SET("idPaciente = @idPaciente")
                .WHERE("id = @id")
                .ToString();

            var affectedRows = await _session.Connection.ExecuteAsync(
                query,
                receita,
                _session.Transaction);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _session.Connection.ExecuteAsync(
                "DELETE FROM TB_Receituario WHERE id = @id",
                new { id },
                _session.Transaction);
            return result > 0;
        }
    }
}
