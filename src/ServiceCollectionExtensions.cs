﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using WebEssentials.AspNetCore.ServiceWorker;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for the <see cref="IServiceCollection"/> type.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ServiceWorker services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddServiceWorker(this IServiceCollection services)
        {
            services.AddTransient<ITagHelperComponent, ServiceWorkerTagHelperComponent>();
            services.AddTransient<PwaOptions>();

            return services;
        }

        /// <summary>
        /// Adds ServiceWorker services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddServiceWorker(this IServiceCollection services, PwaOptions options)
        {
            services.AddTransient<ITagHelperComponent, ServiceWorkerTagHelperComponent>();
            services.AddTransient(factory => options);

            return services;
        }

        /// <summary>
        /// Adds Web App Manifest services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddWebManifest(this IServiceCollection services)
        {
            services.AddTransient<ITagHelperComponent, WebmanifestTagHelperComponent>();
            services.TryAddEnumerable(ServiceDescriptor.Scoped<IConfigureOptions<WebManifest>, WebManifestConfig>());
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<WebManifest>>().Value);

            return services;
        }
    }
}
