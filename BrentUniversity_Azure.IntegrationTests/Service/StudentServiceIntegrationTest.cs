using System;
using System.Linq;
using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Repository;
using BrentUniversity_Azure.Repository.Base;
using BrentUniversity_Azure.Service;
using BrentUniversity_Azure.Service.Base;
using BrentUniversity_Azure.TestCommon;
using NUnit.Framework;

namespace BrentUniversity_Azure.IntegrationTests.Service
{
    /// <summary>
    /// Student Service Retrieving Student By Id Integration Test
    /// </summary>
    [TestFixture]
    [Category("StudentServiceTests.Integration")]
    public class when_retrieving_student_by_id_using_student_service
    {
        #region Example Options With Explanations - Setup and Tear down

        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        //[TestFixtureSetUp]
        //public void InitialSetup()
        //{
        //}

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        //[TestFixtureTearDown]
        //public void FinalTearDown()
        //{
        //}

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        //[SetUp]
        //public void SetupForEachTest()
        //{
        //}

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        //[TearDown]
        //public void TearDownForEachTest()
        //{
        //}

        #endregion

        //Todo: Declare variables needed
        private Student _student;
        private IUnitOfWork _unitOfWork;
        private IStudentService _studentService;
        private IGenericRepository<Student> _studentRepository;
        
        [TestFixtureSetUp]
        public void Setup()
        {
            //Todo: Uncomment when using Automapper library
            //AutoMapperConfiguration.Configure();

            //Todo: New up objects and call your services and/or create repos and set private variables
            var context = new UniversityContext();
            _unitOfWork = new UnitOfWork(context);
            _studentRepository = _unitOfWork.GetRepository<Student>();
            _studentService = new StudentService(_unitOfWork, _studentRepository);
            _student = _studentService.GetById(1);
        }

        
        [Test]
        public void then_student_information_should_be_found()
        {
            //Todo: Check did test pass
            Assert.IsNotNull(_student);
            Assert.AreEqual(_student.Id, 1, "dbo.Student primary key - Id");
            Assert.AreEqual(_student.FirstName, "Carson", "dbo.Student column - FirstName");
            Assert.AreEqual(_student.LastName, "Alexander5551123", "dbo.Student column - LastName");
            Assert.AreEqual(_student.EnrollmentDate, new DateTime(2010,09,17,10,15,00), "dbo.Student column - EnrollmentDate");

        }

        
        [TestFixtureTearDown]
        public void TearDown()
        {
            //Todo: Undo your changes (ie: delete records saved in the database, created from Integration Test)
            //Nothing to tear down for GetById() method call
        }
    }

    /// <summary>
    /// Student Service Saving Student Integration Test
    /// </summary>
    [TestFixture]
    [Category("StudentServiceTests.Integration")]
    public class when_saving_student_using_student_service
    {
        #region Example Options With Explanations - Setup and Tear down

        /// <summary>
        /// This runs only once at the beginning of all tests and is used for all tests in the
        /// class.
        /// </summary>
        //[TestFixtureSetUp]
        //public void InitialSetup()
        //{
        //}

        /// <summary>
        /// This runs only once at the end of all tests and is used for all tests in the class.
        /// </summary>
        //[TestFixtureTearDown]
        //public void FinalTearDown()
        //{
        //}

        /// <summary>
        /// This setup funcitons runs before each test method
        /// </summary>
        //[SetUp]
        //public void SetupForEachTest()
        //{
        //}

        /// <summary>
        /// This setup funcitons runs after each test method
        /// </summary>
        //[TearDown]
        //public void TearDownForEachTest()
        //{
        //}

        #endregion

        //Todo: Declare variables needed
        private Student _student;
        private IUnitOfWork _unitOfWork;
        private IStudentService _studentService;
        private IGenericRepository<Student> _studentRepository;
        private bool _studentFound;

        [TestFixtureSetUp]
        public void Setup()
        {
            //Todo: Uncomment when using Automapper library
            //AutoMapperConfiguration.Configure();

            //Todo: New up objects and call your services and/or create repos and set private variables
            var context = new UniversityContext();
            _unitOfWork = new UnitOfWork(context);
            _studentRepository = _unitOfWork.GetRepository<Student>();
            _studentService = new StudentService(_unitOfWork, _studentRepository);
            _student = DataFactory.GetStudent;
            _studentService.Create(_student);
            _studentFound = _studentRepository.GetQuery().Any(x => x.Id == _student.Id);

        }


        [Test]
        public void then_student_information_should_be_saved_to_db()
        {
            //Todo: Check did test pass
            Assert.IsNotNull(_student, "When creating the student failed because the instance is still null");
            Assert.True(_student.Id != 0, "When checking the Student.Id, it still equals 0 and should NOT");
            Assert.IsTrue(_studentFound, "When trying to find the Student by Student.Id, the student was NOT found");
            Assert.AreEqual(_student.FirstName, DataFactory.GetStudent.FirstName, "Student First Name was NOT the same as previously set with DataFactory");
            Assert.AreEqual(_student.LastName, DataFactory.GetStudent.LastName, "Student Last Name was NOT the same as previously set with DataFactory");
        }


        [TestFixtureTearDown]
        public void TearDown()
        {
            //Todo: Undo your changes (ie: delete records saved in the database, created from Integration Test)
            if (_student == null || _student.Id == 0) return;

            _studentRepository.Delete(_student);
            _studentRepository.Save();
        }
    }
}
