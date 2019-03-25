using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts.Business
{
    public interface IStudentReportBusiness
    {
        List<StudentReport> GetStudentReport(string studentName, int? gradeGreatherThan, string subjectName);
    }
}
