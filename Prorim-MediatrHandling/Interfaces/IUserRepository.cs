using FbSoft_Services.Entities;

namespace FbSoft_MediatrHandling.Interfaces
{
    public interface IUserRepository
    {
        public Task<TB_Users> GetByEmail(string email);
        public Task<IEnumerable<TB_Users>> GetAll();
        public Task<string> Add(TB_Users add);
        public Task<TB_Users> GetByID(string id);
        public Task<bool> Delete(string UserID);
        public Task<bool> Edit(TB_Users edit);
    }
}