using Fintech.Shared;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }

        private static List<Security> Securities = new List<Security>();

        protected override async Task OnInitializedAsync()
        {
            await SecurityService.GetSecurities();
        }
    }
}
