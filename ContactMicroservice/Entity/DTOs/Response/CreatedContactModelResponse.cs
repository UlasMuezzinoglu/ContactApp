using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Response
{
    public class CreatedContactModelResponse
    {
        public string content { get; set; }
        public ContactTypeEnum ContactType { get; set; }
    }
}
