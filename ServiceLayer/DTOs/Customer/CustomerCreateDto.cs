using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ServiceLayer.DTOs.Customer
{
    public class CustomerCreateDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }

    public class CustomerCreateValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateValidator()
        {
           RuleFor(m => m.FullName).NotEmpty().WithMessage("Please Add Full Name");

        }
    }

}
