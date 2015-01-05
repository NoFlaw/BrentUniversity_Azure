using System.Collections.Generic;
using BrentUniversity_Azure.Data;

namespace BrentUniversity_Azure.Service.Base
{
    public interface IStudentService : IEntityService<Student>
    {
        Student GetById(int id);
        IEnumerable<Student> GetAllStudentsWithEnrollmentsAndFiltered();
    }
}
