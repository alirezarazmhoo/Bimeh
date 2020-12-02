using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bimeh.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }
        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, configure>());
        }
        public DbSet<Bimeh.Models.City> Cities { get; set; }

        public DbSet<Bimeh.Models.Insurance> Insurances { get; set; }

        public DbSet<Bimeh.Models.ServiceProviderCenters> ServiceProviderCenters { get; set; }

        public DbSet<Bimeh.Models.Issuance> Issuances { get; set; }

        public DbSet<Bimeh.Models.Requests> Requests { get; set; }

        public DbSet<Bimeh.Models.Chats> Chats { get; set; }

        
        class configure : System.Data.Entity.Migrations.DbMigrationsConfiguration<ApplicationDbContext>
        {
            public configure()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }
            protected override void Seed(Bimeh.Models.ApplicationDbContext context)
            {
                if (!context.Roles.Any())
                {
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    string roleName = "Normal";

                    IdentityResult roleResult;
                    if (!RoleManager.RoleExists(roleName))
                    {
                        roleResult = RoleManager.Create(new IdentityRole(roleName));
                    }
                    roleName = "Admin";
                    if (!RoleManager.RoleExists(roleName))
                    {
                        roleResult = RoleManager.Create(new IdentityRole(roleName));
                    }
                }
                if (!context.Users.Any(s=>s.UserName == "Yazdani"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser { UserName ="Yazdani", Email = "Yazdani@yahoo.com", Address = "اصفهان", FirstName = "Maryam", LastName = "Yazdani", Mobile = "09131111111" };
                    manager.Create(user, "123456");
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }


    }
}