using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerUI.Services;
using CustomerUI.Models;

namespace CustomerUI.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly CustomerService _service;

        public IList<Customer> CustomerList { get; set; } = [];

        [TempData]
        public String StatusMessage { get; set; }

        [BindProperty]
        public Customer NewCustomer { get; set; } = default!;

        public CustomerModel(CustomerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                CustomerList = await _service.GetCustomersAsync();
            }
            catch (Exception ex) 
            {
                StatusMessage = ex.Message;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || NewCustomer == null)
            {
                return Page();
            }

            try
            {
                StatusMessage = await _service.AddCustomerAsync(NewCustomer);
            }
            catch (Exception ex) 
            {
                StatusMessage = ex.Message;
            }            

            return RedirectToAction("Get");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try 
            {
                StatusMessage = await _service.DeleteCustomerAsync(id);
            } 
            catch (Exception ex) 
            { 
                StatusMessage = ex.Message;
            }

            return RedirectToAction("Get");            
        }
    }
}
