using Api.Validation;
using Business.TrashDetection;
using Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("trash-detection")]
    public class TrashDetectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrashDetectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Detect([FromForm] Image image)
        {
            var validator = new ImageValidator();
            var result = validator.Validate(image);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var response = await _mediator.Send(new TrashDetection.Query(image.File));
            return Ok(response);
        }
    }
}
