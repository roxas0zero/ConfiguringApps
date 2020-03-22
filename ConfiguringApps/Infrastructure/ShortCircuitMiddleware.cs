﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;                
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
