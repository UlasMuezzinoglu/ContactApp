using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Request.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContactModelDal : EfEntityRepositoryBase<ContactModel, ContactAppContext>, IContactModelDal
    {
        public int GetTotalContactByLocation(String location) {

            using (ContactAppContext context = new ContactAppContext())
            {
                var count = (from models in context.ContactModels
                              where models.Content == location
                              where models.ContactType == ContactTypeEnum.LOCATION
                              select models).Count();

                return count;
            }
        }


        public int GetTotalGsmCountByLocation(String location)
        {
            using (ContactAppContext context = new ContactAppContext())
            {
                int result = 0;

                var tempModels = (from models in context.ContactModels
                                 where models.Content == location
                                 select models).ToList();

                tempModels.ForEach(item =>
                {
                    result += CountGsmByPerson(item.PersonId);
                });


                return result;
            }
        }

        private int CountGsmByPerson(Guid personId)
        {
            using (ContactAppContext context = new ContactAppContext())
            {
                var tempModels = (from models in context.ContactModels
                                 where models.PersonId == personId
                                 where models.ContactType == ContactTypeEnum.PHONE
                                 select models);

                return tempModels.Count();
            }
        }
    }
}
