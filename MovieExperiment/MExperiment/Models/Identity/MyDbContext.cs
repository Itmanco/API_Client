using Microsoft.AspNet.Identity.EntityFramework;

namespace MExperiment.Models.Identity
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }
}
