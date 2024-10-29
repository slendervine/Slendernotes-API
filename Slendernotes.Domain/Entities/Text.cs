using Slendernotes.Domain.Abstractions;
using Slendernotes.Domain.Enums;
using Slendernotes.Domain.Records;

namespace Slendernotes.Domain.Entities
{
    public sealed class Text : Entity
    {
        public TextContent TextContent { get; private set; }
        public string Title { get; private set; }
        public TextCategory Category { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public int UserId { get; private set; }



        public Text(Guid id, string textBody, string title, TextCategory category, int userId) : base(id)
        {
            TextContent = TextContent.Create(textBody);
            Title = title;
            Category = category;
            CreateDate = DateTime.UtcNow;
            UserId = userId;
            Validate(); 
        }

        

        public void UpdateContent(string newTextBody)
        {
            if (string.IsNullOrWhiteSpace(newTextBody))
                throw new Exception("Text body cannot be empty");

            TextContent = TextContent.Create(newTextBody);
        }

        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new Exception("Title cannot be empty");

            Title = newTitle;
            LastUpdateDate = DateTime.UtcNow;
        }

        public void ChangeCategory(TextCategory newCategory)
        {
            Category = newCategory;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(TextContent.Value))
                throw new Exception("Text body cannot be empty");

            if (string.IsNullOrWhiteSpace(Title))
                throw new Exception("Title cannot be empty");

            if (UserId <= 0)
                throw new Exception("Invalid user id");
        }

    }
}
