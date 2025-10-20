using Microsoft.EntityFrameworkCore;
using BuOdeh.Data;
using BuOdeh.Data.Recording;
using BuOdeh.Repository.Interface;

namespace BuOdeh.Repository.Repository
{
    public class KandangService : IKandangService
    {
        private readonly ApplicationDbContext _context;

        public KandangService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Kandang>> GetAll()
        {
            return await _context.Kandang.ToListAsync();
        }
    }
}
