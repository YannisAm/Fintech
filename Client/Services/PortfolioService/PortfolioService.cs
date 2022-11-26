using Fintech.Client.Pages;
using Fintech.Shared.Models;

namespace Fintech.Client.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _http;

        public PortfolioService(HttpClient http)
        {
            _http = http;
        }

        public List<Fintech.Shared.Models.Portfolio> Portfolios { get; set; } = new List<Fintech.Shared.Models.Portfolio>();
        public string Message { get; set; } = "Loading portfolio...";

        public async Task CreatePortfolio(Fintech.Shared.Models.Portfolio portfolio)
        {
            var response = await _http.PostAsJsonAsync("api/portfolio", portfolio);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {

                }
            }
        }

        public async Task DeletePortfolio(int portfolioId)
        {
            var response = await _http.DeleteAsync($"api/portfolio/{portfolioId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task EditPortfolio(Fintech.Shared.Models.Portfolio portfolio)
        {
            var response = await _http.PutAsJsonAsync("api/portfolio", portfolio);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {

                }
            }
        }

        public async Task<Fintech.Shared.Models.Portfolio?> GetPortfolioById(int portfolioid)
        {
            var result = await _http.GetAsync($"api/portfolio/{portfolioid}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<Fintech.Shared.Models.Portfolio>>();
                if (response != null)
                    return response.Data;
            }
            return null;
        }

        public async Task<Fintech.Shared.Models.Portfolio> GetPortfolioByName(string name)
        {
            var result = await _http.GetAsync($"api/find/portfolio/{name}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<Fintech.Shared.Models.Portfolio>>();
                if (response != null)
                    return response.Data;
            }
            return null;
        }

        public async Task<string> GetPortfolioNameBySecurity(Security security)
        {
            var result = await _http.GetAsync($"api/portfolio/kostas/giannis/{security}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
                if (response != null)
                    return response.Data;
            }
            return null;
        }

        public async Task<List<Fintech.Shared.Models.Portfolio>> GetPortfolios()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Fintech.Shared.Models.Portfolio>>>("api/portfolio");
            if (result != null && result.Data != null)
                return result.Data;
            return new List<Fintech.Shared.Models.Portfolio>();
        }
    }
}
