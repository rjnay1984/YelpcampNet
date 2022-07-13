using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace YelpcampNet.Web.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminOnly : PageModel
    {
        private readonly ILogger<AdminOnly> _logger;

        public AdminOnly(ILogger<AdminOnly> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}