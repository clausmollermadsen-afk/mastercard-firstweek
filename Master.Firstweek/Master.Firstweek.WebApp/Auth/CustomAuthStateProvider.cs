using System.Security.Claims;
using Master.Firstweek.WebApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace Master.Firstweek.WebApp.Auth
{
    /// <summary>
    /// Custom authentication state provider for managing user authentication state.
    /// </summary>
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAuthStateProvider"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public CustomAuthStateProvider(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        /// <summary>
        /// Gets the current authentication state asynchronously.
        /// </summary>
        /// <returns>The current <see cref="AuthenticationState"/>.</returns>
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = _httpContextAccessor.HttpContext?.User ?? _user;
            return Task.FromResult(new AuthenticationState(user));
        }

        /// <summary>
        /// Notifies the authentication state provider that the user has changed.
        /// </summary>
        public void NotifyUserChanged()
        {
            var authState = Task.FromResult(new AuthenticationState(_user));
            NotifyAuthenticationStateChanged(authState);
        }

        /// <summary>
        /// Signs in a user with the specified token.
        /// </summary>
        /// <param name="token">The user's authentication token.</param>
        /// <returns>True if sign-in is successful; otherwise, false.</returns>
        public async Task<bool> SignIn(string token)
        {
            var user = _context.Users.SingleOrDefault(u => u.Token == token);
            if (user == null)
                return false;

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Address),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Sid, user.Id),
            }, "Cookies");

            _user = new ClaimsPrincipal(identity);
            var principal = new ClaimsPrincipal(identity);

            await _httpContextAccessor.HttpContext!.SignInAsync("Cookies", principal);
            NotifyUserChanged();
            return true;
        }

        /// <summary>
        /// Signs out the current user asynchronously.
        /// </summary>
        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync("Cookies");

            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}