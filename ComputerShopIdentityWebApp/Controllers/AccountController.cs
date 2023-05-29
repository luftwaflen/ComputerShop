using AutoMapper;
using ComputerShopIdentity.Models;
using ComputerShopIdentityWebApp.Models;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopIdentityWebApp.Controllers;

public class AccountController : Controller
{
    private readonly IMapper _mapper;
    private readonly UserManager<UserIdentityModel> _userManager;
    private readonly SignInManager<UserIdentityModel> _signInManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IUserService _userService;

    public AccountController(IMapper mapper,
        UserManager<UserIdentityModel> userManager,
        SignInManager<UserIdentityModel> signInManager,
        IUserService userService,
        RoleManager<IdentityRole<int>> roleManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _userService = userService;
        _roleManager = roleManager;
    }

    // GET
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            UserIdentityModel user = new UserIdentityModel
            {
                UserName = register.Name,
                Email = register.Email
            };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, true);
                var userDto = _mapper.Map<UserDto>(user);
                _userService.Create(userDto);
                return RedirectToAction("Index", "Component");
            }

            ModelState.AddModelError("", result.Errors.ToString());
        }

        return View(register);
    }

    public IActionResult Login(string returnUrl = null)
    {
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var user = _userManager.Users.First(u => u.UserName == login.Name);
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Component");
            }

            ModelState.AddModelError("", "Wrong login or password");
        }

        return View(login);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}