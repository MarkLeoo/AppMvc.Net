using System.Net;

namespace App.ExtentionMethods
{
    public static class AppExtention
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(configuration =>
            {
                configuration.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;
                    var content = @$"
                        <!DOCTYPE html>
                        <html lang='en'>

                        <head>
                            <meta charset = 'utf-8' />
                            <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0' />
                            <title> Lỗi </title>
                        </head>
                        <body>
                            <div style='text-align: center;'>
                                <p style='color: red; font-size: 50px;'>Có lỗi xảy ra: {code} - {(HttpStatusCode)code}</p>
                            </div>
                        </body>
                        </html>
                    ";
                    await context.Response.WriteAsync(content);
                });
            });
        }
    }
}