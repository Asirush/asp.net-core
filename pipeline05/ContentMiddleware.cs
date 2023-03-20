namespace pipeline05
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        public ContentMiddleware(RequestDelegate nextDelegate) { this.nextDelegate = nextDelegate; }
        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.ToString() == "/middleware")
            {
                await context.Response.WriteAsync("This is from context");
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }

    public static class ContentMiddlewareExtension
    {
        public static IApplicationBuilder cme(this ApplicationBuilder app)
        {
            return app.UseMiddleware<ContentMiddleware>();
        }
    }
}
