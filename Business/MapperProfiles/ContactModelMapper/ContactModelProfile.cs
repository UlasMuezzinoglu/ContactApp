using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MapperProfiles.ContactModelMapper
{
    public class ContactModelProfile : Profile
    {
        public ContactModelProfile()
        {
            CreateMap<ContactModel, CreateContactModelRequest>().ReverseMap();
            CreateMap<ContactModel, CreatedContactModelResponse>().ReverseMap();

        }

    }
}
