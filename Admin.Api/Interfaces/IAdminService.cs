﻿using Admin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Api.Interfaces
{
    public interface IAdminService
    {
        Task<Models.Admin> GetUsernameAndPassword();
    }
}
