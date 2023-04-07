using FirstTryDDD.Core.AggregateModels.ReaderAggregate;

namespace FirstTryDDD.API.DTOs.ReaderDTOs
{
    public class GetAllReadersResponse
    {
        public GetAllReadersResponse(Reader reader)
        {
            Name = reader.Name;
            UserName = reader.UserName;
            Email = reader.Email;
            Id = reader.Id;
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}
