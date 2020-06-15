using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarjestelma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Jarjestelma.Pages.AsiakasLista
{
    public class IndexModel : PageModel
    {
        private readonly SovellusDbContext _db;

        /* Yhteys tietokantaan */
        public IndexModel(SovellusDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Customers> Customers { get; set; }


        //Asetetaan Customersille tietokantataulun data
        public async Task OnGet()
        {
            Customers = await _db.Customers.ToListAsync();
        }

        //Poistetaan asiakas listasta id arvolla
        public async Task<IActionResult> OnPostPoista(string id)
        {
            var Customer = await _db.Customers.FindAsync(id);

            if(Customer == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}