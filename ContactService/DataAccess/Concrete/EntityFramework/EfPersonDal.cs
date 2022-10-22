using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Request.Common;
using Entity.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, ContactAppContext>, IPersonDal
    {
        public PersonResponse GetDetail(ByIdRequest byIdRequest)
        {
            using (ContactAppContext context = new ContactAppContext()) {
                var person = from cm in context.ContactModels
                             join per in context.Persons
                             on cm.PersonId equals per.Id
                             where per.Id == byIdRequest.Id
                             select new PersonResponse
                             {
                                 PersonId = per.Id,
                                 Firstname = per.Firstname,
                                 Lastname = per.Lastname,
                                 Company = per.Company,
                             };
                var contacts = from cm in context.ContactModels
                               where cm.PersonId == byIdRequest.Id
                               select cm;

                var model = person.FirstOrDefault();

                model.ContactModels = contacts.ToList();

                return model;
            }
        }
    }
}
