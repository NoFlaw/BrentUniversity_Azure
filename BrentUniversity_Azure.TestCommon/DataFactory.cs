using System;
using System.Collections.Generic;
using System.Linq;
using BrentUniversity_Azure.Data;

namespace BrentUniversity_Azure.TestCommon
{
    public static class DataFactory
    {
        public enum Grade
        {
            A = 1, B = 2, C = 3, D = 4, F = 5
        }
        public static Student GetStudent = new Student
        {
                FirstName = "Brenton",
                LastName = "Bates",
                EnrollmentDate = DateTime.Now
        };
        

        public static IEnumerable<Student> GetStudents = new List<Student>()
        {
            new Student
            {
                FirstName = "Gytis",
                LastName = "Barzdukas",
                EnrollmentDate = DateTime.Parse("2012-09-01")
            },
            new Student
            {
                FirstName = "Yan",
                LastName = "Li",
                EnrollmentDate = DateTime.Parse("2012-09-01")
            },
            new Student
            {
                FirstName = "Peggy",
                LastName = "Justice",
                EnrollmentDate = DateTime.Parse("2011-09-01")
            },
            new Student
            {
                FirstName = "Laura",
                LastName = "Norman",
                EnrollmentDate = DateTime.Parse("2013-09-01")
            },
            new Student
            {
                FirstName = "Nino",
                LastName = "Olivetto",
                EnrollmentDate = DateTime.Parse("2005-09-01")
            }
        };

        public static IEnumerable<Instructor> GetInstructors = new List<Instructor>()
        {
            new Instructor
            {
                FirstName = "Kim",
                LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11")
            },
            new Instructor
            {
                FirstName = "Fadi",
                LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06")
            },
            new Instructor
            {
                FirstName = "Roger",
                LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01")
            },
            new Instructor
            {
                FirstName = "Candace",
                LastName = "Kapoor",
                HireDate = DateTime.Parse("2001-01-15")
            },
            new Instructor
            {
                FirstName = "Roger",
                LastName = "Zheng",
                HireDate = DateTime.Parse("2004-02-12")
            }
        };

        public static IEnumerable<Department> GetDepartments = new List<Department>
        {
            new Department
            {
                Name = "English",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorId = GetInstructors.Single(i => i.LastName == "Abercrombie").ID
            },
            new Department
            {
                Name = "Mathematics",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorId = GetInstructors.Single(i => i.LastName == "Fakhouri").ID
            },
            new Department
            {
                Name = "Engineering",
                Budget = 350000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorId = GetInstructors.Single(i => i.LastName == "Harui").ID
            },
            new Department
            {
                Name = "Economics",
                Budget = 100000,
                StartDate = DateTime.Parse("2007-09-01"),
                InstructorId = GetInstructors.Single(i => i.LastName == "Kapoor").ID
            }
        };

        public static IEnumerable<Course> GetCourses = new List<Course>
        {
            new Course
            {
                CourseId = 1050,
                Title = "Chemistry",
                Credits = 3,
                DepartmentId = GetDepartments.Single(s => s.Name == "Engineering").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 4022,
                Title = "Microeconomics",
                Credits = 3,
                DepartmentId = GetDepartments.Single(s => s.Name == "Economics").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 4041,
                Title = "Macroeconomics",
                Credits = 3,
                DepartmentId = GetDepartments.Single(s => s.Name == "Economics").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 1045,
                Title = "Calculus",
                Credits = 4,
                DepartmentId = GetDepartments.Single(s => s.Name == "Mathematics").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 3141,
                Title = "Trigonometry",
                Credits = 4,
                DepartmentId = GetDepartments.Single(s => s.Name == "Mathematics").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 2021,
                Title = "Composition",
                Credits = 3,
                DepartmentId = GetDepartments.Single(s => s.Name == "English").DepartmentId,
                Instructors = new List<Instructor>()
            },
            new Course
            {
                CourseId = 2042,
                Title = "Literature",
                Credits = 4,
                DepartmentId = GetDepartments.Single(s => s.Name == "English").DepartmentId,
                Instructors = new List<Instructor>()
            },
        };

        //Todo: Fix, this causes when_creating_a_student test to fail, most likely due to missing Instructor IDs
        //public static IEnumerable<OfficeAssignment> OfficeAssignments = new List<OfficeAssignment>
        //{
        //    new OfficeAssignment
        //    {
        //        InstructorId = GetInstructors.Single(i => i.LastName == "Fakhouri").ID,
        //        Location = "Smith 17"
        //    },
        //    new OfficeAssignment
        //    {
        //        InstructorId = GetInstructors.Single(i => i.LastName == "Harui").ID,
        //        Location = "Gowan 27"
        //    },
        //    new OfficeAssignment
        //    {
        //        InstructorId = GetInstructors.Single(i => i.LastName == "Kapoor").ID,
        //        Location = "Thompson 304"
        //    },
        //};

        //public static IEnumerable<Enrollment> GetEnrollments = new List<Enrollment>
        //{
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alexander").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Chemistry").CourseId,
        //        Grade = (int)Grade.A
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alexander").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Microeconomics").CourseId,
        //        Grade = (int)Grade.C
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alexander").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Macroeconomics").CourseId,
        //        Grade = (int)Grade.B
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alonso").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Calculus").CourseId,
        //        Grade = (int)Grade.B
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alonso").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Trigonometry").CourseId,
        //        Grade = (int)Grade.B
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Alonso").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Composition").CourseId,
        //        Grade = (int)Grade.B
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Anand").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Chemistry").CourseId
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Anand").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Microeconomics").CourseId,
        //        Grade = (int)Grade.B
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Barzdukas").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Chemistry").CourseId,
        //        Grade = (int)Grade.D
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Li").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Composition").CourseId,
        //        Grade = (int)Grade.C
        //    },
        //    new Enrollment
        //    {
        //        StudentId = GetStudents.Single(s => s.LastName == "Justice").Id,
        //        CourseId = GetCourses.Single(c => c.Title == "Literature").CourseId,
        //        Grade = (int)Grade.F
        //    }
        //};
    }
}
