using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Queries.TextGetDetailsAll;
using Slendernotes.API.Queries.TextGetResumeAll;
using Slendernotes.API.Queries.TextGetDetails;
using Slendernotes.API.Queries.TextGetResume;
using Slendernotes.API.Results;
using Slendernotes.API.Services.Interfaces;

namespace Slendernotes.API.Services
{
    public class TextService : ITextService
    {
        private readonly IMediator _mediator;
        public TextService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResultService<List<TextResume>>> GetAllResumeAsync()
        {
            TextGetResumeAllQuery query = new();
            var resultRepository = await _mediator.Send(query);

            if (resultRepository.IsSuccess)
            {
                return ResultService.Ok(resultRepository.Data);
            }

            return ResultService.Fail<List<TextResume>>(resultRepository.Message);
        }


        public async Task<ResultService<List<TextDetails>>> GetAllDetailsAsync()
        {
            TextGetDetailsAllQuery query = new();
            var resultRepository = await _mediator.Send(query);

            if (resultRepository.IsSuccess)
            {
                return ResultService.Ok(resultRepository.Data);
            }

            return ResultService.Fail<List<TextDetails>>(resultRepository.Message);
        }


        public async Task<ResultService<TextResume>> GetResumeByIdAsync(Guid id)
        {
            TextGetResumeQuery query = new(id);
            var resultRepository = await _mediator.Send(query);

            if (resultRepository.IsSuccess)
            {
                return ResultService.Ok(resultRepository.Data);
            }

            return ResultService.Fail<TextResume>(resultRepository.Message);
        }


        public async Task<ResultService<TextDetails>> GetDetailsByIdAsync(Guid id)
        {
            try
            {
                TextGetDetailsQuery query = new(id);
                var resultRepository = await _mediator.Send(query);

                if (resultRepository.IsSuccess)
                {
                    return ResultService.Ok(resultRepository.Data);
                }

                return ResultService.Fail<TextDetails>(resultRepository.Message);

            }
            catch (Exception e)
            {
                return ResultService.Fail<TextDetails>(e.Message);
            }
        }

        public Task<ResultService<TextDetails>> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultService> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
