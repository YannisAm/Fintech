using Fintech.Shared.Models;

namespace Fintech.Client.Services.SecurityService
{
    public interface ISecurityService
    {
        List<Security> Securities { get; set; }
        Task GetSecurities();
        Task CreateSecurity(Security security);
        Task EditSecurity(Security security);
    }
}
