using FirstTryDDD.Core.AggregateModels.BookAggregate;

namespace FirstTryDDD.API.DTOs.BookDTOs
{
    public class PutBookResponse
    {
        public PutBookResponse(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Uri = book.Uri;
            PublishedDate = book.PublishedDate;
            TotalSells = book.TotalSells;
            UpdatedDate = book.UpdatedDate;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
