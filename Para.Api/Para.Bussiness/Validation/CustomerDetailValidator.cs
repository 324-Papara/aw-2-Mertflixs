using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validation
{
    public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
    {
        public CustomerDetailValidator()
        {
            RuleFor(x => x.FatherName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.MotherName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.MontlyIncome)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.Occupation)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}