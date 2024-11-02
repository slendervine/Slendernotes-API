using FluentValidation;
using Slendernotes.API.DTO.Request;

namespace Slendernotes.API.Validations
{
    public class TextCreateValidator : AbstractValidator<TextCreateDTO>
    {
        private const string InvalidMessage = "O campo [{PropertyName}] é inválido";
        private const string EmptyFieldMessage = "O campo [{PropertyName}] não pode ser vazio";

        public TextCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(InvalidMessage)
                .MaximumLength(100);

            RuleFor(x => x.Category)
                .IsInEnum()
                .WithMessage(InvalidMessage);

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage(InvalidMessage);

        }
    }
}
