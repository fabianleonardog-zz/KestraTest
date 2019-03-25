using KestraTest.Contracts;
using KestraTest.Contracts.DataAccess;
using KestraTest.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.DataAccess.Repository
{
    public class SubjectRepository: BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(KestraStudentContext context)
        {
            base.context = context;
        }
    }
}
