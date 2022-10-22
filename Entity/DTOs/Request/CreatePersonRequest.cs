using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Request
{
    public class CreatePersonRequest : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }

    }
}
