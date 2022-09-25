using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Fintech.Client.Shared
{
    public partial class Search : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();
        protected ElementReference searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }
        
        public void SearchSecurity()
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if(args.Key == null || args.Key.Equals("Enter"))
            {
                SearchSecurity();
            }
            else if(searchText.Length > 1)
            {
                suggestions = await SecurityService.GetSecuritySearchSuggestion(searchText);
            }
        }
    }
}
