using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Request
{
    public class CreateContactModelRequest
    {
        public ContactTypeEnum ContactType { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
    }
}
