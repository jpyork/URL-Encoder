using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static string urlFormatString = " https://companyserver.com/content/{0}/files/{1}/{1}/report.pdf ";
        static Dictionary<string, string> urlCorrections = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            /* introduce user to the program */
            urlCorrections.Add(" ", "%20");
            urlCorrections.Add("<", "%3C");
            urlCorrections.Add(">", "%3E");
            urlCorrections.Add("#", "%23");
            urlCorrections.Add("%", "%25");
            urlCorrections.Add("\"", " %22");
            urlCorrections.Add(";", "%3B");
            urlCorrections.Add("/", "%2F");
            urlCorrections.Add("?", "%3F");
            urlCorrections.Add(":", "%3A");
            urlCorrections.Add("@", "%40");
            urlCorrections.Add("&", "%26");
            urlCorrections.Add("=", "%3D");
            urlCorrections.Add("+", "%2B");
            urlCorrections.Add("$", "%24");
            urlCorrections.Add("{", "%7B");
            urlCorrections.Add("}", "%7D");
            urlCorrections.Add("|", "%7C");
            urlCorrections.Add("^", "%5E");
            urlCorrections.Add("[", "%5B");
            urlCorrections.Add("]", "%5D");
            urlCorrections.Add("'", "%27");

            Console.WriteLine(" welcome to URL Encoder ");
            
            do
            {
                Console.Write("\nProject name: ");
                string projectName = GetUserInput();
                Console.WriteLine("Active name: ");
                string activeName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activeName));

                /* ask user for a retry */

                Console.WriteLine("would you like to try again? (y/n): ");

            } while (Console.ReadLine().ToLower().Equals(" y "));
        }

        /* create & return string */

        static string CreateURL(string projectName, string activityName)
        {
            return String.Format(urlFormatString, Encode(projectName), Encode(activityName));
        }

        /* recieve and check users input */

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.WriteLine(" You entered invalid characters, please try again: ");

            } while (true);

        }
        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
            {
                if ((character >= 0x00 && character <= 0x1F) || character == 0x7F)
                {
                    return false;
                }
            }
            return true;
        }
        static string Encode(string value)
        {
            string encodedValue = "";
            foreach (char character in value.ToCharArray())
            {
                string characterString = character.ToString();
                encodedValue += urlCorrections.GetValueOrDefault(characterString, characterString);
            }
            return encodedValue;
        }
    }
}         
