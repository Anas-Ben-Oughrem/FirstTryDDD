namespace FirstTryDDD.API.DTOs.BookDTOs
{
    public class PostBookRequest
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
