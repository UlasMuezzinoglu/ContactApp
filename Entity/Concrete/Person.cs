using Core.Entities;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Person : ParentEntity,IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
    }
}
