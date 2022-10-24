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
        CreatedContactModelResponse Add(CreateContactModelRequest createContactModelRequest);
        String Delete(ByIdRequest byIdRequest);

        Dictionary<string,int> GetTotalContactByLocation(string location);

        Dictionary<string, int> GetTotalGsmCountByLocation(string location);

        Dictionary<string, Dictionary<string, int>> GetAllReportTypes(string location);
    }
}
