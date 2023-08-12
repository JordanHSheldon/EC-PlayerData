using System.Text;

namespace EsportsProfileWebApi.Web.Extensions
{
    public class BasicAuthHandler
    {
        private readonly string Relm;
        public RequestDelegate Next;

        public BasicAuthHandler(RequestDelegate next, string relm)
        {
            Next = next;
            Relm = relm;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }

            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidpwd = creds.Split(':');
            var uid = uidpwd[0];
            var pwd = uidpwd[1];

            // check here if user is authenticated.
            if (uid != "jordan" || pwd != "password")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await Next(context);
        }
    }
}
