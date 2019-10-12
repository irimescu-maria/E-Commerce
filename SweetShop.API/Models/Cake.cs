namespace SweetShop.API.Models
{
    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }  
    }
}