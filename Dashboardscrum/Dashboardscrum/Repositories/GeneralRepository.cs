using static System.Guid;
using Dashboardscrum.Repositories;

namespace Dashboardscrum.Repositories
{
    public class GeneralRepository
    {
        public static bool parseId(IHttpContextAccessor? httpContext, out Guid guid)
        {
            if (httpContext?.HttpContext == null)
            {
                guid = default;
                return false;
            }

            var id = httpContext.HttpContext.Request.Query["TeamId"].ToString();

            TryParse(id, out guid);

            return guid != new Guid();
        }
    }
}
