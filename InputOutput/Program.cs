using InputOutput.Data;
using InputOutput.Models;

namespace InputOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\klusb\\Desktop\\InputOutputCS\\InputOutput\\Data\\contact.json";
            DataAccess dataAccess = new DataAccess(filePath);
            List<Contact> contacts = dataAccess.ReadUserDefinedContacts();

            foreach(var contact in contacts)
            {
                Console.WriteLine($"First Name: {contact.FirstName}");
                Console.WriteLine($"Last Name: {contact.LastName}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine("-----------------------------");
            }

            Contact newContact = new Contact
            {
                FirstName = "Ted",
                LastName = "Doom",
                PhoneNumber = "723-455-7890",
                Email = "Ted@gmail.com"
            };

            contacts.Add(newContact);
            dataAccess.WriteUserDefinedContacts(contacts);
            Console.WriteLine("Dodaje kontakty....");
            Thread.Sleep(2000);

            var lastContact = contacts.Last();
            Console.WriteLine("Ostatni kontakt dodany:");
            Console.WriteLine($"First Name: {lastContact.FirstName}");
            Console.WriteLine($"Last Name: {lastContact.LastName}");
            Console.WriteLine($"Phone Number: {lastContact.PhoneNumber}");
            Console.WriteLine($"Email: {lastContact.Email}");


            Console.ReadLine();
        }
    }
}
