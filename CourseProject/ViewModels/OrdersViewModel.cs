using CourseProject.DAL.Entity;
using System.Collections;

namespace CourseProject.ViewModels
{
    public class OrdersViewModel
    {
        internal string? lastOrdernum;

        public IEnumerable<Orders> Orders { get; set; }
        public List<OrdersItems> OrdersItems { get; set; }
        public OrdersDetail ordersDetail { get; set; }
        public string? LastOrdernum { get; set; }
        public IEnumerable<IGrouping<string, OrdersItems>>? GrupItems { get; set; }
        public string OrderNum { get; set; }
        public decimal Total { get; set; }
    }
}
