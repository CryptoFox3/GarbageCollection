using GarbageCollection.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbageCollection.Startup))]
namespace GarbageCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

  
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
 
            if (!roleManager.RoleExists("Admin"))
            {

                 
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                var UserId = new ApplicationUser();
                UserId.UserName = "pghodgson558";
                UserId.Email = "Pghodgson558@gmail.com";

                string userPassword = "aA@1234";

                var checkUser = UserManager.Create(UserId, userPassword);

                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(UserId.Id, "Admin");

                }
            }

               
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);

            }
 
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
    }
}
