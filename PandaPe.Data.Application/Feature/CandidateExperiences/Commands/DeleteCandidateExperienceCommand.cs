using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.CandidateExperiences.Commands
{
    public class DeleteCandidateExperienceCommand : IRequest<CandidateExperienceViewModel>
    {
        public int Id { get; set; }
    }

    internal class DeleteHandler : IRequestHandler<DeleteCandidateExperienceCommand, CandidateExperienceViewModel>
    {
        private readonly IRepository<CandidateExperience, int> _candiExpeRepo;
        private readonly IMapper _mapper;

        public DeleteHandler(IRepository<CandidateExperience, int> candiExpeRepo, IMapper mapper)
        {
            this._candiExpeRepo = candiExpeRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateExperienceViewModel> Handle(DeleteCandidateExperienceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var query = await _candiExpeRepo.Query().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("No existe el candidato a eliminar");
                await _candiExpeRepo.DeleteAsync(query, cancellationToken);

                return _mapper.Map<CandidateExperienceViewModel>(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
