using Microsoft.AspNet.Identity.EntityFramework;

namespace MExperiment.Models.Identity
{
    public class AppUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
        public string MyExtraProperty { get; set; }
    }
}
