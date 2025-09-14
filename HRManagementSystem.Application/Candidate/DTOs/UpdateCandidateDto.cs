using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Application.Candidate.DTOs
{
    public class UpdateCandidateDto
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string CvUrl { get; set; }
        public string CvName { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
