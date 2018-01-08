using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MExperiment.Models
{
    public partial class Comments
    {
        public Guid IdComment { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdVideo { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
