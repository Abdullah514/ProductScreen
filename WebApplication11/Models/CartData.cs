using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class CartData
    {
       
            [Key]
            public int CartId { get; set; }
            public int ProductId { get; set; }
            public string UserId { get; set; }

        

            //public IFormFile ProfilePicture { get; set; }

       
    }
}
