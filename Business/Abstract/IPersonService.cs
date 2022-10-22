using Core.Utilities.Results;
using Entity.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        string Add(CreatePersonRequest createPersonRequest);
    }
}
