using AutoMapper;
using PandaPe.Data.Application.Contracts.Persistence.Repositories;
 
using PandaPe.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaPe.Data.Application.Feature.Candidates.Commands
{
    public class DeleteCandidateCommand : IRequest<CandidateViewModel>
    {
        public int Id { get; set; }
    }

    internal class DeleteHandler : IRequestHandler<DeleteCandidateCommand, CandidateViewModel>
    {
        private readonly IRepository<Candidate, int> _candidateRepo;
        private readonly IMapper _mapper;

        public DeleteHandler(IRepository<Candidate, int> candidateRepo, IMapper mapper)
        {
            this._candidateRepo = candidateRepo;
            this._mapper = mapper;
        }
        public async Task<CandidateViewModel> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var query = await _candidateRepo.Query().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new Exception("No existe el candidato a eliminar");
                await _candidateRepo.DeleteAsync(query, cancellationToken);

                return _mapper.Map<CandidateViewModel>(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
