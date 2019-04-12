﻿using System.Collections.Generic;
using System.Linq;
using Disqus.NET.Extensions;

namespace Disqus.NET.Requests
{
    public class DisqusPostGetContextRequest : DisqusRequestBase
    {
        private DisqusPostGetContextRequest(long postId)
        {
            Parameters.Add(new KeyValuePair<string, string>("post", postId.ToString()));
        }

        public static DisqusPostGetContextRequest New(long postId)
        {
            return new DisqusPostGetContextRequest(postId);
        }

        /// <summary>
        ///     Allow to specify relations to include with your response.
        /// </summary>
        /// <param name="related"></param>
        /// <returns></returns>
        public DisqusPostGetContextRequest Related(DisqusPostRelated related)
        {
            if (related == DisqusPostRelated.None) return this;

            var parameters = related.ToStringArray().Select(r => new KeyValuePair<string, string>("related", r));
            Parameters.AddRange(parameters);

            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public DisqusPostGetContextRequest Depth(int depth)
        {
            Parameters.Add(new KeyValuePair<string, string>("depth", depth.ToString()));

            return this;
        }
    }
}