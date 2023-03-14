using System.Security.Claims;
using Duende.IdentityServer.Services;
using IdentityServer.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace IdentityServer.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IIdentityServerInteractionService _interaction;

    public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IIdentityServerInteractionService interaction)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _interaction = interaction;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Login(string returnUrl)
    {
        TempData["returnUrl"] = returnUrl;
        var model = new LoginViewModel
        {
            ReturnUrl = returnUrl,
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        };

        return View(model);
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult ExternalLogin(string provider, string returnUrl)
    {
        var redirectUrl = Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = returnUrl });

        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        return new ChallengeResult(provider, properties);
    }

    public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");

        var loginViewModel = new LoginViewModel
        {
            ReturnUrl = returnUrl,
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        };

        if (remoteError is not null)
        {
            ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

            return View("Login", loginViewModel);
        }

        var info = await _signInManager.GetExternalLoginInfoAsync();

        if (info is null)
        {
            ModelState.AddModelError(string.Empty, "Error loading external login information");

            return View("Login", loginViewModel);
        }

        var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
            isPersistent: false, bypassTwoFactor: true);

        if (signInResult.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }

        var email = info.Principal.FindFirstValue(ClaimTypes.Email);

        if (email is null) return View("Login");

        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                Email = email,
            };

            await _userManager.CreateAsync(user);
        }

        await _userManager.AddLoginAsync(user, info);
        await _signInManager.SignInAsync(user, isPersistent: false);

        return LocalRedirect(returnUrl);

    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(new LoginViewModel());

        var user = await _userManager.FindByNameAsync(model.UserName!);

        if (user is null) return View(new LoginViewModel());

        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password!, false, false);

        if (signInResult.Succeeded) return Redirect(model.ReturnUrl);

        return View(new LoginViewModel());
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        model.ReturnUrl = TempData["returnUrl"].ToString();
        if (ModelState.IsValid) return View(new RegisterViewModel());

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
            return Redirect(model.ReturnUrl);
        }

        return View(new RegisterViewModel());
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Logout(string logoutId)
    {
        var logout = await _interaction.GetLogoutContextAsync(logoutId);
        await _signInManager.SignOutAsync();
        return Redirect(logout.PostLogoutRedirectUri);
    }
}