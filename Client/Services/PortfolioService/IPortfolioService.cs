using Fintech.Shared.Models;

namespace Fintech.Client.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetPortfolios();
        Task<Portfolio?> GetPortfolioById(int portfolioid);
        Task<Portfolio> GetPortfolioByName(string name);
        Task CreatePortfolio(Portfolio portfolio);
        Task EditPortfolio(Portfolio portfolio);
        Task DeletePortfolio(int portfolioId);
        Task<string> GetPortfolioNameBySecurity(Security security);
        string Message { get; set; } //to display if no portfolio was to be found
    }
}
