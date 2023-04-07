using FirstTryDDD.Core.AggregateModels.BookAggregate;

namespace FirstTryDDD.API.DTOs.BookDTOs
{
    public class PostBookResponse
    {
        public PostBookResponse(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Uri = book.Uri;
            PublishedDate = book.PublishedDate;
            TotalSells = book.TotalSells;
            CreatedDate = book.CreatedDate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
