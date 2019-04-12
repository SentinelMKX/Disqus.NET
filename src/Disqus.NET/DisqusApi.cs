using System;

namespace Disqus.NET
{
    public class DisqusApi : IDisqusApi
    {
        public DisqusApi(IDisqusRequestProcessor requestProcessor, DisqusAuthMethod authMethod, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            Applications = new DisqusApplicationsApi(requestProcessor, authMethod, key);
            Blacklists = new DisqusBlacklistsApi(requestProcessor, authMethod, key);
            Category = new DisqusCategoryApi(requestProcessor, authMethod, key);
            Exports = new DisqusExportsApi(requestProcessor, authMethod, key);
            ForumCategory = new DisqusForumCategoriesApi(requestProcessor, authMethod, key);
            Forums = new DisqusForumsApi(requestProcessor, authMethod, key);
            Imports = new DisqusImportsApi(requestProcessor, authMethod, key);
            Organizations = new DisqusOrganizationsApi(requestProcessor, authMethod, key);
            Posts = new DisqusPostsApi(requestProcessor, authMethod, key);
            Threads = new DisqusThreadsApi(requestProcessor, authMethod, key);
            Trends = new DisqusTrendsApi(requestProcessor, authMethod, key);
            TrustedDomains = new DisqusTrustedDomainsApi(requestProcessor, authMethod, key);
            Users = new DisqusUsersApi(requestProcessor, authMethod, key);
            Whitelists = new DisqusWhitelistsApi(requestProcessor, authMethod, key);
        }

        public DisqusApi(DisqusAuthMethod authMethod, string key) : this(
            new DisqusRequestProcessor(new DisqusRestClient()), authMethod, key)
        {
        }

        public IDisqusApplicationsApi Applications { get; }
        public IDisqusBlacklistsApi Blacklists { get; }
        public IDisqusCategoryApi Category { get; }
        public IDisqusExportsApi Exports { get; }
        public IDisqusForumCategoryApi ForumCategory { get; }
        public IDisqusForumsApi Forums { get; }
        public IDisqusImportsApi Imports { get; }
        public IDisqusOrganizationsApi Organizations { get; }
        public IDisqusPostsApi Posts { get; }
        public IDisqusThreadsApi Threads { get; }
        public IDisqusTrendsApi Trends { get; }
        public IDisqusTrustedDomainsApi TrustedDomains { get; }
        public IDisqusUsersApi Users { get; }
        public IDisqusWhitelistsApi Whitelists { get; set; }
    }
}