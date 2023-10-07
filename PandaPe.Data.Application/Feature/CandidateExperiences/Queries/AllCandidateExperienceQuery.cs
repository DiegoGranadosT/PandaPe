using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Application.ViewModels;
using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.CandidateExperiences.Queries
{
    public class AllCandidateExperienceQuery : IRequest<List<CandidateExperienceViewModel>>
    {
        public string? Search { get; set; }
    }

    internal class AllHandler : IRequestHandler<AllCandidateExperienceQuery, List<CandidateExperienceViewModel>>
{
        private readonly IRepository<CandidateExperience, int> _candidateRepo;
        private readonly IMapper _mapper;

        public AllHandler(IRepository<CandidateExperience, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<List<CandidateExperienceViewModel>> Handle(AllCandidateExperienceQuery request, CancellationToken cancellationToken)
        {
            return await _candidateRepo.Query()
                .Where(x => request.Search == null || x.Company.ToUpper().Contains(request.Search.ToUpper()) || x.Job.ToUpper().Contains(request.Search.ToUpper()) || x.Description.ToUpper().Contains(request.Search.ToUpper()) )
                .Select(x => _mapper.Map<CandidateExperienceViewModel>(x))
                .ToListAsync();
        }
    }
}
