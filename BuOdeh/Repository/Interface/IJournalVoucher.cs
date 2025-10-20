using BuOdeh.Data.AccountModel;
using BuOdeh.Data.Inventory;
using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;
using System.Threading.Tasks;

namespace BuOdeh.Repository.Interface
{
    public interface IJournalVoucher
    {
        Task<IList<JournalMasterView>> GetAll(DateTime dtFromDate , DateTime dtToDate , string voucherNo);
        Task<JournalMasterView> JournalView(int id);
        Task<IList<JournalDetailsView>> JournalDetailsView(int id);
        Task<int> Save(JournalMaster model);
        Task<bool> ApprovedOk(JournalMaster model);
        Task<bool> Update(JournalMaster model);
        Task<JournalMaster> GetbyId(int id);
        Task<string> GetSerialNo();
        Task<bool> Delete(JournalMaster model);
        decimal CheckLedgerBalance(int LedgerId);
    }
}
