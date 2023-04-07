namespace FirstTryDDD.API.DTOs.ReaderDTOs
{
    public class PutReaderRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }
    }
}
