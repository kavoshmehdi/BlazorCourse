using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Forms;

namespace DotNetConfDemo
{
    public class App : Application
    {
        public IHost AppHost { get; }
        public App(IServiceCollection additionalServices)
        {
            var host = Host.CreateDefaultBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                    // Register app-specific services
                    //services.AddSingleton<AppState>();
                    if (additionalServices != null)
                        {
                            services.AddAdditionalServices(additionalServices);
                        }
                        services.AddSingleton<AppState>();
                    })
                    .Build();

            host.AddComponent<TodoApp>(parent: this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
