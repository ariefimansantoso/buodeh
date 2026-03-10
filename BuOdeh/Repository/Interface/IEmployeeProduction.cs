using BuOdeh.Data.HrPayroll;

namespace BuOdeh.Repository.Interface
{
    public interface IEmployeeProduction
    {
        Task<List<EmployeeProduction>> GetAll();
        Task<EmployeeProduction> GetById(int id);
        Task<List<EmployeeProduction>> GetByEmployeeId(int employeeId);
        Task<List<EmployeeProduction>> GetByDateRange(int employeeId, DateTime startDate, DateTime endDate);
        Task<int> Insert(EmployeeProduction employeeProduction);
        Task<int> Update(EmployeeProduction employeeProduction);
        Task<int> Delete(int id);
    }
}