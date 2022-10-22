using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonService : IPersonService
    {
        IPersonDal _personDal;

        public PersonService(IPersonDal personDal)
        {
            _personDal = personDal;
        }
        public string Add(CreatePersonRequest createPersonRequest)
        {
            Person person = new Person();
            person.Firstname = createPersonRequest.Firstname;
            person.Lastname = createPersonRequest.Lastname;
            person.Company = createPersonRequest.Company;

            _personDal.Add(person);

            return "success";
        }
    }
}
