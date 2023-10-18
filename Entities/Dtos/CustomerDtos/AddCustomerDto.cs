using ExampleWebApiCRUD.Entities.Enums;

namespace ExampleWebApiCRUD.Entities.Dtos.CustomerDtos
{
    public class AddCustomerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public Genders Gender { get; set; }
    }
}
