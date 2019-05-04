namespace SweetShop.API.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public string ShoppingCartId { get; set; }

        public int Amount { get; set; }

        public Cake Cake { get; set; }
    }
}