using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
 
using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.Candidates.Queries
{
    public class AllCandidateQuery : IRequest<List<CandidateViewModel>>
    {
        public string? Search { get; set; }
    }

    internal class AllHandler : IRequestHandler<AllCandidateQuery, List<CandidateViewModel>>
{
        private readonly IRepository<Candidate, int> _candidateRepo;
        private readonly IMapper _mapper;

        public AllHandler(IRepository<Candidate, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<List<CandidateViewModel>> Handle(AllCandidateQuery request, CancellationToken cancellationToken)
        {
            return await _candidateRepo.Query()
                .Where(x => request.Search == null || x.Name.ToUpper().Contains(request.Search.ToUpper()) || x.Email.ToUpper().Contains(request.Search.ToUpper()) || x.Surname.ToUpper().Contains(request.Search.ToUpper()) )
                .Select(x => _mapper.Map<CandidateViewModel>(x))
                .ToListAsync();
        }
    }
}
