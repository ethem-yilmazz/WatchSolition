using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
	public class AppIdentityDbContextSeed
	{
		public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, AppIdentityDbContext dbContext)
		{
			//veri tabanı yoksa oluştur ve migration'ları yap
			await dbContext.Database.MigrateAsync();

			if (!await roleManager.RoleExistsAsync(AuthorizationConstants.Roles.ADMINISTRATOR))
			{
				await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATOR));
			}
			if (!await userManager.Users.AnyAsync(u => u.UserName == AuthorizationConstants.DEFAULT_ADMİN_USER))
			{
				var adminUser = new ApplicationUser()
				{
					UserName = AuthorizationConstants.DEFAULT_ADMİN_USER,
					Email = AuthorizationConstants.DEFAULT_ADMİN_USER,
					EmailConfirmed = true
				};
				await userManager.CreateAsync(adminUser,AuthorizationConstants.DEFAULT_PASSWORD);
				await userManager.AddToRoleAsync(adminUser,AuthorizationConstants.Roles.ADMINISTRATOR);
			}
			
			if (!await userManager.Users.AnyAsync(u => u.UserName == AuthorizationConstants.DEFAULT_DEMO_USER))
			{
				var demoUser = new ApplicationUser()
				{
					UserName = AuthorizationConstants.DEFAULT_DEMO_USER,
					Email = AuthorizationConstants.DEFAULT_DEMO_USER,
					EmailConfirmed = true
				};
				await userManager.CreateAsync(demoUser,AuthorizationConstants.DEFAULT_PASSWORD);
			}



		}
	}
}
