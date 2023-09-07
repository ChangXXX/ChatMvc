using System.Security.Claims;
using ChatMvc.Models;
using ChatMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers;

public class UserController : Controller
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public ActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Signup(UserViewModel user)
    {   
        if (ModelState.IsValid)
        {
            await _userService.PostUser(user);
            return RedirectToAction("Login", "User");
        }
        return View(user);
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(UserViewModel user)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Login(user);
            if (response.IsSuccessStatusCode)
            {
                var accessToken = response.Headers.GetValues("Jwt").FirstOrDefault();
                HttpContext.Response.Cookies.Append("Jwt", accessToken);
                return Home();
            }

        }
        return View(user);
    }

    public ActionResult Home()
    {
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("Jwt");
        return Home();
    }
}