using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaPe.Data.Application.Feature.CandidateExperiences.Queries;
using PandaPe.Data.Application.Feature.Candidates.Commands;
using PandaPe.Data.Application.Feature.Candidates.Queries;
using PandaPe.UI.Shared.ViewModels;

namespace PandaPe.UI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly IMediator _mediator;

        public CandidateController(ILogger<CandidateController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CandidateViewModel>>> GetAll([FromQuery] AllCandidateQuery request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateViewModel>> GetById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetByIdCandidateQuery { Id = id });

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CandidateViewModel>> Create(CreateCandidateCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<ActionResult<CandidateViewModel>> Update(UpdateCandidateCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CandidateViewModel>> Delete(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteCandidateCommand { Id = id });

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
