using System;
using System.Threading.Tasks;

namespace ShadySoft.AsyncOptions
{
    public interface IAsyncOptionsProvider<TOptions> where TOptions : new()
    {
        Task<TOptions> GetValueAsync();
        Task<TOptions> RefreshValueAsync();
    }
}
