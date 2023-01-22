using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Domain.Entities
{
    public class Person : Entity
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Last_Update_Date { get; set; }
    }
}
