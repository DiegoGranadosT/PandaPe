using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Models.Entities
{
    public class CandidateExperience : CandidateExperienceBase
    {
        public Candidate Candidate { get; set; }
    }
}
