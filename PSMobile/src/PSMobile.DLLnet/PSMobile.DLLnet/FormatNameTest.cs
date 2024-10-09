using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMobile.DLLnet
{
    public class FormatNameTest
    {
        public FormatNameTest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }



        public string ReturnCompletedName()
        {
            return $"{FirstName} {LastName} - lib dev.net";
        }
    }
}
