using System.Security.Claims;
using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.DTOs;
using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;
using IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Controllers;

public class AccountController : Controller
{
    private readonly UserRepository _users;

    public AccountController(UserRepository users) => _users = users;

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(model);

        var user = _users.Validate(model.Username, model.Password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.GivenName, user.FirstName),
            new(ClaimTypes.Surname, user.LastName)
        };

        var identity = new ClaimsIdentity(claims, "ConferenceCookie");
        await HttpContext.SignInAsync("ConferenceCookie", new ClaimsPrincipal(identity));

        return !string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)
            ? Redirect(returnUrl)
            : RedirectToAction("Index", "Attendee");
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterDto model)
    {
        if (!ModelState.IsValid) return View(model);

        if (_users.Exists(model.Username))
        {
            ModelState.AddModelError(nameof(model.Username), "Username is already registered.");
            return View(model);
        }

        _users.Add(new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Username = model.Username,
            Password = model.Password
        });

        TempData["Message"] = "Registration successful. You may now log in.";
        return RedirectToAction(nameof(Login));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("ConferenceCookie");
        return RedirectToAction(nameof(Login));
    }
}
