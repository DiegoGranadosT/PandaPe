using AutoMapper;
using PandaPe.Data.Application.Feature.CandidateExperiences.Commands;
 
using PandaPe.Data.Models.Entities;
using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.MapProfile
{
    internal class CandidateExperienceProfile : Profile
    {
        public CandidateExperienceProfile()
        {
            CreateMap<CandidateExperience, CreateCandidateExperienceCommand>().ReverseMap();
            CreateMap<CandidateExperienceBase, CreateCandidateExperienceCommand>().ReverseMap();
            CreateMap<CandidateExperience, UpdateCandidateExperienceCommand>().ReverseMap();
            CreateMap<CandidateExperienceBase, UpdateCandidateExperienceCommand>().ReverseMap();
            CreateMap<CandidateExperienceViewModel, CandidateExperience>().ReverseMap();
            CreateMap<CandidateExperienceViewModel, CandidateExperienceBase>().ReverseMap();
            CreateMap<CandidateExperience, CandidateExperienceBase>().ReverseMap();
        }
    }
}
