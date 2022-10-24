using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ApplyReportRequest : IDto
    {
        public string Location { get; set; }
    }
}
