using FirstTryDDD.Core.AggregateModels.ReaderAggregate;

namespace FirstTryDDD.API.DTOs.ReaderDTOs
{
    public class PutReaderResponse
    {
        public PutReaderResponse(Reader reader)
        {
            Id = reader.Id;
            Name = reader.Name;
            UserName = reader.UserName;
            Email = reader.Email;
            Password = reader.Password;
            UpdatedDate = reader.UpdatedDate;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
