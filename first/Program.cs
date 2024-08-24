using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ContactManager
{

       static Dictionary<string, string> contacts = new Dictionary<string, string>();

    public void AddContact(string name, string number)
    {
        if (contacts.ContainsKey(name))
        {
            Console.WriteLine($"Contact '{name}' already exists. Use a different name.");
        }
        else
        {
            contacts[name] = number;
            Console.WriteLine($"Contact '{name}' added successfully.");
        }
    }

    public void DeleteContact(string name)
    {
        if (contacts.Remove(name))
        {
            Console.WriteLine($"Contact '{name}' deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Contact '{name}' not found.");
        }
    }

    public void SearchContact(string name)
    {
        if (contacts.TryGetValue(name, out string number))
        {
            Console.WriteLine($"Contact found: {name} - {number}");
        }
        else
        {
            Console.WriteLine($"Contact '{name}' not found.");
        }
    }

    public void DisplayAllContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
        }
        else
        {
            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Key}: {contact.Value}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContactManager manager = new ContactManager();

        while (true)
        {
            Console.WriteLine("\nContact Manager");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Display All Contacts");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter contact name: ");
                    string NameToAdd = Console.ReadLine();
                    Console.Write("Enter contact number: ");
                    string NumberToAdd = Console.ReadLine();
                    manager.AddContact(NameToAdd, NumberToAdd);
                    break;

                case "2":
                    Console.Write("Enter contact name to delete: ");
                    string nameToDelete = Console.ReadLine();
                    manager.DeleteContact(nameToDelete);
                    break;

                case "3":
                    Console.Write("Enter contact name to search: ");
                    string nameToSearch = Console.ReadLine();
                    manager.SearchContact(nameToSearch);
                    break;

                case "4":
                    manager.DisplayAllContacts();
                    break;

                case "5":
                    Console.WriteLine("Exiting the Contact Manager.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
