namespace WebApplication1.Started
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //======= MINIMAL APIS CONCEPTS ======================

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //app.Run((HttpContext httpContext) =>
            //{
            //    httpContext.Response.StatusCode = 400; // for an ivalid repsonse. 
            //    httpContext.Response.WriteAsync("Hello world"); // will be written in the response body
            //});

            //Mocking an invalid response
            app.Run(async (HttpContext context) =>
            {

                //context.Response.Headers["Content-Type"] = "application/json";
                context.Response.Headers["Content-Type"] = "text/html";
                if(context.Request.Method == "GET")
                {
                    //http://localhost:3000/id=1&name=TEST
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        string? id = context.Request.Query["id"];
                        await context.Response.WriteAsync($"<h1>{id}</>"); // will be written in the response body

                    }
                }
                //context.Response.StatusCode = 400;



                //string path  = context.Request.Path; 
                //context.Response.Headers["Server"] = "My server"; // THis allows me to change the name of the seerver but not really the internall server, which is KESTREL
                //await context.Response.WriteAsync("Hello world"); // will be written in the response body
                //await context.Response.WriteAsync($"<h1>{path}</>"); // will be written in the response body

            });
            app.Run(); // Starts the Kestrel web server
        }
    }
}
