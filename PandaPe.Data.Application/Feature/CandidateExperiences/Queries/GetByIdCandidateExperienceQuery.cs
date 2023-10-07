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
    public class GetByIdCandidateExperienceQuery : IRequest<CandidateExperienceViewModel>
    {
        public int Id { get; set; }
    }

    internal class GetByIdHandler : IRequestHandler<GetByIdCandidateExperienceQuery, CandidateExperienceViewModel>
    {
        private readonly IRepository<CandidateExperience, int> _candidateRepo;
        private readonly IMapper _mapper;

        public GetByIdHandler(IRepository<CandidateExperience, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateExperienceViewModel> Handle(GetByIdCandidateExperienceQuery request, CancellationToken cancellationToken)
        {
            var query = await _candidateRepo.Query()
                .Include(x => x.Candidate)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<CandidateExperienceViewModel>(query);
        }
    }
}
