﻿using Fintech.Shared.Models;
using System.Net.Http.Json;

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

                }
            }
        }

        
    }
}
