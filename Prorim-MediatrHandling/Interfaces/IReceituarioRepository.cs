using Prorim_MediatrHandling.Entities;
using Prorim_Services.Entities;

namespace Prorim_MediatrHandling.Interfaces
{
    public interface IReceituarioRepository
    {
        Task<TB_Receituario> GetByID(int id);
        Task<IEnumerable<TB_Receituario>> GetAll();
        Task<int> Add(TB_Receituario lembrete);
        Task<bool> Edit(TB_Receituario lembrete);
        Task<bool> Delete(int id);
    }
}