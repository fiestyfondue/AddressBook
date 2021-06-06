using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string EmailAddress { get; set; }

        public string GetInfo()
        {
            string Message ="First Name: {0} \n Last Name: {1}\n Phone Number: {2}\nHome Address: {3}\n Email Address: {4}\n ";
            return string.Format(Message, FirstName, LastName, PhoneNumber, HomeAddress, EmailAddress);

        }



    }
}
