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

        public LoginModel(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                UserViewModel resposta = await _userApiService.Authenticate(AuthenticationViewModel.Username, AuthenticationViewModel.Password);

                if (resposta != null)
                    return RedirectToPage("Home");

                return RedirectToAction("OnGet");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

    }
}