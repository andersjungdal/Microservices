using Admin.Api.Db;
using Admin.Api.Profiles;
using Admin.Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestAdmin
{
    public class AdminServiceTest
    {
        [Fact]
        public async Task GetValidUsernameAndPassword()
        {
            var options = new DbContextOptionsBuilder<AdminDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Admin.Database;Integrated Security=True")
                .Options;
            var dbContext = new AdminDbContext(options);

            var adminProfile = new AdminProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(adminProfile));
            var mapper = new Mapper(configuration);

            var adminService = new AdminService(null, dbContext, mapper);

            var admin = await adminService.GetUsernameAndPassword();
            Assert.True(admin.Name=="Admin");
            Assert.True(admin.Username == "username123");
            Assert.True(admin.Password == "password123");
        }

        [Fact]
        public async Task GetInvalidUsernameAndPassword()
        {
            var options = new DbContextOptionsBuilder<AdminDbContext>()
                .UseSqlServer("Data Source=LAPTOP-U3V1724K;Initial Catalog=Microservices.Admin.Database;Integrated Security=True")
                .Options;
            var dbContext = new AdminDbContext(options);

            var adminProfile = new AdminProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(adminProfile));
            var mapper = new Mapper(configuration);

            var adminService = new AdminService(null, dbContext, mapper);

            var admin = await adminService.GetUsernameAndPassword();
            Assert.False(admin.Name == "wrongname");
            Assert.False(admin.Username == "wrongusername");
            Assert.False(admin.Password == "wrongpassword");
        }
    }
}
