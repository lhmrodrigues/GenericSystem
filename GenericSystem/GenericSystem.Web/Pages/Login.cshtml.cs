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
        public UserViewModel UserViewModel { get; set; }

        public LoginModel(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                string token = string.Empty;

                return RedirectToPage("Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

    }
}