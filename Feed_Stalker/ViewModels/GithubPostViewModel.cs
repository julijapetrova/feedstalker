using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feed_Stalker.ViewModels
{
    public class GithubPostViewModel
    {
        public string githubEvent { get; set; }
        public string author { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }

        public GithubPostViewModel()
        {
        }
    }
}