using System.Text.Json.Serialization;

namespace Slendernotes.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TextCategory
    {
        None = 0,
        Diario = 1,
        Noticia = 2,
        Outros = 3
    }
}
