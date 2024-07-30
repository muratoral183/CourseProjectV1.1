namespace CourseProject.DAL.Entity
{
    public class OrdersItems
    {
        public int OrdersItemsId { get; set; }
        public string OrderNum { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
