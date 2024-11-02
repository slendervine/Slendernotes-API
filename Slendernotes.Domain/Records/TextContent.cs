namespace Slendernotes.Domain.Records
{
    public record TextContent
    {
        public string Value { get; }
        public int WordCount { get; }
        public bool ContainsInappropriateContent { get; }

        private TextContent(string value)
        {
            // Aplica regras de formatação
            Value = NormalizeText(value);
            WordCount = CalculateWordCount(value);
            ContainsInappropriateContent = CheckForInappropriateContent(value);
        }

        public static TextContent Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Text cannot be empty");

            if (value.Length > 5000)
                throw new Exception("Text cannot be longer than 5000 characters");

            return new TextContent(value);
        }

        private string NormalizeText(string text)
        {
            // Remove espaços extras
            // Normaliza quebras de linha
            // Remove caracteres especiais indesejados
            return text.Trim()
                      .Replace("\r\n", "\n")
                      .Replace("  ", " ");
        }

        private int CalculateWordCount(string text)
        {
            return text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private bool CheckForInappropriateContent(string text)
        {
            var inappropriateWords = new[] { "bosta" };
            return inappropriateWords.Any(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));
        }
    }
}
