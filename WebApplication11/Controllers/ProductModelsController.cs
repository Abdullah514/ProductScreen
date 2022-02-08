#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Models;
using WebApplication11.ViewModels;

namespace WebApplication11.Controllers
{
   public class ProductModelsController : Controller

    { 
        private readonly DatabaseContaxt _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductModelsController(DatabaseContaxt context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
     
            webHostEnvironment = hostEnvironment;
            
        }


      

        // GET: ProductModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductModels.ToListAsync());
        }


        


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("Id,ProductName,ProductPrice,ProfilePicture")] ProductModel productModel)

        public async Task<IActionResult> Create(IFormFile files,ProductModel mp)
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
                        ProductName = mp.ProductName,
                        ProductPrice = mp.ProductPrice,
                        ProfilePicture = newFileName,

                        // ProductName = "Img/" + newFileName,
                       
                        // FileType = fileExtension,
                     //   CreatedOn = DateTime.Now
                    };

                    using (var fileStream = new FileStream(filePath, FileMode.Create)) //temporry arry binary
                    {
                        files.CopyTo(fileStream);
                    }

                    _context.ProductModels.Add(obj);
                    _context.SaveChanges();

                }
            }
            return View();
        }
        //public async Task<IActionResult> Get()
        //{
        //    var employee = await _context.Files.ToListAsync();
        //    return View(employee);   



        // GET: ProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels
            .FirstOrDefaultAsync(m => m.Id == id);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    // GET: ProductModels/Create
    //public IActionResult Create()
    //{
    //    return View();
    //}

    // POST: ProductModels/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,ProductName,ProductPrice,ProfilePicture")] ProductModel productModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(productModel);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(productModel);
    //}

    // GET: ProductModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels.FindAsync(id);
        if (productModel == null)
        {
            return NotFound();
        }
        return View(productModel);
    }

    // POST: ProductModels/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ProductPrice,ProfilePicture")] ProductModel productModel)
    {
        if (id != productModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(productModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(productModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(productModel);
    }

    // GET: ProductModels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productModel = await _context.ProductModels
            .FirstOrDefaultAsync(m => m.Id == id);
        if (productModel == null)
        {
            return NotFound();
        }

        return View(productModel);
    }

    // POST: ProductModels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var productModel = await _context.ProductModels.FindAsync(id);
        _context.ProductModels.Remove(productModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductModelExists(int id)
    {
        return _context.ProductModels.Any(e => e.Id == id);
    }






        //private string ProcessUploadedFile(ProductModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ProfilePicture != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ProfilePicture.CopyTo(fileStream);
        //        }
        //    }

        //    return uniqueFileName;
        //}






    }
}
