using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LotteryExample
{
    public static class EntrantValidator
    {
        // Takes an Entrant and returns a list of reasons that they're not valid.
        // If you get back an empty list, you have a valid entrant!
        public static List<string> Validate(Entrant entrant)
        {
            var failedValidations = new List<String>();

            if (entrant.FirstName.Contains(" "))
            {
                failedValidations.Add("First name cannot contain a space");
            }

            if (entrant.LastName.Contains(" "))
            {
                failedValidations.Add("Last name cannot contain a space");
            }

            var matches = Regex.Matches(entrant.FullName, "[a-zA-Z'\\-]+");
            if (matches.Count != 2)
            {
                failedValidations.Add("Name cannot contain non-alphanumeric symbols other than \"`\" or \"-\"");
            }

            if (entrant.Age <= 0)
            {
                failedValidations.Add("Entrant age cannot be 0 or below");
            }

            if (entrant.Age <= 18)
            {
                failedValidations.Add("Entrants must be 18 or older");
            }

            if (entrant.Age >= 130)
            {
                failedValidations.Add("There are no humans above 130 years of age, this is probably an invalid entrant");
            }

            if (entrant.EntryNumber <= 0)
            {
                failedValidations.Add("Entrant number cannot be 0 or below");
            }

            if (entrant.FirstName.Length < 1)
            {
                failedValidations.Add("First name must be at least 1 character");
            }

            if (entrant.LastName.Length < 1)
            {
                failedValidations.Add("Last name must be at least 1 character");
            }

            if (entrant.FirstName.Length >= 30)
            {
                failedValidations.Add("First name cannot be 30 characters or longer");
            }

            if (entrant.LastName.Length >= 50)
            {
                failedValidations.Add("Last name cannot be 50 characters or longer");
            }

            return failedValidations;
        }
    }
}
