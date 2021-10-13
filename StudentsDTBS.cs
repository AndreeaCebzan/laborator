using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StudentsAPI.Models
{
    public class StudentsDTBS :DbContext
    {
        public StudentsDTBS(DbContextOptions<StudentsDTBS> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
