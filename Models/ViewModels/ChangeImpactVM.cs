using ChangeControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeControlApp.Models.ViewModels
{
    public class ChangeImpactVM
    {
        public ChangeLog ChangeLog { get; set; }
        public Impact Impact { get; set; }
    }
}
