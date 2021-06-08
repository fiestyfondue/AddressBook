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
    class ContactView : IOperationalMethods
    {
        public static List<Contact> contactsList = new List<Contact>();
        public Contact Person3 = new Contact();
        public void ContactViewMethod()
        {
            Contact Person1 = new Contact
            {
                FirstName = "John",
                LastName = "Wick",
                Address = "Bakers Street",
                City = "London",
                State = "UK",
                ZipCode = 11556,
                PhoneNumber = 1234567890,
                Email = "DontKillmyDog@dogmail.com"
            };
            Contact Person2 = new Contact
            {
                FirstName = "Joey",
                LastName = "Diaz",
                Address = "Hyderabad",
                City = "Mumbai",
                State ="MP",
                ZipCode = 45345,
                PhoneNumber = 1234567890,
                Email = "JoeDiaaz@Gmail.com"
            };
            Person1.ValidateContactDetails();
            Person2.ValidateContactDetails();
            //storing contact details to List
            contactsList.Add(Person1);
            contactsList.Add(Person2);
        }
        /// <summary>
        /// Display Contact details template.
        /// </summary>
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
                //global object 'Person3' is used.//
                CustomInput(Person3);
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

        /// <summary>
        /// delete a contact method using an index of list entered by user.
        /// check for contacts available in list
        /// if no contacts display message and end.
        /// else ask for delete using index of list.
        /// </summary>
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
                    foreach (Contact contacts in ContactView.contactsList)
                    {
                        Console.WriteLine($" press {i} for {contacts.FirstName}");
                        i++;
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
        /// <summary>
        /// edit a contact using a index ask ask for details and replace
        /// the details with appropriate details.
        /// </summary>
        public void EditContact()
        {
            try
            {
                if (contactsList.Count == 0)
                {
                    Console.WriteLine("No Contacts available to Edit");
                }
                else
                {
                    int i = 0;
                    Console.WriteLine("Select the contact you want to Edit : ");
                    foreach (Contact contacts in ContactView.contactsList)
                    {

                        Console.WriteLine($" press {i} for {contacts.FirstName}");
                        i++;
                    }
                    int sel = Convert.ToInt32(Console.ReadLine());
                    while (sel >= i || sel < 0)
                    {
                        Console.WriteLine("invalid choice made,");
                        Console.WriteLine("enter a valid choice");
                        sel = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("-------Before editing-------");
                    CustomView(sel);
                    Console.WriteLine("Enter new Details");
                    //global object 'Person3' is used.//
                    CustomInput(Person3);
                    //validating contact details
                    Person3.ValidateContactDetails();
                    //removing contact
                    contactsList.RemoveAt(sel);
                    //adding new details of contact at list
                    contactsList.Insert(sel, Person3);
                    Console.WriteLine();
                    Console.WriteLine("Contact edit successful!!");
                    Console.WriteLine("-------After editing-------");
                    CustomView(sel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Add multiple persons to contact.
        /// </summary>
        private List<Contact> tempContactList = new List<Contact>();
        public void MultipleContact()
        {
            try
            {
                char input = AddPersonOption();
                input = Char.ToUpper(input);
                switch (input)
                {
                    case 'Y':
                        CustomInput(Person3);
                        Person3.ValidateContactDetails();
                        tempContactList.Add(Person3);
                        MultipleContact();
                        break;
                    case 'N':
                        contactsList.AddRange(tempContactList);
                        break;
                    default:
                        Console.WriteLine("Invalid input. enter valid choice.");
                        MultipleContact();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private char AddPersonOption()
        {
            Console.WriteLine("Add another Person?");
            Console.WriteLine("type Y/y for YES.");
            Console.WriteLine("type N/n for NO");
            char input = Convert.ToChar(Console.ReadLine());
            return input;
        }

        /// <summary>
        /// custom display template for edit contact 
        /// sel- is parameter that passes appropriate selected contact index.
        /// </summary>
        /// <param name="sel"></param>
        private void CustomView(int sel)
        {
            Console.WriteLine();
            Console.WriteLine("Contacts");
            Console.WriteLine($"Full Name: {contactsList[sel].FirstName} {contactsList[sel].LastName}");
            Console.WriteLine($"Phone Number: {contactsList[sel].PhoneNumber}");
            Console.WriteLine($"Email: {contactsList[sel].Email}");
            Console.WriteLine($"Address: {contactsList[sel].Address}, \n \t{contactsList[sel].City}, {contactsList[sel].State}, {contactsList[sel].ZipCode}");
            Console.WriteLine();
        }

        public void CustomInput(Contact Person)
        {
            Console.WriteLine("Add a new contact.");
            Console.WriteLine("Enter First Name: ");
            Person.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            Person.LastName = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            Person.Address = Console.ReadLine();
            Console.WriteLine("Enter City: ");
            Person.City = Console.ReadLine();
            Console.WriteLine("Enter State: ");
            Person.State = Console.ReadLine();
            Console.WriteLine("Enter ZipCode: ");
            var input = Console.ReadLine();
            while (true)
            {
                if (Int32.TryParse(input, out _))
                {
                    Person.ZipCode = Convert.ToInt32(input);
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Input!! try again.");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Phone Number: ");
            input = Console.ReadLine();
            while (true)
            {
                if (Int64.TryParse(input, out _))
                {
                    Person.PhoneNumber = Convert.ToInt64(input);
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Input!! try again.");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter Email: ");
            Person.Email = Console.ReadLine();
        }
    }
}
    
    

