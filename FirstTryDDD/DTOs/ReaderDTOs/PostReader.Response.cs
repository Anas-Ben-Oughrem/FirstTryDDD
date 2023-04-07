using FirstTryDDD.Core.AggregateModels.ReaderAggregate;

namespace FirstTryDDD.API.DTOs.ReaderDTOs
{
    public class PostReaderResponse
    {
        public PostReaderResponse(Reader reader )
        {
            Id = reader.Id;
            Name = reader.Name;
            UserName = reader.UserName;
            Password = reader.Password;
            Email = reader.Email;
            CreatedDate = reader.CreatedDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
