using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public abstract class ParentEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        public bool IsDeleted { get; set; } = false;
    }
}
