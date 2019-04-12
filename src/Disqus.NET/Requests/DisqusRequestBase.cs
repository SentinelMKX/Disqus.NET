using System.Collections.Generic;

namespace Disqus.NET.Requests
{
    public class DisqusRequestBase
    {
        protected DisqusRequestBase()
        {
            Parameters = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> Parameters { get; }
    }
}