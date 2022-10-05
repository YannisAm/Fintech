global using Fintech.Shared;
global using System.Net.Http.Json;
global using Fintech.Client.Services.SecurityService;
global using Fintech.Client.Services.PortfolioService;
using Fintech.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();

await builder.Build().RunAsync();
