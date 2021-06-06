using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AddressBook
{
    class AddressBook
    {
        private Contact[] _entries;
        private int _totalEntries = 0;

        public int Size { get; private set; }
        
        public AddressBook(int size)            //Constructor of AddressBook Class
        {
            _entries = new Contact[size];
            Size = size;
        }
        public void NewEntry()
        {
            if (_totalEntries < _entries.Length)
            {
                Console.WriteLine("New Entry");
                Contact contact = new Contact();
                {
                    //FirstName = InputValidator.LetterInput(Console.ReadLine());
                    char FirstName = Convert.ToChar(Console.ReadLine());
                    char LastName = Convert.ToChar(Console.ReadLine());
                    int PhoneNumber = Convert.ToInt32(Console.ReadLine());
                    char HomeAddress = Convert.ToChar(Console.ReadLine());
                    char EmailAddress = Convert.ToChar(Console.ReadLine());
                };

                _entries[_totalEntries++] = contact;
                Console.WriteLine("Added successfully!");
            }
            else
            {
                Console.WriteLine("Address book is already full");
            }
        }

    }
}
