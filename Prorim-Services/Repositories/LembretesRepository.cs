using Dapper;
using DbExtensions;
using Prorim_Services.Services;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;

namespace Prorim_Services.Repositories
{
    public class LembretesRepository : ILembretesRepository
    {
        private readonly DbSession _session;

        public LembretesRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<TB_Lembretes> GetByID(int id)
        {
            var result = await _session.Connection.QueryFirstOrDefaultAsync<TB_Lembretes>(
                "SELECT * FROM TB_Lembretes WHERE id = @id",
                new { id },
                _session.Transaction);
            return result;
        }

        public async Task<IEnumerable<TB_Lembretes>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Lembretes>(
                "SELECT * FROM TB_Lembretes",
                null,
                _session.Transaction);
            return result;
        }

        public async Task<int> Add(TB_Lembretes lembrete)
        {
            var sql = @"INSERT INTO TB_Lembretes (nomeLembrete, DataLembrete, clienteID, tipoTransplante, remedio)
                        VALUES (@nomeLembrete, @DataLembrete, @clienteID, @tipoTransplante, @remedio);
                        SELECT LAST_INSERT_ID();";

            var id = await _session.Connection.ExecuteScalarAsync<int>(
                sql,
                lembrete,
                _session.Transaction);
            return id;
        }

        public async Task<bool> Edit(TB_Lembretes lembrete)
        {
            var query = new SqlBuilder()
                .UPDATE("TB_Lembretes")
                .SET("nomeLembrete = @nomeLembrete")
                .SET("DataLembrete = @DataLembrete")
                .SET("clienteID = @clienteID")
                .SET("tipoTransplante = @tipoTransplante")
                .SET("remedio = @remedio")
                .WHERE("id = @id")
                .ToString();

            var affectedRows = await _session.Connection.ExecuteAsync(
                query,
                lembrete,
                _session.Transaction);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _session.Connection.ExecuteAsync(
                "DELETE FROM TB_Lembretes WHERE id = @id",
                new { id },
                _session.Transaction);
            return result > 0;
        }
    }
}
