using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PandaPe.Data.Application.Feature.CandidateExperiences.Commands;
using PandaPe.Data.Application.Feature.CandidateExperiences.Queries;
using PandaPe.UI.Shared.ViewModels;

namespace PandaPe.UI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExperienceController : ControllerBase
    {
        private readonly ILogger<CandidateExperienceController> _logger;
        private readonly IMediator _mediator;

        public CandidateExperienceController(ILogger<CandidateExperienceController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CandidateExperienceViewModel>>> GetAll([FromQuery] AllCandidateExperienceQuery request)
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
        public async Task<ActionResult<CandidateExperienceViewModel>> GetById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetByIdCandidateExperienceQuery { Id = id });

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CandidateExperienceViewModel>> Create(CreateCandidateExperienceCommand request)
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
        public async Task<ActionResult<CandidateExperienceViewModel>> Update(UpdateCandidateExperienceCommand request)
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
    }
}
