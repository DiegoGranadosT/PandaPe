using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.UI.Shared.ViewModels
{
    public class CandidateViewModel : CandidateBase
    {
        public List<CandidateExperienceBase> CandidateExperiences { get; set; }
    }
}
