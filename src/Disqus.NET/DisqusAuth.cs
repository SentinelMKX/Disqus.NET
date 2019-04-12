namespace Disqus.NET
{
    public class DisqusAuth
    {
        public DisqusAuth(DisqusAuthMethod authMethod, string apiKey)
        {
            AuthMethod = authMethod;
            ApiKey = apiKey;
        }

        /// <summary>
        ///     server-side API key or public-facing JavaScript API key
        /// </summary>
        public string ApiKey { get; }

        public DisqusAuthMethod AuthMethod { get; }
    }
}