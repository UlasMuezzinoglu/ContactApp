using Core.Entities;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Contact : ParentEntity , IEntity
    {
        public Guid PersonId { get; set; }
        public Guid ContactModelId { get; set; }
    }
}
