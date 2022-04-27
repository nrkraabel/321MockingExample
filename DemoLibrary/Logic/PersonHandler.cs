using DemoLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Logic
{
    public class PersonHandler : IPersonHandler
    {
        ISqliteDataAccess database;

        public PersonHandler(ISqliteDataAccess database)
        {
            this.database = database;
        }

        public Person CreatePerson(string firstName, string lastName, double height)
        {
            Person person = new Person();

            if (ValidateName(firstName) == true)
            {
                person.FirstName = firstName;
            }
            else
            {
                throw new ArgumentException("The value was not valid", "firstName");
            }

            if (ValidateName(lastName) == true)
            {
                person.LastName = lastName;
            }
            else
            {
                throw new ArgumentException("The value was not valid", "lastName");
            }
            person.Height = height;


            return person;
        }

        public List<Person> LoadPeople()
        {
            string sql = "select * from Person";

            var output = this.database.LoadData<Person>(sql);

            return output;
        }

        public void SavePerson(Person person)
        {
            string sql = "insert into Person (FirstName, LastName, HeightInInches) " +
                "values (@FirstName, @LastName, @HeightInInches)";

            sql = sql.Replace("@FirstName", $"'{ person.FirstName }'");
            sql = sql.Replace("@LastName", $"'{ person.LastName }'");
            sql = sql.Replace("@HeightInInches", $"{ person.Height }");
            this.database.SaveData(person, sql);
        }

        public void UpdatePerson(Person person)
        {
            string sql = "update Person set FirstName = @FirstName, LastName = @LastName" +
                ", HeightInInches = @HeightInInches where Id = @Id";

            this.database.UpdateData(person, sql);
        }

        private bool ValidateName(string name)
        {
            bool output = true;
            char[] invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

            if (name.Length < 2)
            {
                output = false;
            }

            if (name.IndexOfAny(invalidCharacters) >= 0)
            {
                output = false;
            }

            return output;
        }
    }
}
