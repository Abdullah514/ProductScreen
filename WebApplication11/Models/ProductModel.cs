using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
       
        public string ProfilePicture { get; set; }
        
        //public IFormFile ProfilePicture { get; set; }
       
    }
}
