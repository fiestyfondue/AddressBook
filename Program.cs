using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// Address book program - UC1 creating contact in addressbook
        /// storing name address phone number email
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Contact contacts = new Contact
            {
                FirstName = "John",
                LastName = "Wick",
                Address = "Bakers Street",
                City = "London",
                State = "UK",
                ZipCode = 44520,
                PhoneNumber = 1234567890,
                Email = "harsh.21483@gmail.com"       //for contact
            };
            contacts.ValidateContactDetails();
            Console.WriteLine("Contact Details: ");
            Console.WriteLine($"Full Name: {contacts.FirstName + contacts.LastName} ");
            Console.WriteLine($"Phone Number: {contacts.PhoneNumber} ");
            Console.WriteLine($"Address: {contacts.Address} \n \t{contacts.City} {contacts.State} \n \t{contacts.ZipCode} ");
            Console.WriteLine($"Email: {contacts.Email} ");

            Showcase display = new Showcase();
            ContactView VW = new ContactView();
            VW.ContactViewMethod();
            display.DisplayChoice();
            display.Selection();
        }
    }
}
