using Slendernotes.API.Enums;

namespace Slendernotes.API.DTO.Response
{
    public class TextResume
    {
        public string TextBody { get; set; }
        public string Title { get; set; }
        public TextCategory Category { get; set; }
    }
}
