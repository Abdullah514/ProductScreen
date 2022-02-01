using System.ComponentModel.DataAnnotations;

namespace WebApplication11.ViewModels
{
    //public class ProductViewModel : EditImageViewModel
    //{
    //    [Required]
    //    [Display(Name = "Name")]
    //    public string ProductName { get; set; }
    //    [Required]        
    //    public decimal ProductPrice { get; set; }
    //    [Required]
    //    public string Venue { get; set; }
    //}


    public class ProductViewModel : EditImageViewModel  
    {  
   
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProfilePicture { get; set; }


    }  
}  
//}
