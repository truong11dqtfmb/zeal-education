using System.Security.Claims;

namespace Zeal_education.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserName()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                string result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                return result;
            }
            return null;
        }
    }
}
