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
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            bool addMore = true;

            while (addMore)
            {
                Console.WriteLine("Czy chcesz dodać kontakty? ");
                Console.WriteLine("1.Tak/2.Nie");
                if(Console.ReadLine() == "2")
                {
                    addMore = false;
                    break;
                }
                Console.WriteLine("Podaj Imie:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Podaj Nazwisko:");
                string lastName = Console.ReadLine();
                Console.WriteLine("Podaj Numer Telefonu:");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Podaj Email:");
                string email = Console.ReadLine();

                Contact contact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email
                };
                contacts.Add(contact);
                Console.WriteLine("Kontakt został dodany.");
            }
            dataAccess.WriteUserDefinedContacts(contacts);
            Console.WriteLine("Dodaje kontakty....");

            Thread.Sleep(1000);
            Console.WriteLine("Kontakty zostały dodane do twojego pliku!");

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
