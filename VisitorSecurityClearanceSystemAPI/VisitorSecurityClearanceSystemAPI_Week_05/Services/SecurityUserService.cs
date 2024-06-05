using System.Threading.Tasks;
using VisitorSecurityClearanceSystemAPI.CosmosDBServices;
using VisitorSecurityClearanceSystemAPI.Interfaces;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;
using VisitorSecurityClearanceSystemAPI_Week_05.Interfaces;

namespace VisitorSecurityClearanceSystemAPI_Week_05.Services
{
    public class SecurityUserService : ISecurityUserService
    {
        private readonly ICosmosDBService _cosmosDBService;

        public SecurityUserService()
        {
            _cosmosDBService = _cosmosDBService;
        }

        public async Task<SecurityUser> AddSecurityUserAsync(SecurityUser securityUser)
        {
            return await _cosmosDBService.AddSecurityUserAsync(securityUser);
        }

        public async Task<SecurityUser> GetSecurityUserByIdAsync(string uId)
        {
            return await _cosmosDBService.GetSecurityUserByIdAsync(uId);
        }

        public async Task<bool> UpdateSecurityUserAsync(SecurityUser securityUser)
        {
            return await _cosmosDBService.UpdateSecurityUserAsync(securityUser);
        }

        public async Task<bool> DeleteSecurityUserAsync(string uId)
        {
            return await _cosmosDBService.DeleteSecurityUserAsync(uId);
        }
    }
}
