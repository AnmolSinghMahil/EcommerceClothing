namespace EcommerceClothing.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AvailableProduct> AvailableProducts { get; set; }
    }
}
