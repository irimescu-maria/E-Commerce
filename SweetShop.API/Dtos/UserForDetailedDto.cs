using System;

namespace SweetShop.API.Dtos
{
    public class UserForDetailedDto
    {
         public int Id { get; set; }
        public string Username { get; set; }
       public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime LatActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}