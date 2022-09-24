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

        public async Task GetSecurities()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Security>>>("api/security");
            if (result != null && result.Data != null)
                Securities = result.Data;
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
            var response = await _http.PostAsJsonAsync("api/security", security);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
                if (!(result?.Success ?? false))
                {

                }
            }
        }
    }
}
