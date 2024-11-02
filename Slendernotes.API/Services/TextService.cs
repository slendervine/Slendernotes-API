using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Queries.TextGetDetailsAll;
using Slendernotes.API.Queries.TextGetResumeAll;
using Slendernotes.API.Queries.TextGetDetails;
using Slendernotes.API.Queries.TextGetResume;
using Slendernotes.API.Results;
using Slendernotes.API.Services.Interfaces;
using Slendernotes.API.DTO.Request;
using Slendernotes.API.Commands.TextCreate;
using Slendernotes.API.Commands.TextDelete;
using Slendernotes.Domain.Common;

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

        public async Task<ResultService<Guid>> CreateAsync(TextCreateDTO dataDTO)
        {   
            TextCreateCommand command = new(dataDTO);
            ResultRepository<Guid> resultRepository = await _mediator.Send(command);
            if (!resultRepository.IsSuccess)
            {
                return ResultService.Fail<Guid>(resultRepository.Message);
            }

            return ResultService.Ok(resultRepository.Data);
        }

        public async Task<ResultService> DeleteAsync(Guid id)
        {
            TextDeleteCommand command = new(id);
            var resultRepository = await _mediator.Send(command);
            if (!resultRepository.IsSuccess)
            {
                return ResultService.Fail(resultRepository.Message);
            }

            return ResultService.Ok(resultRepository.Message);
        }
    }
}
