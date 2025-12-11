using BlazorApp1;
using DayCareFRon;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddScoped<CustomerService>();
//builder.Services.AddScoped<VehicleService>();
//builder.Services.AddScoped<RepairService>();
//builder.Services.AddScoped<LookupService>();
//builder.Services.AddScoped<MechanicService>();
//builder.Services.AddScoped<SellerService>();
//builder.Services.AddScoped<SparePartService>();
//builder.Services.AddScoped<SaleService>();
//builder.Services.AddScoped<SaleDetailService>();



builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7019")
});
builder.Services.AddSingleton<ApiConfig>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new ApiConfig { ApiBaseUrl = config["ApiBaseUrl"]! };
});


await builder.Build().RunAsync();
