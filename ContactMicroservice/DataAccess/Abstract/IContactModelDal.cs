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
        int GetTotalContactByLocation(String location);

        int GetTotalGsmCountByLocation(String location);
    }
}
