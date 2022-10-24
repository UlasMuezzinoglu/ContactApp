using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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

        //check duplicates
        public bool isExistsByPersonIdAndContactType(Guid personId, ContactTypeEnum contactType) {

            using (ContactAppContext context = new ContactAppContext())
            {
                var collection = (from models in context.ContactModels
                                  where models.ContactType == contactType
                                  where models.PersonId == personId
                                  select models);

                return collection.Any();
            }  
        }



        public Dictionary<string, int> GetTotalContactByLocation(String location) {
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (string.IsNullOrEmpty(location))
            {
                using (ContactAppContext context = new ContactAppContext())
                {
                    var collection = (from models in context.ContactModels
                                      where models.ContactType == ContactTypeEnum.LOCATION
                                      select models);

                    foreach (var line in collection.GroupBy(info => info.Content)
                        .Select(group => new
                        {
                            content = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.content))
                    {
                        result.Add(line.content, line.Count);
                    }
                    return result;
                }
            }
            else
            {
                using (ContactAppContext context = new ContactAppContext())
                {
                    var count = (from models in context.ContactModels
                                 where models.Content == location
                                 where models.ContactType == ContactTypeEnum.LOCATION
                                 select models).Count();
                    result.Add(location, count);
                    return result;
                }
            }
        }

        public Dictionary<string, int> GetTotalGsmCountByLocation(String location)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            

            if (string.IsNullOrEmpty(location))
            {
                using (ContactAppContext context = new ContactAppContext())
                {
                    int result = 0;

                    var tempModels = (from models in context.ContactModels
                                      where models.ContactType == ContactTypeEnum.LOCATION
                                      select models).OrderBy(i => i.Content).ToList();

                    string tempContent = string.Empty;

                    tempModels.ForEach(item =>
                    {
                        tempContent = item.Content;
                        
                        result += CountGsmByPerson(item.PersonId);

                        if (!map.ContainsKey(tempContent))
                        {
                            map.Add(tempContent, result);
                        }
                        else {
                            result += map.GetValueOrDefault(tempContent);
                            map.Remove(tempContent);
                            map.Add(item.Content, result);
                        }

                        result = 0;
                        tempContent = string.Empty;
                    });

                    
                    return map;
                }
            }
            else {
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

                    map.Add(location, result);
                    return map;
                }
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
