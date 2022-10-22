using Core.Entities;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ContactModel : ParentEntity, IEntity
    {
        public ContactTypeEnum ContactType { get; set; }
        public string content { get; set; }
    }
}
