using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts
{
    public class StudentReport
    {
        public string Student { get; set; }

        public int StudentId { get; set;  }

        public int? LanguageArts { get; set; }

        public int? Science { get; set; }

        public int? SocialStudies { get; set; }

        public int? Maths { get; set; }

    }
}
