using BuOdeh.Data.HrPayroll;
using BuOdeh.Data.Inventory;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface ITaskCategory
    {
        Task<List<TaskCategoryView>> GetAll();
       Task<bool> CheckName(string name);
       Task<int> CheckNameId(string name);
        Task<int> Save(TaskCategory model);
        Task<bool> Update(TaskCategory model);
        Task<TaskCategory> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
