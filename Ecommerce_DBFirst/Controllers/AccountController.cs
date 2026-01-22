using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly JwtService _jwtService;

    // Demo users
    private readonly Dictionary<string, (string Password, string Role)> users =
        new()
        {
            { "admin", ("admin123", "Admin") },
            { "user", ("user123", "User") }
        };

    public AccountController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (users.ContainsKey(username) && users[username].Password == password)
        {
            var role = users[username].Role;
            var token = _jwtService.GenerateToken(username, role);

            // Store JWT in cookie
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("Index", "Product");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
