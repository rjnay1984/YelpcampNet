using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace YelpcampNet.Web.Pages
{
    public class Protected : PageModel
    {
        private readonly ILogger<Protected> _logger;

        public Protected(ILogger<Protected> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}