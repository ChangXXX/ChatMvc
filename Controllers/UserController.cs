using System.Net.Http.Headers;
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
    public async Task<ActionResult> Signup(User user)
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
    public async Task<ActionResult> Login(User user)
    {
        if (ModelState.IsValid)
        {
            var response = await _userService.Login(user);
            if (response.IsSuccessStatusCode)
            {
                // Request.H
                return Home();
            }

        }
        return View(user);
    }

    public ActionResult Home()
    {
        return RedirectToAction("Index", "Home");
    }
}