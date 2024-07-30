using System.ComponentModel.DataAnnotations;

namespace CourseProject.DAL.Entity
{
    public class OrdersDetail
    {
        [Key]
        public int OrdersDetailId { get; set; }
        public string OrderNum { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string? Apartment { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Note { get; set; }

      
    }
}
