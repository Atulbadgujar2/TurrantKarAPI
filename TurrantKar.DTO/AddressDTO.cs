using TurrantKar.Entity;

namespace TurrantKar.DTO
{
    public class AddressDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public int CustomerId { get; set; }

        public static Address MapToEntity(AddressDTO model)
        {
            Address entity = new Address();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Company = model.Company;
            entity.County = model.County;
            entity.City = model.City;
            entity.PhoneNumber = model.PhoneNumber;
            entity.ZipPostalCode = model.ZipPostalCode;
            entity.FaxNumber = model.FaxNumber;
            entity.Address1 = model.Address1;
            entity.Address2 = model.Address2;          
            return entity;
        }

        public static Address MapToEntityWithEntity(AddressDTO model, Address entity)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Company = model.Company;
            entity.County = model.County;
            entity.City = model.City;
            entity.PhoneNumber = model.PhoneNumber;
            entity.ZipPostalCode = model.ZipPostalCode;
            entity.FaxNumber = model.FaxNumber;
            entity.Address1 = model.Address1;
            entity.Address2 = model.Address2;

            return entity;
        }
    }
}
