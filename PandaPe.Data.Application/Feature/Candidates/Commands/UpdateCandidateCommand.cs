using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Application.ViewModels;
using PandaPe.Data.Models.Entities;
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
        private readonly IMapper _mapper;

        public UpdateHandler(IRepository<Candidate, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateViewModel> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _candidateRepo.Query().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("No existe el candidato");
                var model = _mapper.Map(request, query);

                await _candidateRepo.UpdateAsync(model, cancellationToken);

                return _mapper.Map<CandidateViewModel>(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
