using System.Threading.Tasks;

namespace VisitorSecurityClearanceSystemAPI.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string username, string password);
    }
}
