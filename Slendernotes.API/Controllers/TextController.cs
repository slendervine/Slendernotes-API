using Microsoft.AspNetCore.Mvc;
using Slendernotes.API.DTO.Request;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Results;
using Slendernotes.API.Services.Interfaces;

namespace Slendernotes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextController : ControllerBase
    {

        private readonly ITextService _textService;

        public TextController(ITextService textService)
        {
            _textService = textService;
        }

        [HttpGet("resume")]
        public async Task<ActionResult<ResultApplication<List<TextResume>>>> GetAllResume()
        {
            var result = await _textService.GetAllResumeAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail<TextResume>(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Data));
        }

        [HttpGet("resume/{id}")]
        public async Task<ActionResult<ResultApplication<TextResume>>> GetResume(Guid id)
        {
            var result = await _textService.GetResumeByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail<TextResume>(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Data));
        }

        [HttpGet("details")]
        public async Task<ActionResult<ResultApplication<List<TextDetails>>>> GetAllDetails()
        {
            var result = await _textService.GetAllDetailsAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail<TextDetails>(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Data));
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<ResultApplication<TextDetails>>> GetDetails(Guid id)
        {
            var result = await _textService.GetDetailsByIdAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail<TextDetails>(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Data));
        }

        [HttpPost]
        public async Task<ActionResult<ResultApplication<Guid>>> Create([FromBody] TextCreateDTO dataDTO)
        {
            var result = await _textService.CreateAsync(dataDTO);
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail<Guid>(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Data));
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResultApplication>> Delete(Guid id)
        {
            var result = await _textService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                return BadRequest(ResultApplication.Fail(result.Message));
            }

            return Ok(ResultApplication.Ok(result.Message));
        }

    }
}
