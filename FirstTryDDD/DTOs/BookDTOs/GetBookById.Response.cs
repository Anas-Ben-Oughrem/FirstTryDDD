using FirstTryDDD.Core.AggregateModels.BookAggregate;

namespace FirstTryDDD.API.DTOs.BookDTOs
{
    public class GetBookByIdResponse
    {
        public GetBookByIdResponse(Book book)
        {
            Title = book.Title;
            Uri = book.Uri;
            PublishedDate = book.PublishedDate;
            TotalSells = book.TotalSells;
        }

        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }
    }
}
