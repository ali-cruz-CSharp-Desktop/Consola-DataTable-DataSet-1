using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConexionSQL01.Models
{
    class People
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Edad { get; set; }

    }
}
