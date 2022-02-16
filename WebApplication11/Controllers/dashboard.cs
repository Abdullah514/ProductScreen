using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Data;
using WebApplication11.Models;

namespace WebApplication11.Admin
{
    public class dashboard : Controller
    {
        private readonly DatabaseContaxt _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public dashboard(DatabaseContaxt context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;

            webHostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,ProductName,ProductPrice,ProfilePicture")] ProductModel productModel)

        public async Task<IActionResult> Create(IFormFile files, ProductModel pm)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");

                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    string filePath = Path.Combine(uploadsFolder, newFileName);

                    // ProductModel objm = new ProductModel();
                    //  var objfilesa = new ProductModel()

                    var obj = new ProductModel()

                    {
                        //  Id = 0,

                        ProductName = pm.ProductName,
                        ProductPrice = pm.ProductPrice,
                        Description = pm.Description,
                        ProfilePicture = newFileName,


                    };

                    using (var fileStream = new FileStream(filePath, FileMode.Create)) //temporry arry binary
                    {
                        files.CopyTo(fileStream);
                    }

                    _context.ProductModels.Add(obj);
                    _context.SaveChanges();
                    ModelState.Clear();
                }
            }
            return View();
        }

    }
}
