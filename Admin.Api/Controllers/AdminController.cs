using Admin.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService admin;

        public AdminController(IAdminService admin)
        {
            this.admin = admin;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync()
        {
            var result = await admin.GetUsernameAndPassword();
            if (result.IsSuccess)
            {
                return Ok(result.Admin);
            }
            return NotFound();
        }

    }
}
