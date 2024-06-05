using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI.Interfaces
{
    public interface IManagerService
    {
        Task<Manager> AddManagerAsync(Manager manager);
        Task<Manager> GetManagerByIdAsync(string uId);
        Task<bool> UpdateManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(string uId);
    }
}
