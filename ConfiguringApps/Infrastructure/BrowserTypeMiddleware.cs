﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private readonly RequestDelegate nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] =
                httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("edge"));
            await nextDelegate.Invoke(httpContext);
        }
    }
}
