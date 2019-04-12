﻿using System;

namespace Disqus.NET
{
    /// <summary>
    /// </summary>
    /// <remarks>https://msdn.microsoft.com/en-us/library/ms229064(v=vs.100).aspx</remarks>
#if NET45
    [Serializable]
#endif
    public class DisqusApiException : Exception
    {
        public DisqusApiResponseCode Code { get; }

        public string Error { get; }

        public DisqusApiException(DisqusApiResponseCode code, string error) : base(error)
        {
            Code = code;
            Error = error;
        }
    }
}