using System;
using System.Collections.Generic;
using System.IO;

namespace LotteryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var addingEntrants = true;

            var entrants = new List<Entrant>();

            var random = new System.Random();

            while (addingEntrants)
            {
                AddEntrant(random, entrants);

                askAdd:
                Console.Write("Add another? ");
                var c = Console.ReadKey();
                Console.WriteLine();

                if (c.KeyChar == 'y' || c.KeyChar == 'Y')
                {
                    continue;
                }
                else if(c.KeyChar == 'n' || c.KeyChar == 'N') 
                {
                    addingEntrants = false;
                }
                else
                {
                    Console.WriteLine("Please enter either y or n");
                    // I know, I know
                    goto askAdd;
                }

                if (entrants.Count < 1)
                {
                    Console.WriteLine("Not enough entrants.  Exiting.");
                }
                else
                {
                    Console.WriteLine("Now that entrants have all been added, we can pick a winner.");
                    var winner = entrants[random.Next(0, entrants.Count - 1)];
                    Console.WriteLine("Winner is " + winner.FullName + " with entry number " + winner.EntryNumber);
                }

                Console.ReadKey();
            }
        }

        private static void AddEntrant(Random random, List<Entrant> entrants)
        {
            var toAdd = new Entrant();
            Console.Write("First Name: ");
            toAdd.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            toAdd.LastName = Console.ReadLine();
            Console.Write("Age: ");
            toAdd.Age = int.Parse(Console.ReadLine());
            toAdd.EntryNumber = random.Next();

            var results = EntrantValidator.Validate(toAdd);
            if (results.Count > 0)
            {
                Console.WriteLine("Entrant was invalid:");
                foreach (var result in results)
                {
                    Console.WriteLine(" - " + result);
                }
            }
            else
            {
                entrants.Add(toAdd);
            }
        }
    }
}
