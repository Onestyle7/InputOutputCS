using InputOutput.Data;
using InputOutput.Models;
using InputOutput.Repositories;

namespace InputOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\klusb\\Desktop\\InputOutputCS\\InputOutput\\Data\\contact.json";
            DataAccess dataAccess = new DataAccess(filePath);
            ContactRepository contactRepository = new ContactRepository(dataAccess);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Witaj w aplikacji do zarządzania kontaktami!");
                Console.WriteLine("1: Wyświetl wszystkie kontakty");
                Console.WriteLine("2: Dodaj nowy kontakt");
                Console.WriteLine("3: Zaktualizuj istniejący kontakt");
                Console.WriteLine("4: Usuń kontakt");
                Console.WriteLine("5: Wyszukaj kontakt");
                Console.WriteLine("6: Zakończ program");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var contacts = contactRepository.GetAllContacts();
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine($"Imię: {contact.FirstName}, Nazwisko: {contact.LastName}, Numer telefonu: {contact.PhoneNumber}, Email: {contact.Email}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Podaj imię:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Podaj numer telefonu:");
                        string phoneNumber = Console.ReadLine();
                        Console.WriteLine("Podaj email:");
                        string email = Console.ReadLine();

                        Contact newContact = new Contact
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber,
                            Email = email
                        };

                        contactRepository.AddContact(newContact);
                        break;

                    case "3":
                        Console.WriteLine("Który kontakt chcesz zaktualizować?");

                        string contactIdToUpdate = Console.ReadLine();
                        int contactId = int.Parse(contactIdToUpdate);

                        Contact contactToUpdate = contactRepository.FindContact(contactId);

                        Console.WriteLine(contactToUpdate);

                        Console.WriteLine("Podaj nowe imię:");
                        string newFirstName = Console.ReadLine();
                        Console.WriteLine("Podaj nowe nazwisko:");
                        string newLastName = Console.ReadLine();
                        Console.WriteLine("Podaj nowy numer telefonu:");
                        string newPhoneNumber = Console.ReadLine();
                        Console.WriteLine("Podaj nowy email:");
                        string newEmail = Console.ReadLine();

                        contactToUpdate.FirstName = newFirstName;
                        contactToUpdate.LastName = newLastName;
                        contactToUpdate.PhoneNumber = newPhoneNumber;
                        contactToUpdate.Email = newEmail;

                        contactRepository.UpdateContact(contactToUpdate);
                        break;
                    case "4":
                        Console.WriteLine("Który kontakt chcesz usunąć?");
                        string contactIdToDelete = Console.ReadLine();
                        int contactIdDelete = int.Parse(contactIdToDelete);

                        contactRepository.DeleteContact(contactIdDelete);
                        break;
                    case "5":
                        Console.WriteLine("Podaj szukane słowo: (Imie lub nazwisko)");
                        string searchTerm = Console.ReadLine();

                        var foundContacts = contactRepository.FindContacts(searchTerm);
                        foreach (var contact in foundContacts)
                        {
                            Console.WriteLine($"Imię: {contact.FirstName}, Nazwisko: {contact.LastName}, Numer telefonu: {contact.PhoneNumber}, Email: {contact.Email}");
                        }
                        break;
                    case "6":
                        exit = true;
                        break;

                }
            }
        }
    }
}
