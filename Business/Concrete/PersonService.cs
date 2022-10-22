using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Request.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDal _personDal;

        private readonly IMapper _mapper;

        public PersonService(IPersonDal personDal, IMapper mapper)
        {
            _personDal = personDal;
            _mapper = mapper;
        }
        public String Add(CreatePersonRequest createPersonRequest)
        {
            Person person = _mapper.Map<Person>(createPersonRequest);
          

            _personDal.Add(person);

            return "SUCCESS";
        }

        public string Delete(ByIdRequest byIdRequest)
        {
            Person deletedPerson = _personDal.Get(person => person.Id == byIdRequest.Id);
            deletedPerson.IsDeleted = true;
            _personDal.Update(deletedPerson);

            return "SUCCESS";
        }
    }
}
