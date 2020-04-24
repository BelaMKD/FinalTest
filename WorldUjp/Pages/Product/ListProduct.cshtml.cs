using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorldUjp.Pages.Product
{
    public class ListProductModel : PageModel
    {
        private readonly ITaxPayerRepository taxPayerRepository;
        public Core.TaxPayer TaxPayer { get; set; }
        public ListProductModel(ITaxPayerRepository taxPayerRepository)
        {
            this.taxPayerRepository = taxPayerRepository;
        }
        public void OnGet(int id)
        {
            TaxPayer = taxPayerRepository.GetTaxPayer(id);
        }
    }
}