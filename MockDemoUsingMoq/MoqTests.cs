using Autofac.Extras.Moq;
using DemoLibrary.Logic;
using DemoLibrary.Database;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MockDemoUsingMoq
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadPeople_ValidCall()
        {
            using (AutoMock mock = AutoMock.GetLoose())
            {
                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.LoadData<Person>("select * from Person"))
                    .Returns(GetSamplePeople());

                PersonHandler client = mock.Create<PersonHandler>();
                List<Person> expected = GetSamplePeople();

                List<Person> actual = client.LoadPeople();

                Assert.True(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].FirstName, actual[i].FirstName);
                    Assert.AreEqual(expected[i].LastName, actual[i].LastName);
                }
            }
        }

        [Test]
        public void SavePeople_ValidCall()
        {
            using (AutoMock mock = AutoMock.GetLoose())
            {

                //TDD
                //mock.Mock<ISqliteDataAccess>()
                    //.Verify(x => x.SaveData(person, sql), Times.Exactly(1));
            }

        }

        private List<Person> GetSamplePeople()
        {
            List<Person> output = new List<Person>
            {
                new Person
                {
                    FirstName = "SpongeBob",
                    LastName = "SquarePants"
                },
                new Person
                {
                    FirstName = "Jerry",
                    LastName = "Bytheway"
                },
                new Person
                {
                    FirstName = "BigHead",
                    LastName = "SnipersDream"
                }
            };

            return output;
        }
    }
}