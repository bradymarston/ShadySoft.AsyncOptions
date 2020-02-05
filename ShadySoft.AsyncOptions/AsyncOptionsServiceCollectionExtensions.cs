using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace ShadySoft.AsyncOptions
{
    public static class AsyncOptionsServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAsyncOptions<TOptions>(this IServiceCollection services, Func<TOptions, IServiceProvider, Task> setupActionAsync) where TOptions : new()
        {
            services.AddScoped<IAsyncOptionsProvider<TOptions>>(sp => new AsyncOptionsProvider<TOptions>(sp, setupActionAsync));
            return services;
        }
    }
}