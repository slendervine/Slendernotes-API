﻿using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Results;

namespace Slendernotes.API.Queries.TextGetDetails
{
    public class TextGetDetailsQuery : IRequest<ResultRepository<TextDetails>>
    {
        public Guid Id { get; set; }

        public TextGetDetailsQuery(Guid id)
        {
            Id = id;
        }
    }
}