using System.Collections.Generic;

namespace DemoLibrary.Logic
{
    public interface IPersonHandler
    {
        Person CreatePerson(string firstName, string lastName, double height);
        List<Person> LoadPeople();
        void SavePerson(Person person);
        void UpdatePerson(Person person);
    }
}