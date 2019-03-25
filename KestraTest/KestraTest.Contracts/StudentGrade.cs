using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts
{
    public partial class StudentGrade
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
