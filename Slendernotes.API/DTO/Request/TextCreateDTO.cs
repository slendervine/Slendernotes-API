using Slendernotes.Domain.Text;

namespace Slendernotes.API.DTO.Request
{
    public class TextCreateDTO
    {
        public string TextBody { get; set; }
        public string Title { get; set; }
        public TextCategory Category { get; set; }
        public int UserId { get; set; }
    }
}
