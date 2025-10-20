using BuOdeh.Data.HrPayroll;
using BuOdeh.Data.HrPayrollModel;

namespace BuOdeh.Repository.Interface
{
    public interface IPayHead
	{
        Task<List<PayHeadView>> GetAll();
       Task<bool> CheckName(string name);
       Task<int> CheckNameId(string name);
        Task<int> Save(PayHead model);
        Task<bool> Update(PayHead model);
        Task<PayHead> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
