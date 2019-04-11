using System.Collections.Generic;

namespace SweetShop.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cake> Cakes { get; set; }
    }
}