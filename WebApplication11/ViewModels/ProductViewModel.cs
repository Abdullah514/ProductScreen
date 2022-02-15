using System.ComponentModel.DataAnnotations;

namespace WebApplication11.ViewModels
{


    public class ProductViewModel : EditImageViewModel  
    {  
   
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProfilePicture { get; set; }


    }  
}  
//}
