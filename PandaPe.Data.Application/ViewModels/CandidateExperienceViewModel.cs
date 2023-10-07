using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.ViewModels
{
    public class CandidateExperienceViewModel : CandidateExperienceBase
    {
        public CandidateBase Candidate { get; set; }
    }
}
