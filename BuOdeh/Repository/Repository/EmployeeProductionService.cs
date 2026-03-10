using BuOdeh.Data;
using BuOdeh.Data.HrPayroll;
using BuOdeh.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BuOdeh.Repository.Repository
{
    public class EmployeeProductionService : IEmployeeProduction
    {
        private readonly ApplicationDbContext _context;

        public EmployeeProductionService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all non-deleted employee production records
        /// </summary>
        public async Task<List<EmployeeProduction>> GetAll()
        {
            try
            {
                return await _context.EmployeeProduction
                    .Where(ep => ep.IsDeleted == false)
                    .OrderByDescending(ep => ep.InputDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee production records: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get a single production record by ID
        /// </summary>
        public async Task<EmployeeProduction> GetById(int id)
        {
            try
            {
                return await _context.EmployeeProduction
                    .Where(ep => ep.ID == id && ep.IsDeleted == false)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving production record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get all production records for a specific employee
        /// </summary>
        public async Task<List<EmployeeProduction>> GetByEmployeeId(int employeeId)
        {
            try
            {
                return await _context.EmployeeProduction
                    .Where(ep => ep.EmployeeID == employeeId && ep.IsDeleted == false)
                    .OrderByDescending(ep => ep.InputDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employee production records: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get production records for an employee within a date range
        /// </summary>
        public async Task<List<EmployeeProduction>> GetByDateRange(int employeeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _context.EmployeeProduction
                    .Where(ep => ep.EmployeeID == employeeId 
                        && ep.InputDate >= startDate 
                        && ep.InputDate <= endDate
                        && ep.IsDeleted == false)
                    .OrderByDescending(ep => ep.InputDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving production records for date range: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Insert a new production record
        /// </summary>
        public async Task<int> Insert(EmployeeProduction employeeProduction)
        {
            try
            {
                employeeProduction.DateCreated = DateTime.Now;
                employeeProduction.IsDeleted = false;

                _context.EmployeeProduction.Add(employeeProduction);
                await _context.SaveChangesAsync();

                return employeeProduction.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting production record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing production record
        /// </summary>
        public async Task<int> Update(EmployeeProduction employeeProduction)
        {
            try
            {
                var existing = await _context.EmployeeProduction.FindAsync(employeeProduction.ID);
                if (existing == null)
                    throw new Exception("Production record not found.");

                existing.EmployeeID = employeeProduction.EmployeeID;
                existing.InputDate = employeeProduction.InputDate;
                existing.NumberProduced = employeeProduction.NumberProduced;

                _context.EmployeeProduction.Update(existing);
                await _context.SaveChangesAsync();

                return existing.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating production record: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Soft delete a production record (mark as deleted)
        /// </summary>
        public async Task<int> Delete(int id)
        {
            try
            {
                var record = await _context.EmployeeProduction.FindAsync(id);
                if (record == null)
                    throw new Exception("Production record not found.");

                record.IsDeleted = true;

                _context.EmployeeProduction.Update(record);
                await _context.SaveChangesAsync();

                return record.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting production record: {ex.Message}", ex);
            }
        }
    }
}