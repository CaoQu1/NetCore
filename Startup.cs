using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseImages(@"c:\\xx.jpg");
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseImages(this IApplicationBuilder app, string directory)
        {
            Func<RequestDelegate, RequestDelegate> middleware = next =>
            {
                return context =>
                {
                    string fileName = context.HttpRequest.Uri.LocalPath.TrimStart('/');
                    if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
                    {
                        fileName += ".jpg";
                    }
                    fileName = Path.Combine(directory, fileName);
                    context.HttpResponse.WriteFile(fileName, "image/jpg");
                    return next(context);
                };
            };
            return app.Use(middleware);
        }
    }
}
