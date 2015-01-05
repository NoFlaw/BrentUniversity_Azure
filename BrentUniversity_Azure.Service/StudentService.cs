using System;
using System.Collections.Generic;
using System.Linq;
using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Repository.Base;
using BrentUniversity_Azure.Service.Base;

namespace BrentUniversity_Azure.Service
{
    public class StudentService : EntityService<Student>, IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IUnitOfWork unitOfWork, IGenericRepository<Student> studentRepository)
            : base(unitOfWork, studentRepository)
        {
            _studentRepository = unitOfWork.GetRepository<Student>();
        }

        public Student GetById(int id)
        {
            try
            {
                return _studentRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Unable to retrieve the student by the provided Id: {0}, Error: {1}", id, ex));
            }
        }

        public IEnumerable<Student> GetAllStudentsWithEnrollmentsAndFiltered()
        {
            const int pageNumber = 1;
            const int pageSize = 20;

            int totalStudentCount;

            return _studentRepository.Query().Include(i => i.Enrollments)
                    .OrderBy(q => q
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName))
                    .Filter(q => q.Enrollments != null)
                    .GetPage(pageNumber, pageSize, out totalStudentCount);
        }

    }
}
