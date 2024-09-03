using CustomerUI.Models;
using System.IO;
using System.Net.Http;

namespace CustomerUI.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("customer.api");
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            List<Customer> customers = [];

            try
            {
                //customers = await _httpClient.GetFromJsonAsync<List<Customer>>("") ?? [];                
                HttpResponseMessage response = await _httpClient.GetAsync("");

                response.EnsureSuccessStatusCode();
                
                if (response.IsSuccessStatusCode)
                {
                    customers = await response.Content.ReadFromJsonAsync<List<Customer>>() ?? [];
                }
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
            
            return customers;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            Customer customer = new Customer();

            try
            {
                //customers = await _httpClient.GetFromJsonAsync<List<Customer>>("") ?? [];                
                HttpResponseMessage response = await _httpClient.GetAsync(id.ToString());

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    customer = await response.Content.ReadFromJsonAsync<Customer>() ?? new Customer();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customer;
        }

        public async Task<String> AddCustomerAsync(Customer customer)
        {
            try 
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("", customer);
                response.EnsureSuccessStatusCode();                

                return "Customer created successfully";
            } 
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        public async Task<String> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync("", customer);
                response.EnsureSuccessStatusCode();

                return "Customer updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<String> DeleteCustomerAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(id.ToString());
                response.EnsureSuccessStatusCode();

                return "Customer deleted successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
