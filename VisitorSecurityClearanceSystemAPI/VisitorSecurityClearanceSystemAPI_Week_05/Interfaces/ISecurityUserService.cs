using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI.Interfaces
{
    public interface ISecurityUserService
    {
        Task<SecurityUser> AddSecurityUserAsync(SecurityUser securityUser);
        Task<SecurityUser> GetSecurityUserByIdAsync(string uId);
        Task<bool> UpdateSecurityUserAsync(SecurityUser securityUser);
        Task<bool> DeleteSecurityUserAsync(string uId);
    }
}
