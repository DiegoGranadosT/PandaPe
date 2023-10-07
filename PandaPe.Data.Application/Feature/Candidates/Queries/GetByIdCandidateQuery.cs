using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Application.ViewModels;
using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.Candidates.Queries
{
    public class GetByIdCandidateQuery : IRequest<CandidateViewModel>
    {
        public int Id { get; set; }
    }

    internal class GetByIdHandler : IRequestHandler<GetByIdCandidateQuery, CandidateViewModel>
    {
        private readonly IRepository<Candidate, int> _candidateRepo;
        private readonly IMapper _mapper;

        public GetByIdHandler(IRepository<Candidate, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateViewModel> Handle(GetByIdCandidateQuery request, CancellationToken cancellationToken)
        {
            var query = await _candidateRepo.Query()
                .Include(x => x.CandidateExperiences)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<CandidateViewModel>(query);
        }
    }
}
