using DemoLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class App : IApp
    {
        IPersonHandler personHandler;

        public App(IPersonHandler handler)
        {
            personHandler = handler;
        }

        public void Run()
        {
            string selection = "";

            do
            {
                selection = GetActionChoice();

                Console.WriteLine();

                switch (selection)
                {
                    case "1":
                        DisplayPeople(personHandler.LoadPeople());
                        break;
                    case "2":
                        AddPerson();
                        break;
                    case "3":
                        Console.WriteLine("Thanks for using this application");
                        break;
                    default:
                        Console.WriteLine("That was an invalid choice. Hit enter and try again.");
                        break;
                }

                Console.WriteLine("Hit return to continue...");
                Console.ReadLine();

            } while (selection != "3");
        }

        private void AddPerson()
        {
            Console.Write("What is the person's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("What is the person's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("What is the person's height: ");
            string height = Console.ReadLine();
            double Height = 0;
            if (double.TryParse(height, out double result))
            {
                Height = result;
            }

            Person person = personHandler.CreatePerson(firstName, lastName, Height);
            personHandler.SavePerson(person);
        }

        private void DisplayPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine(p.FullName);
            }
        }

        private string GetActionChoice()
        {
            string output = "";

            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1 | Load People");
            Console.WriteLine("2 | Create and Save Person");
            Console.WriteLine("3 | Exit Program");
            Console.Write("Selection: ");
            output = Console.ReadLine();

            return output;
        }
    }
}
