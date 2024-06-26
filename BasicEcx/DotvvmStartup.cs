﻿using DotVVM.BusinessPack;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Bootstrap4;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BasicEcx
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrap4Configuration(DotvvmBootstrapOptions.CreateDefaultSettings());
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);

            // enable the Compilation Status Page even in production.
            config.Diagnostics.CompilationPage.IsEnabled = true;
            config.Diagnostics.CompilationPage.AuthorizationPredicate = context => Task.FromResult(true);
            config.Diagnostics.CompilationPage.IsApiEnabled = true;
        }

        public void ConfigureServices(IDotvvmServiceCollection services)
        {
            //services.Services.AddSingleton<ICookieManager, DotvvmSystemWebCookieManager>();
            services.AddDefaultTempStorages("Temp");
            services.AddBusinessPack(theme: BusinessPackTheme.Bootstrap4);
            //services.AddHotReload(); // Not sure what this does, it was in the default-created file.
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/default.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));
            config.RouteTable.AutoDiscoverRoutes(new DotvvmRouteStrategyEcxContent(config));
            config.RouteTable.AutoDiscoverRoutes(new DotvvmRouteStrategyEcxContent(config,"Test"));
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // auto-register all .dotcontrol files that are children of the /Controls folder
            config.Markup.AutoDiscoverControls(new DefaultControlRegistrationStrategy(config, "ecx", "Controls"));

            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/Styles/styles.css")
            });
        }
		
    }
}
