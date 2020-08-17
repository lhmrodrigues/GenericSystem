using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericSystem.Web.Pages
{
    public class PageBase : PageModel
    {
        public bool? Success { get; set; }
        public string Message { get; set; }
    }
}
