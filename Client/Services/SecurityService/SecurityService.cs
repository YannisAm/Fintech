using Fintech.Shared.Models;

namespace Fintech.Client.Services.SecurityService
{
    public class SecurityService : ISecurityService
    {
        private readonly HttpClient _http;

        public SecurityService(HttpClient http)
        {
            _http = http;
        }

        public List<Security> Securities { get; set; } = new List<Security>();
        public string Message { get; set; } = "Loading security...";

        public async Task<Security?> GetSecurityById(int id)
        {
            var result = await _http.GetAsync($"api/security/{id}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<ServiceResponse<Security>>();
                if (response != null)
                    return response.Data;
            }
            return null;
        }

        public async Task<List<Security>> GetSecurities()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Security>>>("api/security");
            if (result != null && result.Data != null)
                return result.Data;
            return new List<Security>();
        }

        public async Task CreateSecurity(Security security)
        {
            var response = await _http.PostAsJsonAsync("api/security", security);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {

                }
            }
        }

        public async Task EditSecurity(Security security)
        {
            var response = await _http.PutAsJsonAsync("api/security", security);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {
                    //na epistrefei kati apo to ServiceResponse, ena minima ktl wste na to emfanizoyme ston xristi
                }
            }
        }

        public async Task DeleteSecurity(int securityId)
        {
            var response = await _http.DeleteAsync($"api/security/{securityId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task SearchSecurity(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Security>>>($"api/security/search/{searchText}");
            if (result != null && result.Data != null)
                Securities = result.Data;
            if (Securities.Count == 0)
                Message = "No securities found.";
        }

        public async Task<List<string>> GetSecuritySearchSuggestion(string searchTextSuggestion)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/security/search/{searchTextSuggestion}");
            return result.Data;
        }
    }
}
