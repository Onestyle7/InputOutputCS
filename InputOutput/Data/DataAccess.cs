using InputOutput.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InputOutput.Data
{
    public class DataAccess
    {
        private string _filePath;

        public DataAccess(string filePath) 
        {
            _filePath = filePath;
        }
        public List<Contact> ReadUserDefinedContacts()
        {
            using StreamReader reader = new StreamReader(_filePath);
            var json = reader.ReadToEnd();

            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(json);

            return contacts;
        }
        public void WriteUserDefinedContacts(List<Contact> contacts)
        {
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
