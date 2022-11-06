﻿using Fintech.Shared.Models;

namespace Fintech.Server.Services.SecurityService
{
    public interface ISecurityService
    {
        Task<ServiceResponse<List<Security>>> GetSecuritiesAsync();
        Task<ServiceResponse<Security>> GetSecurityByIdAsync(int id);
        Task<ServiceResponse<int>> CreateSecurityAsync(Security security);
        Task<ServiceResponse<int>> CreateSecurityWithPortfolioAsync(Security security, Portfolio portfolio);
        Task<ServiceResponse<int>> EditSecurityAsync(Security security);
        Task<ServiceResponse<int>> DeleteSecurityAsync(int securityId);
        Task<ServiceResponse<List<Security>>> SearchSecurity(string searchText);
        Task<ServiceResponse<List<string>>> GetSecuritySearchSuggestion(string searchText);

    }
}
