using System;

namespace SweetShop.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public byte[] ContentType { get; set; }
    }
}