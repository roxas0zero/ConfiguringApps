using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate nextDelegate;
        private readonly UptimeService uptime;

        public ContentMiddleware(RequestDelegate nextDelegate, UptimeService uptime)
        {
            this.nextDelegate = nextDelegate;
            this.uptime = uptime;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync(
                    $"This is from the content middleware (uptime: {uptime.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
