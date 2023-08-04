using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository.Repositories.Interfaces;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

   
        public async Task<List<CustomerListDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            return _mapper.Map<List<CustomerListDto>>(model);
        }
    }
}
