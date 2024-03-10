using Application.InterfaceService;
using System.Security.Claims;

namespace WebAPI.WebService
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            var context = _contextAccessor.HttpContext;
            if (context?.User?.Identity?.IsAuthenticated == true)
            {
                string Id = context.User.FindFirstValue("AccountId");
                GetCurrentUserId = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
            }
        }
        public Guid GetCurrentUserId { get; set; }
    }
}
