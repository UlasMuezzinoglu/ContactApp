using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs.Request.Common;
using Entity.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        PersonResponse GetDetail(ByIdRequest byIdRequest);
    }
}
