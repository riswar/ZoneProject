using System.Runtime.CompilerServices;
using System.Web;

namespace ZoneClient.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<HttpResponseMessage> GetAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var properties=from p in data.GetType().GetProperties() where p.GetValue(data, null) != null
                           select $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(data,null).ToString())}";
            string queryString = string.Join("&", properties.ToArray());
            return await httpClient.GetAsync($"{url}?{queryString}");
        }
    }
}
