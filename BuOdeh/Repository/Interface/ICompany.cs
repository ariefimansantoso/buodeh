using BuOdeh.Data.Inventory;
using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface ICompany
    {
        Task<bool> Update(Company model);
        Task<Company> GetbyId(int id);
    }
}
