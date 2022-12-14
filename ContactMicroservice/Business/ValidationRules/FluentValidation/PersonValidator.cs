using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Firstname).Length(3,35);
            RuleFor(person => person.Lastname).Length(3, 35);
            RuleFor(person => person.Company).Length(3, 35);

        }
    }
}
