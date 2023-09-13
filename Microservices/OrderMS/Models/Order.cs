namespace OrderMS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal PriceTotal { get; set;} = 0;
        public string ProductName { get; set; }
        public int ProductID { get; set; }
    }
}
