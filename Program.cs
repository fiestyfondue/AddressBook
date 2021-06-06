using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook(50);
            Console.WriteLine("Address Book Options: \n" +
                                 "Add-to add new Entry .\n" +
                                 "search-To search Entry. \n" +
                                 "clear- To clear screen. \n" +
                                 "options - Display Instructions\n");
            while(true)
            {
                Console.WriteLine("Options: ");
                string Instructions = Console.ReadLine();

                if(Instructions.ToLower()=="quit")
                {
                    Console.Clear();
                    Console.WriteLine("GoodBye!");
                    break;
                }
                else if(Instructions.ToLower()=="Add")
                {
                    Console.Clear();
                    addressBook.NewEntry();
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
        }
    }
}
