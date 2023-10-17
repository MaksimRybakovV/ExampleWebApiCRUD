using ExampleWebApiCRUD.Entities.Enums;

namespace ExampleWebApiCRUD.Entities.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public Genders Gender { get; set; }
    }
}
