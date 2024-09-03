using CustomerWebAPI.Database;
using CustomerWebAPI.Models;
using CustomerWebAPI.Repositories.Interfaces;

namespace CustomerWebAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public int CreateCustomer(Customer customer)
        {
            using var context = new DataContext();
            int id = context.Customers.Add(customer).Entity.Id;
            context.SaveChanges();

            return id;
        }

        public List<Customer> GetCustomers()
        {
            using var context = new DataContext();
            var list = context.Customers.ToList();

            return list;
        }

        public Customer GetCustomer(int id)
        {
            using var context = new DataContext();
            Customer? Customer = context.Customers.Find(id);

            return Customer ?? throw new KeyNotFoundException("Customer not found");
        }

        public int UpdateCustomer(Customer customer)
        {
            using var context = new DataContext();
            int id = context.Customers.Update(customer).Entity.Id;
            context.SaveChanges();
            
            return id;
        }

        public void DeleteCustomer(int id)
        {
            using var context = new DataContext();
            Customer ?customer = context.Customers.Find(id);

            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
        
    }
}
