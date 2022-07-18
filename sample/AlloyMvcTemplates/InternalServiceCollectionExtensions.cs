using EPiServer.Framework.Hosting;
using EPiServer.Framework.Web.Resources;
using EPiServer.Web.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace AlloyMvcTemplates
{
    public static class InternalServiceCollectionExtensions
    {
        public static IServiceCollection AddUIMappedFileProviders(this IServiceCollection services, string applicationRootPath, string uiSolutionRelativePath)
        {
            services.Configure<ClientResourceOptions>(o => o.Debug = true);

            var uiSolutionFolder = Path.Combine(applicationRootPath, uiSolutionRelativePath);
            EnsureDictionary(new DirectoryInfo(Path.Combine(applicationRootPath, "modules/_protected")));
            services.Configure<CompositeFileProviderOptions>(c =>
            {
                c.BasePathFileProviders.Add(new MappingPhysicalFileProvider("/EPiServer/PowerSlice", string.Empty, Path.Combine(uiSolutionFolder, "PowerSlice")));
            });
            return services;
        }

        private static void EnsureDictionary(DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Parent.Exists)
            {
                EnsureDictionary(directoryInfo.Parent);
            }

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
    }
}
