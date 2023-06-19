namespace EcommerceClothing.Models
{
    public class Output
    {
        public string Key { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
