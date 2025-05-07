using Dapper;
using DbExtensions;
using FbSoft_Services.Services;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FbSoft_Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSession _session;

        public UserRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<TB_Users> GetByEmail(string email)
        {
            var result = await _session.Connection.QueryFirstOrDefaultAsync<TB_Users>("SELECT * FROM TB_Users where email = @email", new { email = email }, _session.Transaction);
            return result;
        }
        public async Task<TB_Users> GetByID(string id)
        {
            var result = await _session.Connection.QueryFirstAsync<TB_Users>("SELECT * FROM TB_Users where id = @id", new { id = id }, _session.Transaction);
            return result;
        }

        public async Task<IEnumerable<TB_Users>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Users>("SELECT * FROM TB_Users", null, _session.Transaction);
            return result;
        }

        public async Task<string> Add(TB_Users users)
        {
            await _session.Connection.ExecuteAsync("INSERT INTO TB_Users (ID, password, email, displayName, role) VALUES(@id, @password, @email, @nome, @role)",
                new { id = users.id, Nome = users.displayName, Email = users.email, Password = users.password, role = users.role }, _session.Transaction);
            return users.id;
        }
        public async Task<bool> Edit(TB_Users users)
        {
            var query = new SqlBuilder().UPDATE("TB_Users")
                .SET("id = @id")
                ._If(!users.displayName.IsNullOrEmpty(), "displayName = @displayName")
                ._If(!users.password.IsNullOrEmpty(), "password = @password")
                ._If(!users.email.IsNullOrEmpty(), "email = @email")
                ._If(!users.country.IsNullOrEmpty(), "country = @country")
                ._If(!users.city.IsNullOrEmpty(), "city = @city")
                ._If(!users.address.IsNullOrEmpty(), "address = @address")
                ._If(!users.state.IsNullOrEmpty(), "state = @state")
                ._If(!users.about.IsNullOrEmpty(), "about = @about")
                ._If(!users.zipCode.IsNullOrEmpty(), "zipCode = @zipCode")
                ._If(!users.role.IsNullOrEmpty(), "role = @role")
                .WHERE("id = @id").ToString();
            await _session.Connection.ExecuteAsync(query,
                new
                {
                    displayName = users.displayName,
                    email = users.email,
                    country = users.country,
                    city = users.city,
                    address = users.address,
                    state = users.state,
                    about = users.about,
                    zipCode = users.zipCode,
                    role = users.role,
                    id = users.id,
                    password = users.password
                }, _session.Transaction);
            return true;
        }
        public async Task<bool> Delete(string UserID)
        {
            await _session.Connection.ExecuteAsync("delete from TB_Users where id = @id", new { id = UserID }, _session.Transaction);
            return true;
        }
    }
}
