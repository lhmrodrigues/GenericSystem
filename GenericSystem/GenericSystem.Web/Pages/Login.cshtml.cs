using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericSystem.Infra.CrossCutting.Communication.Interfaces;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericSystem.Web.Pages
{
    public class LoginModel : PageBase
    {
        private readonly IUserApiService _userApiService;

        [BindProperty]
        public AuthenticationViewModel AuthenticationViewModel { get; set; }

        [BindProperty]
        public UserViewModel UserViewModel { get; set; }

        public LoginModel(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }
        public async Task<IActionResult> OnGet(bool? success, string message)
        {
            Success = success;
            Message = message;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                UserViewModel resposta = await _userApiService.Authenticate(AuthenticationViewModel.Username, AuthenticationViewModel.Password);

                if (resposta != null)
                    return RedirectToPage("Home");

                return RedirectToAction("OnGet", new { success = false, message = "Usuário ou senha inválido" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
        public async Task<IActionResult> OnPostRegister()
        {
            try
            {
                if (await _userApiService.VerifyUsername(UserViewModel.Username))
                    return RedirectToAction("OnGet",new { success = false, message = "Username já esta em uso" });

                if (!await _userApiService.PostAsync(UserViewModel))
                    return RedirectToAction("OnGet", new { success = false, message = "Erro ao realizar o Cadastro" });

                return RedirectToAction("OnGet", new { success = true, message = "Cadastro realizado com sucesso" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("OnGet", new { success = false, message = "Falaha ao se conectar com a api de dados" });
            }
        }
    }
}