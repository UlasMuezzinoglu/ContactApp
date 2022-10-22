﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Request;
using Entity.DTOs.Request.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        String Add(CreatePersonRequest createPersonRequest);

        String Delete(ByIdRequest byIdRequest);
    }
}
