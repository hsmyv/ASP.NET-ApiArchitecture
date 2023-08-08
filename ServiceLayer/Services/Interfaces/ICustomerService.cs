using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.DTOs.Customer;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetAllAsync();
        Task InsertAsync(CustomerCreateDto customer);
        Task UpdateAsync(int id, CustomerEditDto customer);
        Task<CustomerListDto> GetByNameAsync(string name);
        Task<IEnumerable<CustomerListDto>> GetAllByConditionAsync(string search);

    }
}
