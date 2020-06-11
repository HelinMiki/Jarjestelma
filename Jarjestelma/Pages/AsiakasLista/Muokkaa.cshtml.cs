using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarjestelma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jarjestelma.Pages.AsiakasLista
{
    public class MuokkaaModel : PageModel
    {
        private SovellusDbContext _db;

        public MuokkaaModel(SovellusDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customers Customer { get; set; }

        //Haetaan asiakkaan ID, jotta saadaan yhteys Muokkaa.cshtml tiedostoon.
        public async Task OnGet(string id)
        {
            Customer = await _db.Customers.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            //Haetaan asiakkaan data tietokannasta ja asetetaan sille haluttu data.
            if (ModelState.IsValid)
            {
                var DbCustomer = await _db.Customers.FindAsync(Customer.CustomerID);

                DbCustomer.CustomerID = Customer.CustomerID;
                DbCustomer.CompanyName = Customer.CompanyName;
                DbCustomer.ContactName = Customer.ContactName;
                DbCustomer.ContactTitle = Customer.ContactTitle;
                DbCustomer.Address = Customer.Address;
                DbCustomer.PostalCode = Customer.PostalCode;
                DbCustomer.City = Customer.City;
                DbCustomer.Region = Customer.Region;
                DbCustomer.Country = Customer.Country;
                DbCustomer.Phone = Customer.Phone;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}