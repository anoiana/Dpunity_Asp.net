using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
     public class User
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public string Passwordhash { get; set; }
        public string Role { get; set; }

    }
}
