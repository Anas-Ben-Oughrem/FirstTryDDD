using FirstTryDDD.Core.AggregateModels.AuthorAggregate;

namespace FirstTryDDD.API.DTOs.AuthorDTOs
{
    public class GetAllAuthorsResponse
    {
        public GetAllAuthorsResponse(Author author ) 
        { 
            Id = author.Id;
            Name = author.Name;
            PhoneNumber = author.PhoneNumber;
            Age = author.Age;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
    }
}
