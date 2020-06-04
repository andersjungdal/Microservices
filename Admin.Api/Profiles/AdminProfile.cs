using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Api.Profiles
{
    public class AdminProfile : AutoMapper.Profile
    {
        public AdminProfile()
        {
            CreateMap<Db.Admin, Models.Admin>();
        }
    }
}
