using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using FrontAuth.WebApp.Helpers;
using FrontAuth.WebApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FrontAuth.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        //Get: Mostrar Login
        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }

        //Post:login
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
            {
                ViewBag.Error = "Credenciales invalidas";
                    return View();
            }

            //Crear y firmar los claims usando helper
            var principal = ClaimsHelper.CrearClaimsPrincipal(result);
            await HttpContext.SignInAsync("AuthCookie", principal);
            return RedirectToAction("Index", "Home");
        }

        //Registro de usuario Post
        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegistroDTO dto)
        {
            var result = await _authService.RegistrarAsync(dto);
            if (result == null || result.Id <= 0)
            {
                ViewBag.Error = "Error al registrar";
                return View();
            }

            //Crear y firmar los claims usando helper
            var principal = ClaimsHelper.CrearClaimsPrincipal(result);
            await HttpContext.SignInAsync("AuthCookie", principal);
            return RedirectToAction("Index", "Home");
        }

        //Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AuthCookie");
            return RedirectToAction("Login");
        }

        //Mostrar registro
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

    }
}
