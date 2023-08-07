
using Domain.Entities;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
       public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}
