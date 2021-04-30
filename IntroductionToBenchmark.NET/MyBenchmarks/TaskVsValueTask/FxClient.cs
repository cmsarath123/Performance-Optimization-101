using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.TaskVsValueTask
{
    public class FxClient
    {
        private readonly IMemoryCache _cachedFxRates = new MemoryCache(new MemoryCacheOptions());
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };

        public async Task<FxRate> GetFxRateAsyncTask(string baseCurrency, string targetCurrency)
        {
            var cacheKey = (baseCurrency, targetCurrency);
            var fxRate = _cachedFxRates.Get<FxRate>(cacheKey);
            if(fxRate is null)
            {
                fxRate = await _httpClient.GetFromJsonAsync<FxRate>($"api/FxRates/{baseCurrency}/{targetCurrency}");
                _cachedFxRates.Set(cacheKey, fxRate, TimeSpan.FromHours(1));
            }

            return fxRate;
        }

        public async ValueTask<FxRate> GetFxRateAsyncValueTask(string baseCurrency, string targetCurrency)
        {
            var cacheKey = (baseCurrency, targetCurrency);
            var fxRate = _cachedFxRates.Get<FxRate>(cacheKey);
            if (fxRate is null)
            {
                fxRate = await _httpClient.GetFromJsonAsync<FxRate>($"api/FxRates/{baseCurrency}/{targetCurrency}");
                _cachedFxRates.Set(cacheKey, fxRate, TimeSpan.FromHours(1));
            }

            return fxRate;
        }

    }

    public record FxRate(string BaseCurrency, string TargetCurrency, decimal Rate);
}
