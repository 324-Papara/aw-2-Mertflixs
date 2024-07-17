using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(3, 15)
                .WithMessage("First name length must be between 3-15 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(1, 15)
                .WithMessage("Last name length must be between 1-15 characters!");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty()
                .Length(11)
                .WithMessage("Identity number must be 11 characters!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .Length(11, 100)
                .WithMessage("Email must be between 11-100 characters!");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty();

            RuleFor(x => x.CustomerNumber)
                .NotEmpty()
                .InclusiveBetween(1, 100000)
                .WithMessage("Customer number must be between 1-100000");
        }
    }
}
