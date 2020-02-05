using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShadySoft.AsyncOptions
{
    public class AsyncOptionsProvider<TOptions> : IAsyncOptionsProvider<TOptions> where TOptions : new()
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Func<TOptions, IServiceProvider, Task> _setupActionAsync;
        private TOptions _options;

        public AsyncOptionsProvider(IServiceProvider serviceProvider, Func<TOptions, IServiceProvider, Task> setupActionAsync)
        {
            _serviceProvider = serviceProvider;
            _setupActionAsync = setupActionAsync;
        }

        public async Task<TOptions> GetValueAsync()
        {
            if (_options != null)
                return _options;

            _options = new TOptions();
            return await RefreshValueAsync();
        }

        public async Task<TOptions> RefreshValueAsync()
        {
            await _setupActionAsync(_options, _serviceProvider);
            return _options;
        }
    }
}
