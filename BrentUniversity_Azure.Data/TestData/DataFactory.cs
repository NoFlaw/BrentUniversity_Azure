using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrentUniversity_Azure.Data.TestData
{
    public static class DataFactory
    {
        public static Student GetStudent()
        {
            return new Student
            {
                FirstName = "Brenton",
                LastName = "Bates",
                EnrollmentDate = DateTime.Now
            };
        }

        public static List<Student> GetStudents  = new List<Student>() 
        {
            new Student { FirstName = "Gytis",    LastName = "Barzdukas", 
                EnrollmentDate = DateTime.Parse("2012-09-01") },
            new Student { FirstName = "Yan",      LastName = "Li",        
                EnrollmentDate = DateTime.Parse("2012-09-01") },
            new Student { FirstName = "Peggy",    LastName = "Justice",   
                EnrollmentDate = DateTime.Parse("2011-09-01") },
            new Student { FirstName = "Laura",    LastName = "Norman",    
                EnrollmentDate = DateTime.Parse("2013-09-01") },
            new Student { FirstName = "Nino",     LastName = "Olivetto",  
                EnrollmentDate = DateTime.Parse("2005-09-01") }
        };

        public static List<Instructor> GetInstructors = new List<Instructor>
        {
            new Instructor { FirstName = "Kim",     LastName = "Abercrombie", 
                HireDate = DateTime.Parse("1995-03-11") },
            new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",    
                HireDate = DateTime.Parse("2002-07-06") },
            new Instructor { FirstName = "Roger",   LastName = "Harui",       
                HireDate = DateTime.Parse("1998-07-01") },
            new Instructor { FirstName = "Candace", LastName = "Kapoor",      
                HireDate = DateTime.Parse("2001-01-15") },
            new Instructor { FirstName = "Roger",   LastName = "Zheng",      
                HireDate = DateTime.Parse("2004-02-12") }
        };

        public static List<Department> GetDepartments = new List<Department>
        {
            new Department { Name = "English",     Budget = 350000, 
                StartDate = DateTime.Parse("2007-09-01"), 
                InstructorId  = GetInstructors.Single( i => i.LastName == "Abercrombie").ID },
            new Department { Name = "Mathematics", Budget = 100000, 
                StartDate = DateTime.Parse("2007-09-01"), 
                InstructorId  = GetInstructors.Single( i => i.LastName == "Fakhouri").ID },
            new Department { Name = "Engineering", Budget = 350000, 
                StartDate = DateTime.Parse("2007-09-01"), 
                InstructorId  = GetInstructors.Single( i => i.LastName == "Harui").ID },
            new Department { Name = "Economics",   Budget = 100000, 
                StartDate = DateTime.Parse("2007-09-01"), 
                InstructorId  = GetInstructors.Single( i => i.LastName == "Kapoor").ID }
        };
    }
}
