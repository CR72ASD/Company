﻿using Company.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repositories.Identity
{
	public class AppIdentityContext : IdentityDbContext<AppUser>
	{
		public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
		{
		}
	}
}
