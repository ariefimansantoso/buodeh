using BuOdeh.Data.Setting;
using BuOdeh.Data.ViewModel;

namespace BuOdeh.Repository.Interface
{
    public interface IEmailSetting
    {
        Task<bool> Update(EmailSetting model);
        Task<EmailSetting> GetbyId(int id);
    }
}
