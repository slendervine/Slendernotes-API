using AutoMapper;
using MongoDB.Driver;
using Slendernotes.API.Common;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Models;
using Slendernotes.API.Repository.Interfaces;
using Slendernotes.API.Results;
using System.Collections.Generic;

namespace Slendernotes.API.Repository
{
    public class TextRepository : ITextRepository
    {
        private IMongoCollection<Text> _texts;
        private IMapper _mapper;
        public TextRepository(IMongoDatabase db, IMapper mapper)
        {
            _texts = db.GetCollection<Text>("Texts"); //collection de dentro do mongo
            _mapper = mapper;
        }

        public async Task<ResultRepository<Text>> GetById(Guid id)
        {
            Text? text = await _texts.Find(t => t.Id == id)
                                       .FirstOrDefaultAsync();

            if (text == null)
            {
                return ResultRepository.NotFound<Text>();
            }

            return ResultRepository.Ok(text);
        }

        public async Task<ResultRepository<List<Text>>> GetAll()
        {
            List<Text>? textList = await _texts.Find(_ => true).ToListAsync();

            if (textList == null)
            {
                return ResultRepository.NotFound<List<Text>>();
            }

            return ResultRepository.Ok(textList);
        }
    }
}
