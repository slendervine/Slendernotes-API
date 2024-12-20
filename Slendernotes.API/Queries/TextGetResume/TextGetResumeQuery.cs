﻿using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Queries.TextGetResume
{
    public class TextGetResumeQuery : IRequest<ResultRepository<TextResume>>
    {
        public Guid Id { get; set; }

        public TextGetResumeQuery(Guid id)
        {
            Id = id;
        }
    }
}
