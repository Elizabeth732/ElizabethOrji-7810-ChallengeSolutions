//Elizabeth Ifunanyachi Orji BU/22C/IT/7810
using System;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter a date (mm/dd/yyyy) or type 'exit' to quit:");
        while (true)
        {
            Console.Write("Enter a date: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            try
            {
                string result = ReverseDateFormat(input);
                Console.WriteLine($"Date Converted to: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
        }
    }

    static string ReverseDateFormat(string Input)
    {
        if (string.IsNullOrWhiteSpace(Input))
        {
            throw new ArgumentException("Enter a date as it cannot be empty/null.");
        }

        // Define the regex pattern
        string pattern = @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$";
        TimeSpan timeout = TimeSpan.FromMilliseconds(500); // Set a timeout of 500 milliseconds

        try
        {
            // Match the input date with the regex pattern
            Match match = Regex.Match(dateInput, pattern, RegexOptions.None, timeout);

            if (match.Success)
            {
                // Extract the components
                int month = int.Parse(match.Groups["mon"].Value);
                int day = int.Parse(match.Groups["day"].Value);
                int year = int.Parse(match.Groups["year"].Value);

                // Normalize year to 4 digits
                if (year<100)
                {
                    year += (year >= 0 && year <= 29) ? 2000 : 1900;
                }


                return $"{year:D4}-{month:D2}-{day:D2}";
        }
        else
        {
            throw new FormatException("Invalid date format. Please use the format mm/dd/yyyy or m/d/yy.");
        }
    } }       
    
    
}