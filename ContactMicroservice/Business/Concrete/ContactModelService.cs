using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
    public class ContactModelService : IContactModelService
    {
        private readonly IContactModelDal _contactModelDal;
        private readonly IMapper _mapper;

        public ContactModelService(IContactModelDal contactModelDal , IMapper mapper)
        {
            _contactModelDal = contactModelDal;
            _mapper = mapper;

        }



        public CreatedContactModelResponse Add(CreateContactModelRequest createContactModelRequest)
        {
            ContactModel contactModel = _mapper.Map<ContactModel>(createContactModelRequest);
            _contactModelDal.Add(contactModel);

            return _mapper.Map<CreatedContactModelResponse>(contactModel);
        }

        public string Delete(ByIdRequest byIdRequest)
        {
            ContactModel deletedContactModel = _contactModelDal.Get(c => c.Id == byIdRequest.Id);
            deletedContactModel.IsDeleted = true;
            _contactModelDal.Update(deletedContactModel);

            return "SUCCESS";
        }

        public int GetTotalContactByLocation(string location)
        {
           return _contactModelDal.GetTotalContactByLocation(location);
        }

        public int GetTotalGsmCountByLocation(string location)
        {
            return _contactModelDal.GetTotalGsmCountByLocation(location);
        }

        public Dictionary<string,int> GetAllReportTypes(string location)
        {
            Dictionary<string,int> result = new Dictionary<string,int>();
            result.Add("peopleCount", GetTotalContactByLocation(location));
            result.Add("gsmCount", GetTotalGsmCountByLocation(location));
            return result;
        }




    }
}
