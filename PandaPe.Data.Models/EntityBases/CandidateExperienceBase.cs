using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Models.EntityBases
{
    public class CandidateExperienceBase : EntityBase<int>
    {
        public int CandidateId { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [MaxLength(100)]
        public string Job { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
