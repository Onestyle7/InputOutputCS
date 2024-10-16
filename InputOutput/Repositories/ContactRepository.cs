using InputOutput.Data;
using InputOutput.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutput.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataAccess _dataAccess;
        private List<Contact> _contacts;

        public ContactRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _contacts = _dataAccess.ReadUserDefinedContacts();
        }

        public void AddContact(Contact contact)
        {
            contact.contactId = _contacts.Max(c => c.contactId) + 1;
            _contacts.Add(contact);
            _dataAccess.WriteUserDefinedContacts(_contacts);
        }

        public void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.contactId == contactId);
            if(contact != null)
            {
                _contacts.Remove(contact);
                _dataAccess.WriteUserDefinedContacts(_contacts);
            }
            else
            {
                throw new Exception("Contact not found");
            }
        }

        public Contact FindContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.contactId == contactId);
            return contact;
        }

        public List<Contact> FindContacts(string searchTerm)
        {
            return _contacts.Where(c =>
                c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) 
                ||
                c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.contactId == contact.contactId);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Email = contact.Email;
                _dataAccess.WriteUserDefinedContacts(_contacts);
            }
            else
            {
                throw new Exception("Contact not found");
            }
        }
    }
}
