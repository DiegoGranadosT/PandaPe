using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Application.Feature.CandidateExperiences.Commands;
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
    public class UpdateCandidateCommand : IRequest<CandidateViewModel>
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
    }

    internal class UpdateHandler : IRequestHandler<UpdateCandidateCommand, CandidateViewModel>
    {
        private readonly IRepository<Candidate, int> _candidateRepo;
        private readonly IRepository<CandidateExperience, int> _candidateExpRepo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateHandler(IRepository<Candidate, int> candidateRepo, IRepository<CandidateExperience, int> candidateExpRepo, IMediator mediator, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._candidateExpRepo = candidateExpRepo;
            this._mediator = mediator;
            this._mapper = mapper;
        }
        public async Task<CandidateViewModel> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            //using var transaccion = _candidateRepo.BeginTransaction();
            try
            {
                var query = await _candidateRepo.Query().Include(x => x.CandidateExperiences).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("No existe el candidato");



                var model = _mapper.Map(request, query);

                await _candidateRepo.UpdateAsync(model, cancellationToken);

                //await transaccion.CommitAsync();
                return _mapper.Map<CandidateViewModel>(model);
            }
            catch (Exception ex)
            {
                //await transaccion.RollbackAsync();
                throw ex;
            }
        }
    }
}
