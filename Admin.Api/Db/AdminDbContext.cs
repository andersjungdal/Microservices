using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Api.Db
{
    public class AdminDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
