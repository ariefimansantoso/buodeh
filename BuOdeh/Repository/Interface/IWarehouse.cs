using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface IWarehouse
    {
        Task<List<WarehouseView>> GetAll();
       Task<bool> CheckName(string name);
       Task<int> CheckNameId(string name);
        Task<int> Save(Warehouse model);
        Task<bool> Update(Warehouse model);
        Task<Warehouse> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
