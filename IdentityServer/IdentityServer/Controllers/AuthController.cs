using IdentityServer.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace IdentityServer.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(new LoginViewModel());

        var user = await _userManager.FindByNameAsync(model.UserName!);

        if (user is null) return View(new LoginViewModel());

        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password!, false, false);

        if (signInResult.Succeeded) return RedirectToAction("Index", "Home");

        return View(new LoginViewModel());
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(new RegisterViewModel());

        var findResult = await _userManager.FindByNameAsync(model.UserName!);

        if (findResult is not null) return View(new RegisterViewModel());

        var userToCreate = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(userToCreate, model.Password!);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(userToCreate, true);
            return RedirectToAction("Index", "Home");
        }

        return View(new RegisterViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}