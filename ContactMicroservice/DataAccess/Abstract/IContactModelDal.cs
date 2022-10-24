using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContactModelDal : IEntityRepository<ContactModel>
    {

        bool isExistsByPersonIdAndContactType(Guid personId, ContactTypeEnum contactType);
        Dictionary<string, int> GetTotalContactByLocation(String location);

        Dictionary<string, int> GetTotalGsmCountByLocation(String location);
    }
}
