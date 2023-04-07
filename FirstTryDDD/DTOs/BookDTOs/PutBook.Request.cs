namespace FirstTryDDD.API.DTOs.BookDTOs
{
    public class PutBookRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalSells { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
