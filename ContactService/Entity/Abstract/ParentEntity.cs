using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Abstract
{
    public abstract class ParentEntity
    {
        public Guid Id { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
