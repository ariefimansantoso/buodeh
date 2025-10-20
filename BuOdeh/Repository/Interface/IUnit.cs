using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface IUnit
    {
        Task<List<UnitView>> GetAll();
       Task<bool> CheckName(string name);
       Task<int> CheckNameId(string name);
        Task<int> Save(Unit model);
        Task<bool> Update(Unit model);
        Task<Unit> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
