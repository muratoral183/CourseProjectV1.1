using System.ComponentModel.DataAnnotations;

namespace CourseProject.DAL.Entity
{
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        public string OrderNum { get; set; }
        public double VatTotal { get; set; }
        public double SubTotal { get; set; }
        public int PaymentType { get; set; }
      
    }
}
