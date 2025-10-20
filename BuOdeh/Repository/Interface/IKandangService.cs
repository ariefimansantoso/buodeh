using BuOdeh.Data.Recording;

namespace BuOdeh.Repository.Interface
{
    public interface IKandangService
    {
        Task<List<Kandang>> GetAll();
    }
}