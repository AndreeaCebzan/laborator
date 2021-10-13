using System.Collections.Generic;
using Models;

namespace Repositories
{
    public class StudentRepo
    {
        public static List<StudentsAPI.Models> Students = new List<StudentsAPI.Models>() {
            new Student() { Id =1, Nume= "Cebzan", Prenume= "Andreea", Facultate="Ac", Sectie="IS" , An_studiu=4, Grupa=2},
            
        };
    }
}
