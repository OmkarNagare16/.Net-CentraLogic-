using VisitorSecurityClearanceSystemAPI.CosmosDBServices;
using VisitorSecurityClearanceSystemAPI.Interfaces;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI_Week_05.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ICosmosDBService _cosmosDBService;

        public  ManagerService()
        {
            _cosmosDBService = _cosmosDBService;
        }

        public async Task<Manager> AddManagerAsync(Manager manager)
        {
            return await _cosmosDBService.AddManagerAsync(manager);
        }

        public async Task<Manager> GetManagerByIdAsync(string uId)
        {
            return await _cosmosDBService.GetManagerByIdAsync(uId);
        }

        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            return await _cosmosDBService.UpdateManagerAsync(manager);
        }

        public async Task<bool> DeleteManagerAsync(string uId)
        {
            return await _cosmosDBService.DeleteManagerAsync(uId);
        }
    }
}
