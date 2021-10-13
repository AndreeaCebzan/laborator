using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string Prenume { get; set; }
        public string Facultate { get; set; }
        public string Sectie { get; set; }

        public int An_studiu { get; set; }
        public int Grupa { get; set; }
    }
}
