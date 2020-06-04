using Admin.Api.Db;
using Admin.Api.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Api.Services
{
    public class AdminService : IAdminService
    {
        private readonly ILogger<AdminService> logger;
        private readonly AdminDbContext adminDbContext;
        private readonly IMapper mapper;

        public AdminService(ILogger<AdminService> logger, AdminDbContext adminDbContext, IMapper mapper)
        {
            this.logger = logger;
            this.adminDbContext = adminDbContext;
            this.mapper = mapper;
        }
        public async Task<Models.Admin> GetUsernameAndPassword()
        {
            try
            {
                var admin = await adminDbContext.Admin.FirstOrDefaultAsync();
                if (admin != null)
                {
                    logger?.LogInformation("Admin found");
                    var result = mapper.Map<Db.Admin, Models.Admin>(admin);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return null;
            }
        }
    }
}
