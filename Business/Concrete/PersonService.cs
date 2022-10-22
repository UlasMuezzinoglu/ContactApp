using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Request.Common;
using Entity.DTOs.Response;
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

        public List<PersonResponse> GetAll()
        {
            List<Person> people = _personDal.GetAll(item => !item.IsDeleted);

            return _mapper.Map<List<PersonResponse>>(people);
        }

        public PersonResponse GetDetail(ByIdRequest byIdRequest)
        {
            PersonResponse person = _personDal.GetDetail(byIdRequest);
            return person;
        }
    }
}
