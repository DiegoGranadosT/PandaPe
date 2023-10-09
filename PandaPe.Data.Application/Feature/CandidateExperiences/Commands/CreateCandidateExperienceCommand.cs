using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;

using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.CandidateExperiences.Commands
{
    public class CreateCandidateExperienceCommand : IRequest<CandidateExperienceViewModel>
    {
        public int CandidateId { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        [MaxLength(100)]
        public string Job { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    internal class CreateHandler : IRequestHandler<CreateCandidateExperienceCommand, CandidateExperienceViewModel>
    {
        private readonly IRepository<CandidateExperience, int> _CandidateExperienceRepo;
        private readonly IMapper _mapper;

        public CreateHandler(IRepository<CandidateExperience, int> candidateExperienceRepo, IMapper mapper)
        {
            _CandidateExperienceRepo = candidateExperienceRepo;
            _mapper = mapper;
        }
        public async Task<CandidateExperienceViewModel> Handle(CreateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var candidateExperience = _mapper.Map<CandidateExperience>(request);

                var result = await _CandidateExperienceRepo.AddAsync(candidateExperience);

                return _mapper.Map<CandidateExperienceViewModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
