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
    public class UpdateCandidateExperienceCommand : IRequest<CandidateExperienceViewModel>
    {
        public int Id { get; set; }
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

    internal class UpdateHandler : IRequestHandler<UpdateCandidateExperienceCommand, CandidateExperienceViewModel>
    {
        private readonly IRepository<CandidateExperience, int> _candidateRepo;
        private readonly IMapper _mapper;

        public UpdateHandler(IRepository<CandidateExperience, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateExperienceViewModel> Handle(UpdateCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _candidateRepo.Query().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("No existe el candidato");
                var model = _mapper.Map(request, query);

                await _candidateRepo.UpdateAsync(model);

                return _mapper.Map<CandidateExperienceViewModel>(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
