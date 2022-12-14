using Fintech.Shared.Models;

namespace Fintech.Server.Services.SecurityService
{
    public interface ISecurityService
    {
        Task<ServiceResponse<List<Security>>> GetSecuritiesAsync(string email);
        Task<ServiceResponse<Security>> GetSecurityByIdAsync(int id);
        Task<ServiceResponse<int>> CreateSecurityAsync(Security security);
        Task<ServiceResponse<int>> EditSecurityAsync(Security security);
        Task<ServiceResponse<int>> DeleteSecurityAsync(int securityId);
    }
}
