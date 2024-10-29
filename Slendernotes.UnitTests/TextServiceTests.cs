using MediatR;
using NSubstitute;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.IRepository;
using Slendernotes.API.Results;
using Slendernotes.API.Services;
using Slendernotes.API.Services.Interfaces;

namespace Slendernotes.UnitTests
{
    public class TextServiceTests
    {

        private readonly IMediator _mediator;
        private readonly ITextService _textService;

        public TextServiceTests()
        {
            _mediator = Substitute.For<IMediator>();
            _textService = new TextService(_mediator);
        }

        
        //[Fact]
        //public async void CreateAsync_ShouldReturnResultServiceWithTextDetails_WhenSuccess()
        //{
        //    //Arrenge
        //    TextDetails textDetails = new();
        //    ResultService<TextDetails> expectedResult = new ResultService<TextDetails>();
        //
        //    //aqui precisa criar o command do create
        //
        //
        //    //Act
        //    _mediator.Send(/*aqui precisa passar como parametro o Command do Create, ainda n fiz*/).Returns(expectedResult);
        //    ResultService<TextDetails> result = await _textService.CreateAsync();
        //
        //    //Assert
        //    Assert.Equal(ResultService.Ok(textDetails), result);
        //}

    }
}