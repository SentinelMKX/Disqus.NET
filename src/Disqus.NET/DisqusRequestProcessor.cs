using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Disqus.NET
{
    public class DisqusRequestProcessor : IDisqusRequestProcessor
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        private readonly IDisqusRestClient _restClient;

        public DisqusRequestProcessor(IDisqusRestClient restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// </summary>
        /// <exception cref="DisqusApiException"></exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(DisqusRequestMethod method, string endpoint,
            ICollection<KeyValuePair<string, string>> parameters)
        {
            var response = await ExecuteAsync(method, endpoint, parameters).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(content, SerializerSettings);
            }

            IDisqusResponse<string> errorResponse =
                JsonConvert.DeserializeObject<DisqusErrorResponse>(content, SerializerSettings);

            throw new DisqusApiException(errorResponse.Code, errorResponse.Response);
        }

        private async Task<HttpResponseMessage> ExecuteAsync(DisqusRequestMethod method, string endpoint,
            ICollection<KeyValuePair<string, string>> parameters)
        {
            switch (method)
            {
                default:
                case DisqusRequestMethod.Get:
                    return await _restClient.ExecuteGetAsync(endpoint, parameters).ConfigureAwait(false);
                case DisqusRequestMethod.Post:
                    return await _restClient.ExecutePostAsync(endpoint, parameters).ConfigureAwait(false);
            }
        }
    }
}