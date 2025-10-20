using BuOdeh.Data.Inventory;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface ICurrency
    {
        Task<List<CurrencyView>> GetAll();
       Task<bool> CheckName(string name);
       Task<int> CheckNameId(string name);
        Task<int> Save(Currency model);
        Task<bool> Update(Currency model);
        Task<Currency> GetbyId(int id);
        Task<CurrencyView> GetCurrencyView(int id);
        Task<bool> Delete(int id);
    }
}
