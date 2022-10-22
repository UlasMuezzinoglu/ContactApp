using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MapperProfiles.PersonMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
        }

    }
}
