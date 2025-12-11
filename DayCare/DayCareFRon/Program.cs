
using DayCareFRon;
using DayCareFRon.Frontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddScoped<ChildService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<TutorService>();


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7174")
});
builder.Services.AddSingleton<ApiConfig>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new ApiConfig { ApiBaseUrl = config["ApiBaseUrl"]! };
});


await builder.Build().RunAsync();
