using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication11.ViewModels
{
    public class UploadImageViewModel 
    {
        [Required]
        [Display(Name = "Image")]
        public IFormFile ProductPicture { get; set; }

    }
}
