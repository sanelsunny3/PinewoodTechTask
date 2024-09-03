using CustomerWebAPI.Models;

namespace CustomerWebAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public int CreateCustomer(Customer customer);
        public List<Customer> GetCustomers();
        public Customer GetCustomer(int id);        
        public int UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);
    }
}
