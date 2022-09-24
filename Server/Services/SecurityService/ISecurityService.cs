using Fintech.Shared.Models;

namespace Fintech.Server.Services.SecurityService
{
    public interface ISecurityService
    {
        Task<ServiceResponse<List<Security>>> GetSecuritiesAsync();
        Task<ServiceResponse<int>> CreateSecurityAsync(Security security);
        Task<ServiceResponse<int>> EditSecurityAsync(Security security);
        
    }
}
