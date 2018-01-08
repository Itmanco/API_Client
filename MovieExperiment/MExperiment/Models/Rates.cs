using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MExperiment.Models
{
    public partial class Rates
    {
        public Guid IdRate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdVideo { get; set; }
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }

        //public Users IdUserNavigation { get; set; }
        //public Videos IdVideoNavigation { get; set; }
    }
}
