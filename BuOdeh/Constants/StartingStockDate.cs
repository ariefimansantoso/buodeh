
using BuOdeh.Data;
using BuOdeh.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BuOdeh.Constants
{
    public class StartingStockDate : IStartingStockDate
    {
        private readonly ApplicationDbContext _context;

        public StartingStockDate(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DateTime> Get()
        {
            
            return new DateTime(1990,1,1);
        }

        public DateTime GetSync()
        {
            
            return new DateTime(1990, 1, 1);
        }

        public static DateTime StockDate = new DateTime(2025, 1, 29, 0, 0, 0);
    }

    public interface IStartingStockDate
    {
        Task<DateTime> Get();
        DateTime GetSync();
    }
}
