using BuOdeh.Data;
using BuOdeh.Data.Setting;
using BuOdeh.Repository.Interface;

namespace BuOdeh.Repository.Repository
{
    public class GeneralService : IGeneralSetting
    {
        private readonly ApplicationDbContext _context;
        public GeneralService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralSetting> GetbyId(int id)
        {
            GeneralSetting model = await _context.GeneralSetting.FindAsync(id);
            return model;
        }

        public async Task<bool> Update(GeneralSetting model)
        {
            _context.GeneralSetting.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
