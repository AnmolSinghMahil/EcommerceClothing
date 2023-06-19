namespace EcommerceClothing.Models
{
    public class AvailableProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }
}
