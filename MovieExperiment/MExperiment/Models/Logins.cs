using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MExperiment.Models
{
    public partial class Logins
    {
        public Guid IdLogin { get; set; }
        public Guid IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Users IdUserNavigation { get; set; }
    }
}
