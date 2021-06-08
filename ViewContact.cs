using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    interface IOperationalMethods
    {
        public void ContactViewMethod();
        public void Listview();
        public void NewContact();
        public void DeleteContact();
        public void EditContact();

    }
    class ViewContact : IOperationalMethods
    {

        public static List<Contact> contactsList = new List<Contact>();

        public void ContactViewMethod()
        {
            Contact Person1 = new Contact
            {
                FirstName = "Harsh",
                LastName = "Sinha",
                Address = "Hoshangabad Road",
                City = "Bhopal",
                State = "Madhya Pradesh",
                ZipCode = 32344,
                PhoneNumber = 1234567890,
                Email = "JohnWick.com"
            };
            Contact Person2 = new Contact
            {
                FirstName = "Joh",
                LastName = "Joe",
                Address = "Australia",
                City = "punjab",
                State = "Munich",
                ZipCode = 87869,
                PhoneNumber = 1234567890,
                Email = "JoeDoe@rmail.com"
            };
            Person1.ValidateContactDetails();
            Person2.ValidateContactDetails();

            //storing contact details to List
            contactsList.Add(Person1);
            contactsList.Add(Person2);

        }
        public List<Contact> GetLIst()
        {
            return contactsList;
        }

        public void Listview()
        {
            try
            {
                if (contactsList.Count == 0)
                    Console.WriteLine("No Contacts to Display");
                else
                {
                    foreach (Contact i in contactsList)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Contacts");
                        Console.WriteLine($"Full Name: {i.FirstName} {i.LastName}");
                        Console.WriteLine($"Phone Number: {i.PhoneNumber}");
                        Console.WriteLine($"Email: {i.Email}");
                        Console.WriteLine($"Address: {i.Address}, \n \t{i.City}, {i.State}, {i.ZipCode}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// New contact method - ask user to enter all details. using console
        /// </summary>
        public void NewContact()
        {
            try
            {
                Contact Person3 = new Contact();
                Console.WriteLine("Add a new contact.");
                Console.WriteLine("Enter First Name: ");
                Person3.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                Person3.LastName = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                Person3.Address = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                Person3.City = Console.ReadLine();
                Console.WriteLine("Enter State: ");
                Person3.State = Console.ReadLine();
                Console.WriteLine("Enter ZipCode: ");
                Person3.ZipCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone Number: ");
                Person3.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email: ");
                Person3.Email = Console.ReadLine();
                //validating contact details
                Person3.ValidateContactDetails();
                //adding contact to list
                contactsList.Add(Person3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("New contact entry aborted.");

            }

        }
        public void DeleteContact()
        {
            try
            {
                if (contactsList.Count == 0)
                {
                    Console.WriteLine("No Contacts available to Delete");
                }
                else
                {
                    int i = 0;
                    Console.WriteLine("Select the contact you want to Delete : ");
                    foreach (Contact contacts in ViewContact.contactsList)
                    {

                        Console.WriteLine($" press {i} for {contacts.FirstName}");
                        i++;
                    }

                    {
                        Console.WriteLine();
                    }
                    int sel = Convert.ToInt32(Console.ReadLine());
                    while (sel >= i || sel < 0)
                    {
                        Console.WriteLine("invalid choice made,");
                        Console.WriteLine("enter a valid choice");
                        sel = Convert.ToInt32(Console.ReadLine());
                    }
                    contactsList.RemoveAt(sel);
                    Console.WriteLine("Contact deleted successfully!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
