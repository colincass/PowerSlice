using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSlice
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule), typeof(EPiServer.Shell.ShellInitialization))]
    public class InitializationModule : IConfigurableModule
    {
        /// <summary>
        /// Configure the container for this module
        /// </summary>
        /// <param name="context">The EPiServer context</param>
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<ProtectedModuleOptions>(o =>
            {
                if (!o.Items.Any(x => x.Name.Equals("PowerSlice")))
                {
                    o.Items.Add(new ModuleDetails() { Name = "PowerSlice" });
                }
            });
        }

        /// <summary>
        /// Initialize this module
        /// </summary>
        /// <param name="context">The EPiServer initialization context</param>
        public void Initialize(InitializationEngine context)
        {
        }

        /// <summary>
        /// Un-initialize this module
        /// </summary>
        /// <param name="context">The EPiServer initialization context</param>
        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
