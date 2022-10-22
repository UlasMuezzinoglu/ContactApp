using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Request.Common;
using Entity.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactModelService
    {
        CreatedContactModelResponse add(CreateContactModelRequest createContactModelRequest);
        String delete(ByIdRequest byIdRequest);
    }
}
