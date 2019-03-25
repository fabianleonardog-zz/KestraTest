using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts.DataAccess
{
    public interface IStudentGradeRepository : IRepository<StudentGrade>
    {
        List<StudentGrade> GetStudentReportData();
    }
}
