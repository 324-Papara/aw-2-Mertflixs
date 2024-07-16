using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validation
{
    public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .Length(1, 25)
                .WithMessage("Country must be 1-25 characters !");
            RuleFor(x => x.City)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("City must be 1-100 characters !");
            RuleFor(x => x.AddressLine)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Adressline maximum length 200 characters !");
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(5, 11)
                .WithMessage("ZipCode must be 5-11 characters !");
        }
    }
}