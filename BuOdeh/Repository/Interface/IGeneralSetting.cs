using BuOdeh.Data.Setting;

namespace BuOdeh.Repository.Interface
{
    public interface IGeneralSetting
    {
        Task<bool> Update(GeneralSetting model);
        Task<GeneralSetting> GetbyId(int id);
    }
}
