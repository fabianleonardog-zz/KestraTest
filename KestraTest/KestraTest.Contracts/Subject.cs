using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts
{
    public class Subject
    {
        public Subject()
        {
            StudentGrade = new HashSet<StudentGrade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
