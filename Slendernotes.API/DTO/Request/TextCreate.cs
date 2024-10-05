using Slendernotes.API.Enums;

namespace Slendernotes.API.DTO.Request
{
    public class TextCreate
    {
        public string TextBody { get; set; }
        public string Title { get; set; }
        public TextCategory Category { get; set; }
        public int UserId { get; set; }
    }
}
