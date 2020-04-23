using ChangeControlApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeControl.Models
{
    public class ChangeLog
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string  Reason { get; set; }
        public string AffectedProductsAndProcesses { get; set; }
        public Impact Impact { get; set; }
    }
}
