using InputOutput.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutput.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int contactId);
        Contact FindContact(int contactId);
        List<Contact> FindContacts(string searchTerm);
    }
}
