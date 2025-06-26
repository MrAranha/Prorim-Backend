using Prorim_MediatrHandling.Entities;
using Prorim_Services.Entities;

namespace Prorim_MediatrHandling.Interfaces
{
    public interface ILaudosRepository
    {
        Task<TB_Laudos> GetByID(int id);
        Task<IEnumerable<TB_Laudos>> GetAll();
        Task<int> Add(TB_Laudos lembrete);
        Task<bool> Edit(TB_Laudos lembrete);
        Task<bool> Delete(int id);
    }
}