using FirstTryDDD.Core.AggregateModels.ReaderAggregate;

namespace FirstTryDDD.API.DTOs.ReaderDTOs
{
    public class GetReaderByIdResponse
    {
        public GetReaderByIdResponse(Reader reader)
        {
            Name = reader.Name;
            UserName = reader.UserName;
            Email = reader.Email;
            Id = reader.Id;
            CreatedDate = reader.CreatedDate;
            UpdatedDate = reader.UpdatedDate;
            Password = reader.Password;
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
