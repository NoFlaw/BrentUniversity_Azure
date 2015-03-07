using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Service;
using NUnit.Framework;
using Telerik.JustMock;

namespace BrentUniversity_Azure.UnitTests.Service
{
    /// <summary>
    /// StudentService Unit Tests
    /// </summary>
    
    [TestFixture]
    [Category("StudentService.Unit")]
    public sealed class when_retrieving_student_by_id : Specification<StudentService, Student> 
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

        private const int Id = 1;

        /// <summary>
        /// Step 1 - Arrange (Create the objects and prepare the test)
        /// </summary>
        protected override void Arrange()
        {
            //Todo: New up objects and call your services and/or create repos and set private variables
            MockingContainer.Arrange<StudentService>(x => x.GetById(Id)).Returns(Arg.IsAny<Student>).OccursOnce();
        }

        /// <summary>
        /// Step 2 - Act (Call the method)
        /// </summary>
        protected override Student Act()
        {
            //Todo: Do Work
            return MockingContainer.Instance.GetById(Id);
            
        }

        /// <summary>
        /// Step 3 - Assert (Make sure what you expect is true)
        /// </summary>
        [Test]
        public void test_for_when_retrieving_student_by_id()
        {
            //Todo: Check did test pass
            MockingContainer.AssertAll();

        }

    }
}
