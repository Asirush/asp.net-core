using Microsoft.AspNetCore.Localization;

namespace SimpleRouting.Models
{
    public class MyCultureprovider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResearch(HttpContext httpContext)
        {
            // todo sql reauest
            

            var requestCulture = new ProviderCultureResult("ru");
            return Task.FromResult(requestCulture);
        }
    }
}
