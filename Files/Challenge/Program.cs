//Elizabeth Ifunanyachi Orji BU/22C/IT/7810

bool exit = false;
        
        while (!exit)
        {
            DateTime todayDate = DateTime.Today;

        Console.WriteLine("Enter a date (format: dd/mm/yyyy):");
        string dateInputStr = Console.ReadLine().Trim();

        // Parsing the user input into a DateTime object
        if (DateTime.TryParseExact(dateInputStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dateInput))
        {
            // Comparing the parsed date with today's date
            if (dateInput.Date == todayDate)
            {
                Console.WriteLine($"{dateInput.ToString("dd/MM/yyyy")} is today.");
            }
            else
            {
                // Calculating the difference in days between dateInput and todayDate
                int daysDifference = (dateInput.Date - todayDate).Days;

                if (daysDifference < 0)
                {
                    Console.WriteLine($"The date {dateInput.ToString("dd/MM/yyyy")} is {-daysDifference} days before today.");
                }
                else if (daysDifference > 0)
                {
                    Console.WriteLine($"The date {dateInput.ToString("dd/MM/yyyy")} is {daysDifference} days after today.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter a date in the format dd/mm/yyyy.");
        }
    
        }

      