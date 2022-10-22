using Core.Entities;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Response
{
    public class PersonResponse : IDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }

        public List<ContactModel> ContactModels { get; set; }

        public Guid Id { get; set; }
    }
}
