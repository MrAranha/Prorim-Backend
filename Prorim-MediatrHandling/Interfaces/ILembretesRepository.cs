using Prorim_Services.Entities;

namespace Prorim_MediatrHandling.Interfaces
{
    public interface ILembretesRepository
    {
        Task<TB_Lembretes> GetByID(int id);
        Task<IEnumerable<TB_Lembretes>> GetAll();
        Task<int> Add(TB_Lembretes lembrete);
        Task<bool> Edit(TB_Lembretes lembrete);
        Task<bool> Delete(int id);
    }
}