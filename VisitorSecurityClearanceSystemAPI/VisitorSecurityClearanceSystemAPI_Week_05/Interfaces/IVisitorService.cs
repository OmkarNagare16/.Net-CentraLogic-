using VisitorSecurityClearanceSystemAPI_Week_05.Entities;

namespace VisitorSecurityClearanceSystemAPI_Week_05.Interfaces
{
    public class IVisitorService
    {
        Task<Visitor> RegisterVisitorAsync(Visitor visitor);
        Task<Visitor> GetVisitorByIdAsync(string id);
        Task<bool> UpdateVisitorAsync(Visitor visitor);
        Task<bool> DeleteVisitorAsync(string id);
    }
}
