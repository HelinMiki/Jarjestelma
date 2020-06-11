using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarjestelma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Jarjestelma.Pages.AsiakasLista
{
    public class LisaaModel : PageModel
    {
        private readonly SovellusDbContext _db;

        public LisaaModel(SovellusDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customers Customer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Customers.AddAsync(Customer);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}