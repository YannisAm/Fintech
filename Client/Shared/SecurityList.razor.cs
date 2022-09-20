using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        private static List<Security> Securities = new List<Security>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<List<Security>>("api/security");
            if (result != null)
                Securities = result;
        }
    }
}
