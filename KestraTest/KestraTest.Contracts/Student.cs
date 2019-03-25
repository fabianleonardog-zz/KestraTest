using System;
using System.Collections.Generic;

namespace KestraTest.Contracts
{
    public partial class Student
    {
        public Student()
        {
            StudentGrade = new HashSet<StudentGrade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
