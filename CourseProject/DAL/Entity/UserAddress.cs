using System.ComponentModel.DataAnnotations;

namespace CourseProject.DAL.Entity
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
   
    }
}
