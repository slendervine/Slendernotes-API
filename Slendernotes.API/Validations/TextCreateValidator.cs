using FluentValidation;

namespace Slendernotes.API.Validations
{
    public class TextCreateValidator : AbstractValidator<DTO.Request.TextCreate>
    {
        private const string InvalidMessage = "O campo [{PropertyName}] é inválido";
        private const string EmptyFieldMessage = "O campo [{PropertyName}] não pode ser vazio";

        public TextCreateValidator()
        {

            RuleFor(x => x.TextBody)
                .NotEmpty()
                .WithMessage(EmptyFieldMessage);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(EmptyFieldMessage);

            RuleFor(x => x.Category)
                .IsInEnum()
                .WithMessage(InvalidMessage);

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage(InvalidMessage);

        }
    }
}
