namespace SimpleRouting.Models
{
    public class UserAgentConstrain : IRouteConstraint
    {
        private string requeredUserAgent;
        public UserAgentConstrain(string userAgent)
        {
            requeredUserAgent = userAgent;
        }

        public bool Match(HttpContext? httpContext, IRouter? route, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return httpContext.Request.Headers["UserAgent"].ToString() != null &&
                httpContext.Request.Headers["UserAgent"]
                .ToString().Contains(requeredUserAgent);
        }
    }
}
