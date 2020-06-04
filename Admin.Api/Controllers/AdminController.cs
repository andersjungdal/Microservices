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
        [HttpPost]
        public async Task<IActionResult> GetCustomerAsync([FromBody] Models.Admin x)
        {
            
            var result = await admin.GetUsernameAndPassword();
            
            if (result != null && x.Username == result.Username && x.Password == result.Password)
            {
                result.Password = null;
                return Ok(result);
            }
            return NotFound();
        }

    }
}
