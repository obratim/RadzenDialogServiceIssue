using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using RadzenDialogServiceIssue.Client;

namespace RadzenDialogServiceIssue.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


            builder.Services
                .AddScoped<DialogService>()
                .AddScoped<NotificationService>()
                .AddScoped<TooltipService>()
                .AddScoped<ContextMenuService>();

            await builder.Build().RunAsync();
        }
    }
}