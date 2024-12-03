using Slendernotes.Domain.Text;

namespace Slendernotes.API.DTO.Response
{
    public class TextDetails
    {
        public Guid Id { get; private set; }
        public string TextBody { get; set; }
        public string Title { get; set; }
        public TextCategory Category { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
    }
}
