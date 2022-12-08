global using Fintech.Client.Services.PortfolioService;
global using Fintech.Client.Services.SecurityService;
global using Fintech.Client.Services.AuthService;
global using System.Net.Http.Json;
global using Blazored.LocalStorage;
using Fintech.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
