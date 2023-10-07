using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
 
using PandaPe.Data.Models.Entities;
using PandaPe.Data.Models.EntityBases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.Candidates.Commands
{
    public class CreateCandidateCommand : IRequest<CandidateViewModel>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
    }

    internal class CreateHandler : IRequestHandler<CreateCandidateCommand, CandidateViewModel>
    {
        private readonly IRepository<Candidate, int> _candidateRepo;
        private readonly IMapper _mapper;

        public CreateHandler(IRepository<Candidate, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateViewModel> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var candidate = _mapper.Map<Candidate>(request);

                var result = await _candidateRepo.AddAsync(candidate);

                return _mapper.Map<CandidateViewModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
