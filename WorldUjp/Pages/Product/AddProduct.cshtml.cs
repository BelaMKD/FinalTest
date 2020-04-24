using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorldUjp.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ITaxPayerRepository taxPayerRepository;
        private readonly IDDVRepository dDVRepository;
        [BindProperty]
        public Core.TaxPayer TaxPayer { get; set; }
        [BindProperty]
        public Core.Product Product { get; set; }
        public string Message { get; set; }
        public List<SelectListItem> DDVs { get; set; }
        public AddProductModel(IProductRepository productRepository, ITaxPayerRepository taxPayerRepository, IDDVRepository dDVRepository)
        {
            this.productRepository = productRepository;
            this.taxPayerRepository = taxPayerRepository;
            this.dDVRepository = dDVRepository;
        }
        public void OnGet(int id)
        {
            TaxPayer = taxPayerRepository.GetTaxPayer(id);
            Product = new Core.Product();
            DDVs = dDVRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Tax.ToString("P")
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Product.Price > 0)
                {
                    Product.TaxPayerId = TaxPayer.Id;
                    TaxPayer.Products.Add(productRepository.CreateProduct(Product));
                    productRepository.Commit();
                    return RedirectToPage("./ListProduct", new { id = TaxPayer.Id });
                }
            }

            DDVs = dDVRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Tax.ToString("P")
            }).ToList();
            Message = "Price must be greater then 0";
            return Page();
        }
    }
}