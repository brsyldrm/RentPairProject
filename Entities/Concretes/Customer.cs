using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }

    }
}
