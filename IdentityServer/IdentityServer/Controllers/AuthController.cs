using IdentityServer.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest(model);

        var user = await _userManager.FindByNameAsync(model.UserName!);

        if (user is null) return BadRequest(model);

        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password!, false, false);

        if (signInResult.Succeeded) return Ok();

        return BadRequest();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        var findResult = await _userManager.FindByNameAsync(model.UserName!);

        if (findResult is not null) return BadRequest();

        var userToCreate = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(userToCreate, model.Password!);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(userToCreate, true);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}