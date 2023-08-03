using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repositories.Interfaces;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public async Task<List<CustomerListDto>> GetAll()
        {

        }
    }
}
