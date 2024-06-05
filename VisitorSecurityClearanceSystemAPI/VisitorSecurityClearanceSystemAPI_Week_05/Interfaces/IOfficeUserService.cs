using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI.Interfaces
{
    public interface IOfficeUserService
    {
        Task<OfficeUser> AddOfficeUserAsync(OfficeUser officeUser);
        Task<OfficeUser> GetOfficeUserByIdAsync(string uId);
        Task<bool> UpdateOfficeUserAsync(OfficeUser officeUser);
        Task<bool> DeleteOfficeUserAsync(string uId);
    }
}
