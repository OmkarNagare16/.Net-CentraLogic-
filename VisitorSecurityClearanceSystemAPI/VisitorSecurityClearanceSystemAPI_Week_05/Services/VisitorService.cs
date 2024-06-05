using Nest;
using VisitorSecurityClearanceSystemAPI_Week_05.Entities;
using VisitorSecurityClearanceSystemAPI_Week_05.Interfaces;

namespace VisitorSecurityClearanceSystemAPI.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IRepository<Visitor> _visitorRepository;

        public VisitorService(IRepository<Visitor> visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<Visitor> RegisterVisitorAsync(Visitor visitor)
        {
            return await _visitorRepository.AddAsync(visitor);
        }

        public async Task<Visitor> GetVisitorByIdAsync(string id)
        {
            return await _visitorRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateVisitorAsync(Visitor visitor)
        {
            return await _visitorRepository.UpdateAsync(visitor);
        }

        public async Task<bool> DeleteVisitorAsync(string id)
        {
            return await _visitorRepository.DeleteAsync(id);
        }
    }
}
