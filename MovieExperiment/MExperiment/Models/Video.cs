using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MExperiment.Models
{
    public class Video
    {
        public string videoName { get; set; }
        public string videoURL { get; set; }

        public Video(string vName, string vURL)
        {
            videoName = vName;
            videoURL = vURL;
        }
    }
}
