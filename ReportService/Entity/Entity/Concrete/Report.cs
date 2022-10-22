using Core.Entities;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Report : ParentEntity, IEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime CompletedDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string FilePath { get; set; }
    }
}
