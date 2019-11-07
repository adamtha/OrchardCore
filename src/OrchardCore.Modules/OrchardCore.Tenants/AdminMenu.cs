using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using System;
using OrchardCore.Environment.Shell;
using System.Threading.Tasks;

namespace OrchardCore.Tenants
{
    public class AdminMenu : INavigationProvider
    {
        private readonly ShellSettings _shellSettings;
        private readonly IStringLocalizer S;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer, ShellSettings shellSettings)
        {
            _shellSettings = shellSettings;
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            // Don't add the menu item on non-default tenants
            if (_shellSettings.Name != ShellHelper.DefaultShellName)
            {
                return Task.CompletedTask;
            }

            builder
                .Add(S["Configuration"], configuration => configuration
                    .AddClass("menu-configuration").Id("configuration")
                    .Add(S["Tenants"], "5", deployment => deployment
                        .Action("Index", "Admin", new { area = "OrchardCore.Tenants" })
                        .Permission(Permissions.ManageTenants)
                        .LocalNav()
                    )
                );

            return Task.CompletedTask;
        }
    }
}
