using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorSortableList.DemoApp.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var services = builder.Services;

            services.AddSingleton<IPersistenceSample, PersistenceSample>();

            await builder.Build().RunAsync();
        }
    }
}
