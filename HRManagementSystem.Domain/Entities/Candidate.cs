using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string CvUrl { get; set; }
        public string CvName { get; set; }
        public string Status { get; set; } // "accepted" | "declined" | null
        public string Note { get; set; }
    }
}
