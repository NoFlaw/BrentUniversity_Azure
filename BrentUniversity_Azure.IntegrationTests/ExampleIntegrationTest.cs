using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock;

namespace BrentUniversity_Azure.IntegrationTests
{
    /// <summary>
    /// A Example Integration Test
    /// </summary>
    [TestFixture]
    [Category("ExampleTests.Integration")]
    public class when_making_an_example_integration_test
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
        
        //You would declare your variables here
        //private Person _person;
            
        [TestFixtureSetUp]
        public void Setup()
        {
            //Todo: Uncomment when using Automapper library
            //AutoMapperConfiguration.Configure();

            //Todo: New up objects and call your services and/or create repos and set private variables
            //var model = new SomeClass();
            //_repository = new Repository<DbObject>(model);
            //var service = new Service(_repository);
            //_person = service.FindById(1);
        }

        
        [Test]
        public void this_is_a_fake_test()
        {
            //Todo: Check for did test pass
            //Assert.IsNotNull(_person);
        }

        
        [TestFixtureTearDown]
        public void TearDown()
        {
            //Todo: Delete whatever you did (example: records saved in the database, when created in the Integration Test)
            //_repository.Delete(_person);
            //_repository.SaveChanges();
        }
    }
}
