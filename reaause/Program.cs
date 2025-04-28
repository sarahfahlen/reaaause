using reaause.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using reaause;
using reaause.Services.Advertisment;
using reaause.Services.Facilities;
using reaause.Services.Facility;
using reaause.Services.Login;
using reaause.Services.Purchase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5097") 
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAdvertisementService, AdvertisementServiceServer>();

builder.Services.AddScoped<ILoginService, LoginServiceServer>(); 

builder.Services.AddScoped<IPurchaseService, PurchaseServiceServer>();

builder.Services.AddScoped<IFacilityService, FacilityServiceServer>();


await builder.Build().RunAsync();