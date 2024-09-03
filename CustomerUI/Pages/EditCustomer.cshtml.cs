using CustomerUI.Models;
using CustomerUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerUI.Pages
{
    public class EditCustomerModel : PageModel
    {
        private readonly CustomerService _service;        

        public EditCustomerModel(CustomerService service)
        {
            _service = service;
        }

        [BindProperty]
        public Customer NewCustomer { get; set; } = new Customer();

        [TempData]
        public String StatusMessage { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                NewCustomer = await _service.GetCustomerAsync(id);
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || NewCustomer == null)
            {
                return Page();
            }

            try
            {
                StatusMessage = await _service.UpdateCustomerAsync(NewCustomer);
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            return RedirectToPage("Customer");
        }
    }
}
