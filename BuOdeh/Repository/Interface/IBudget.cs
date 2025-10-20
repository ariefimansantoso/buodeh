using BuOdeh.Data.AccountModel;
using BuOdeh.Data.BudgetModel;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface IBudget
	{
        Task<IList<BudgetMaster>> GetAll(DateTime dtFromDate , DateTime dtToDate , string voucherNo);
		Task<IList<BudgetVariance>> GetBudgetVariance(int budgetmasterId);
		Task<IList<BudgetMaster>> GetAllBudget();

        Task<IList<BudgetDetailsView>> BudgetDetailsView(int id);
        Task<int> Save(BudgetMaster model);
        Task<bool> ApprovedOk(BudgetMaster model);
        Task<bool> Update(BudgetMaster model);
        Task<BudgetMaster> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
