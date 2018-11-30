using System;
using System.Collections.Generic;
using System.Text;

namespace LotteryExample
{
    public class Entrant
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public int Age { get; set; }

        public int EntryNumber { get; set; }
    }
}
