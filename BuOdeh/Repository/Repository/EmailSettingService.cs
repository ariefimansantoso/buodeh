using Microsoft.EntityFrameworkCore;
using BuOdeh.Data;
using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;
using BuOdeh.Repository.Interface;

namespace BuOdeh.Repository.Repository
{
    public class EmailSettingService : IEmailSetting
    {
        private readonly ApplicationDbContext _context;
        public EmailSettingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<EmailSetting> GetbyId(int id)
        {
            EmailSetting model = await _context.EmailSetting.FindAsync(id);
            return model;
        }

        public async Task<bool> Update(EmailSetting model)
        {
            _context.EmailSetting.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
