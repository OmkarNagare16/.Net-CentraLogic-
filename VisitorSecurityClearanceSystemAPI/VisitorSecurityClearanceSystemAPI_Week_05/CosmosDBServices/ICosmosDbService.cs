using VisitorSecurityClearanceSystemAPI.Entities;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI.CosmosDBServices
{
    public interface ICosmosService
    {

        // Manager curd 
        Task<Manager> AddManagerAsync(Manager manager);
        Task<Manager> GetManagerByIdAsync(string uId);
        Task<bool> UpdateManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(string uId);


        // Office UserCurd 

        Task<OfficeUser> AddOfficeUserAsync(OfficeUser officeUser);
        Task<OfficeUser> GetOfficeUserByIdAsync(string uId);
        Task<bool> UpdateOfficeUserAsync(OfficeUser officeUser);
        Task<bool> DeleteOfficeUserAsync(string uId);


        // Security 
        Task<SecurityUser> AddSecurityUserAsync(SecurityUser securityUser);
        Task<SecurityUser> GetSecurityUserByIdAsync(string uId);
        Task<bool> UpdateSecurityUserAsync(SecurityUser securityUser);
        Task<bool> DeleteSecurityUserAsync(string uId);

        // visitor
        Task<Visitor> AddItemAsync(Visitor item);
        Task<Visitor> GetItemAsync(string id);
        Task<bool> UpdateItemAsync(string id, Visitor item);
        Task<bool> DeleteItemAsync(string id);

    }
}
