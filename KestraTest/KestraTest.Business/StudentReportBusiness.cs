using KestraTest.Contracts;
using KestraTest.Contracts.Business;
using KestraTest.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KestraTest.Business
{
    public class StudentReportBusiness : IStudentReportBusiness
    {
        private readonly IStudentGradeBusiness _studentGradeBusiness;
        private List<StudentGrade> StudentGrades = new List<StudentGrade>();

        public StudentReportBusiness(IStudentGradeBusiness studentGradeBusiness)
        {
            _studentGradeBusiness = studentGradeBusiness;
        }
        public List<StudentReport> GetStudentReport(string studentName, int? gradeGreatherThan, string subjectName)
        {
            List<StudentReport> result = new List<StudentReport>();
            StudentGrades = _studentGradeBusiness.GetStudentReportData();

            if (!string.IsNullOrEmpty(studentName))
                StudentGrades = StudentGrades.Where(x => x.Student.Name.ToUpper().Contains(studentName.ToUpper())).ToList();

            if (!string.IsNullOrEmpty(subjectName))
                StudentGrades = StudentGrades.Where(x => x.Subject.Name.ToUpper().Contains(subjectName.ToUpper())).ToList();

            if (gradeGreatherThan.HasValue)
                StudentGrades = StudentGrades.Where(x => x.Grade > gradeGreatherThan).ToList();

            result.AddRange(from lst in StudentGrades.Select(x => x.StudentId).Distinct() select new StudentReport() { StudentId = lst });

            foreach(StudentReport stu in result)
            {
                stu.Student = StudentGrades.Where(x => x.StudentId == stu.StudentId).FirstOrDefault().Student.Name;
                stu.LanguageArts = GetSubjectGrade((int)SubjectEnum.LanguageArts, stu.StudentId);
                stu.Maths = GetSubjectGrade((int)SubjectEnum.Maths, stu.StudentId);
                stu.Science = GetSubjectGrade((int)SubjectEnum.Science, stu.StudentId);
                stu.SocialStudies = GetSubjectGrade((int)SubjectEnum.SocialStudies, stu.StudentId);
            }

            return result;
        }

        private int? GetSubjectGrade(int subjectId, int studentId)
        {
            if (StudentGrades.Any(x => x.StudentId == studentId && x.SubjectId == subjectId))
                return StudentGrades.Where(x => x.StudentId == studentId && x.SubjectId == subjectId).FirstOrDefault().Grade;
            else
                return null;
        }
    }
}
