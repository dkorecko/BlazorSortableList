using BlazorSortableList.DemoApp.Client;
using BlazorSortableList.DemoApp.Components;

namespace BlazorSortableList.DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            services.AddSingleton<IPersistenceSample, PersistenceSample>();

            //services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //services.AddServerSideBlazor().AddCircuitOptions(option =>
            //    {
            //        if (app.Environment.IsDevelopment()) //Only add details when debugging.
            //        {
            //            option.DetailedErrors = true;
            //        }
            //    });

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
