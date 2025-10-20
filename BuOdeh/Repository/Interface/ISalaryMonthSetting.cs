using BuOdeh.Data.HrPayroll;
using BuOdeh.Data.HrPayrollModel;
using BuOdeh.Data.Setting;

namespace BuOdeh.Repository.Interface
{
    public interface ISalaryMonthSetting
    {
        Task<List<MonthlySalarySettingView>> GetAll(string YearMonth);
        Task<List<MonthlySalary>> GetAllMonth();
        Task<bool> CheckName(string name);
        Task<int> CheckNameId(string name);
        Task<int> Save(MonthlySalary model);
        Task<MonthlySalary> GetbyId(int id);
        Task<bool> Delete(int id);
    }
}
