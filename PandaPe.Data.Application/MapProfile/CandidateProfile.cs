using AutoMapper;
using PandaPe.Data.Application.Feature.Candidates.Commands;
 
using PandaPe.Data.Models.Entities;
using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.MapProfile
{
    internal class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CreateCandidateCommand>().ReverseMap();
            CreateMap<Candidate, UpdateCandidateCommand>().ReverseMap();
            CreateMap<CandidateViewModel, Candidate>().ReverseMap();
            CreateMap<CandidateViewModel, CandidateBase>().ReverseMap();
        }
    }
}
