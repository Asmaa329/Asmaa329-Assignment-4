using BenchmarkDotNet.Running;
using System.Text;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace AcademyScheduleAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // Part 1 — Starter Data
            // ==========================================
            string[] sessionNames =
            {
                "C# Basics",
                "Arrays",
                "Functions",
                "Date and Time",
                "Exception Handling"
            };

            DateTime[] sessionDates =
            {
                new DateTime(2026, 9, 10, 18, 0, 0),
                new DateTime(2026, 9, 13, 18, 0, 0),
                new DateTime(2026, 9, 17, 18, 0, 0),
                new DateTime(2026, 9, 20, 18, 0, 0),
                new DateTime(2026, 9, 24, 18, 0, 0)
            };

            int[] sessionDurations =
            {
                180,
                240,
                180,
                240,
                180
            };

            // ==========================================
            // Part 2 — Display All Sessions
            // ==========================================
            Console.WriteLine("=== Part 2: Display All Sessions ===");
            DisplaySessions(sessionNames, sessionDates, sessionDurations);

            // ==========================================
            // Part 3 — Search for a Session
            // ==========================================
            Console.WriteLine("=== Part 3: Search for a Session ===");
            SearchSession(sessionNames, sessionDates, sessionDurations);

            // ==========================================
            // Part 4 — Array Methods Practice
            // ==========================================
            Console.WriteLine("\n=== Part 4: Array Methods Practice ===");

            // 4.1 Sort Session Names
            Console.WriteLine("\n--- 4.1 Sort Session Names ---");
            string[] sortedNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, sortedNames, sessionNames.Length);
            Array.Sort(sortedNames);
            Console.WriteLine("Sorted Session Names:");
            foreach (var name in sortedNames)
            {
                Console.WriteLine($"- {name}");
            }

            // 4.2 Reverse Session Names
            Console.WriteLine("\n--- 4.2 Reverse Session Names ---");
            string[] reversedNames = new string[sessionNames.Length];
            Array.Copy(sessionNames, reversedNames, sessionNames.Length);
            Array.Reverse(reversedNames);
            Console.WriteLine("Reversed Session Names:");
            foreach (var name in reversedNames)
            {
                Console.WriteLine($"- {name}");
            }

            // 4.3 Find Session Index
            Console.WriteLine("\n--- 4.3 Find Session Index ---");
            Console.Write("Enter session name: ");
            string searchIndexName = Console.ReadLine();
            int indexFound = Array.IndexOf(sessionNames, searchIndexName);
            Console.WriteLine($"Index: {indexFound}");

            // 4.4 Check if a Session Exists
            Console.WriteLine("\n--- 4.4 Check if a Session Exists ---");
            Console.Write("Enter session name: ");
            string checkExistName = Console.ReadLine();
            bool isExist = Array.Exists(sessionNames, name => name.Equals(checkExistName, StringComparison.OrdinalIgnoreCase));
            if (isExist)
            {
                Console.WriteLine("Session exists.");
            }
            else
            {
                Console.WriteLine("Session does not exist.");
            }

            // 4.5 Find a Session
            Console.WriteLine("\n--- 4.5 Find a Session ---");
            string foundSession = Array.Find(sessionNames, name => name.StartsWith("F", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Found Session (starts with 'F'): {foundSession}");

            // 4.6 Find a Session Index Using a Condition
            Console.WriteLine("\n--- 4.6 Find a Session Index Using Condition ---");
            int conditionIdx = Array.FindIndex(sessionNames, name => name.Contains("Date", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Index of session containing 'Date': {conditionIdx}");

            // 4.7 Copy an Array
            Console.WriteLine("\n--- 4.7 Copy an Array ---");
            string[] copiedArray = new string[sessionNames.Length];
            Array.Copy(sessionNames, copiedArray, sessionNames.Length);
            copiedArray[0] = "C# Advanced";

            Console.WriteLine("Original Array:");
            for (int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"[{i}] {sessionNames[i]}");
            }

            Console.WriteLine("\nCopied Array (After Changing element [0]):");
            for (int i = 0; i < copiedArray.Length; i++)
            {
                Console.WriteLine($"[{i}] {copiedArray[i]}");
            }

            // ==========================================
            // Part 5 — Duration Analysis
            // ==========================================
            Console.WriteLine("\n=== Part 5: Duration Analysis ===");
            Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
            Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");
            Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
            Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");

            Console.WriteLine("\n--- Sorted Durations ---");
            int[] sortedDurations = new int[sessionDurations.Length];
            Array.Copy(sessionDurations, sortedDurations, sessionDurations.Length);
            Array.Sort(sortedDurations);
            Console.WriteLine("Durations Sorted (Smallest to Largest):");
            foreach (var duration in sortedDurations)
            {
                Console.WriteLine($"- {duration} minutes");
            }

            // ==========================================
            // Part 6 — Functions & Reports Demo
            // ==========================================
            Console.WriteLine("\n=== Part 6: Function Examples & Reports ===");

            // DateTime Return Example
            DateTime endTime = GetSessionEndTime(sessionDates[0], sessionDurations[0]);
            Console.WriteLine($"First Session End Time: {endTime:hh:mm tt}");

            // ReadSessionDate Example
            DateTime parsedDate = ReadSessionDate("2026-09-10");
            Console.WriteLine($"Parsed Date: {parsedDate:dd MMMM yyyy}");

            // Reports Examples
            Console.WriteLine("\n--- Report Using String ---");
            Console.WriteLine(BuildReportUsingString(sessionNames, sessionDurations));

            Console.WriteLine("\n--- Report Using StringBuilder ---");
            Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDurations));

            // 7.1 ref
            int number = 10;
            Console.WriteLine($"Before ChangeByRef: {number}");
            ChangeByRef(ref number);
            Console.WriteLine($"After ChangeByRef: {number}");

            // 7.2 out
            Console.Write("\nEnter session name for 'out' demo (e.g. Arrays): ");
            string searchOutName = Console.ReadLine();
            if (TryGetSessionDetails(searchOutName, sessionNames, sessionDurations, out int outIndex, out int outDuration))
            {
                Console.WriteLine($"Index: {outIndex}, Duration: {outDuration} minutes");
            }
            else
            {
                Console.WriteLine("Session not found using out parameter.");
            }

            // 7.3 Reference Type Without ref
            Console.WriteLine("\nArray element [0] before ModifyArrayWithoutRef: " + sessionNames[0]);
            ModifyArrayWithoutRef(sessionNames);
            Console.WriteLine("Array element [0] after ModifyArrayWithoutRef: " + sessionNames[0]);
            // Restore original name
            sessionNames[0] = "C# Basics";


            Console.WriteLine("\n=== PART 8: params Keyword ===");
            Console.WriteLine("Total (120, 180): " + CalculateTotalDurationParams(120, 180));
            Console.WriteLine("Total (120, 180, 240): " + CalculateTotalDurationParams(120, 180, 240));
            Console.WriteLine("Total (60, 90, 120, 180, 240): " + CalculateTotalDurationParams(60, 90, 120, 180, 240));


            Console.WriteLine("\n=== PART 9: Session Date Details ===");
            DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations, 1); // Index 1: Arrays


            Console.WriteLine("\n=== PART 10: Date Difference ===");
            CalculateDateDifference(sessionDates[0], sessionDates[1], sessionNames[0], sessionNames[1]);


            Console.WriteLine("\n=== PART 11: Past and Upcoming Sessions ===");
            DisplayPastAndUpcoming(sessionNames, sessionDates);


            Console.WriteLine("\n=== PART 12: Find the Next Session ===");
            DisplayNextSession(sessionNames, sessionDates);


            Console.WriteLine("\n=== PART 13: Date Formatting ===");
            DisplayFormattedDates(sessionDates[1]);


            Console.WriteLine("\n=== PART 14: Read and Validate a Date ===");
            DateTime userValidDate = ReadAndValidateDate();
            Console.WriteLine($"Successfully Parsed Date: {userValidDate:yyyy-MM-dd HH:mm}");


            Console.WriteLine("\n=== PART 15: Exception Handling - Menu Input ===");
            int menuChoice = ReadValidMenuOption();
            Console.WriteLine($"Selected Option: {menuChoice}");


            Console.WriteLine("\n=== PART 16: Exception Handling - Invalid Array Index ===");
            AccessSessionByIndex(sessionNames);


            Console.WriteLine("\n=== PART 17 & 18: Throw Exception & finally ===");
            ValidateDurationDemo(-20);
            ValidateDurationDemo(180);


            Console.WriteLine("\n=== PART 19 & 20: Reports ===");
            Console.WriteLine("--- String Report ---");
            Console.WriteLine(BuildScheduleReportString(sessionNames, sessionDates, sessionDurations));

            Console.WriteLine("--- StringBuilder Report ---");
            Console.WriteLine(BuildScheduleReportStringBuilder(sessionNames, sessionDates, sessionDurations));




            BenchmarkRunner.Run<ScheduleReportBenchmark>();



        }

        // Returns: void | Accepts: arrays
        static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
        {
            for (int i = 0; i < names.Length; i++)
            {
                DisplaySessionDetails(i, names[i], dates[i], durations[i]);
            }
        }

        // Returns: void | Accepts: individual parameters
        static void DisplaySessionDetails(int index, string name, DateTime date, int duration)
        {
            Console.WriteLine($"{index + 1}. {name}");
            Console.WriteLine($"Date: {date:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {date:hh:mm tt}");
            Console.WriteLine($"Duration: {duration} minutes\n");
        }

        // Returns: void | Accepts: arrays
        static void SearchSession(string[] names, DateTime[] dates, int[] durations)
        {
            Console.Write("Enter Session Name: ");
            string searchName = Console.ReadLine();

            int index = Array.IndexOf(names, searchName);

            if (index != -1)
            {
                DisplaySessionDetails(index, names[index], dates[index], durations[index]);
            }
            else
            {
                Console.WriteLine("Session not found.\n");
            }
        }

        // Returns: int
        static int GetTotalDuration(int[] durations)
        {
            int total = 0;
            for (int i = 0; i< durations.Length;i++)
            {
                total += durations[i];
            }
            return total;
        }

        // Returns: double
        static double GetAverageDuration(int[] durations)
        {
            if (durations.Length == 0) return 0;
            return (double)GetTotalDuration(durations) / durations.Length;
        }

        // Returns: int
        static int GetShortestDuration(int[] durations)
        {
            int min = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (durations[i] < min)
                    min = durations[i];
            }
            return min;
        }

        // Returns: int
        static int GetLongestDuration(int[] durations)
        {
            int max = durations[0];
            for (int i = 1; i < durations.Length; i++)
            {
                if (durations[i] > max)
                    max = durations[i];
            }
            return max;
        }

        // Returns: DateTime
        static DateTime GetSessionEndTime(DateTime startTime, int durationMinutes)
        {
            return startTime.AddMinutes(durationMinutes);
        }

        // Returns: DateTime
        static DateTime ReadSessionDate(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        // Returns: string
        static string BuildReportUsingString(string[] names, int[] durations)
        {
            string report = "--- Report (String) ---\n";
            for (int i = 0; i < names.Length; i++)
            {
                report += $"Session: {names[i]} | Duration: {durations[i]} mins\n";
            }
            return report;
        }

        // Returns: string (Uses StringBuilder)
        static string BuildReportUsingStringBuilder(string[] names, int[] durations)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- Report (StringBuilder) ---");
            for (int i = 0; i < names.Length; i++)
            {
                sb.AppendLine($"Session: {names[i]} | Duration: {durations[i]} mins");
            }
            return sb.ToString();
        }
        // ==========================================
        // Part 7
        // ==========================================

        static void ChangeByRef(ref int val)
        {
            val *= 2;
        }

        static bool TryGetSessionDetails(string name, string[] names, int[] durations, out int index, out int duration)
        {
            index = Array.IndexOf(names, name);
            if (index != -1)
            {
                duration = durations[index];
                return true;
            }
            duration = 0;
            return false;
        }

        static void ModifyArrayWithoutRef(string[] names)
        {
            if (names.Length > 0)
            {
                names[0] = "Modified Inside Method";
            }
        }

        // ==========================================
        // Part 8 Implementation
        // ==========================================
        static int CalculateTotalDurationParams(params int[] durations)
        {
            int sum = 0;
            foreach (var d in durations) sum += d;
            return sum;
        }

        // ==========================================
        // Part 9 Implementation
        // ==========================================
        static void DisplaySessionDateDetails(string[] names, DateTime[] dates, int[] durations, int index)
        {
            if (index < 0 || index >= names.Length) return;

            DateTime dt = dates[index];
            DateTime endTime = dt.AddMinutes(durations[index]);

            Console.WriteLine($"Session: {names[index]}");
            Console.WriteLine($"Date: {dt:dd MMMM yyyy}");
            Console.WriteLine($"Day: {dt.DayOfWeek}");
            Console.WriteLine($"Year: {dt.Year}");
            Console.WriteLine($"Month: {dt.Month}");
            Console.WriteLine($"Day Number: {dt.Day}");
            Console.WriteLine($"Start Time: {dt:hh:mm tt}");
            Console.WriteLine($"Duration: {durations[index]} minutes");
            Console.WriteLine($"End Time: {endTime:hh:mm tt}");
        }

        // ==========================================
        // Part 10 Implementation
        // ==========================================
        static void CalculateDateDifference(DateTime date1, DateTime date2, string name1, string name2)
        {
            TimeSpan diff = date2 - date1;
            Console.WriteLine($"First Session: {name1}");
            Console.WriteLine($"Second Session: {name2}");
            Console.WriteLine("Difference:");
            Console.WriteLine($"{Math.Abs(diff.TotalDays)} days");
            Console.WriteLine($"{Math.Abs(diff.TotalHours)} hours");
        }

        // ==========================================
        // Part 11 Implementation
        // ==========================================
        static void DisplayPastAndUpcoming(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < names.Length; i++)
            {
                string status = dates[i] < now ? "Past" : "Upcoming";
                Console.WriteLine($"{names[i]} -> {status}");
            }
        }

        // ==========================================
        // Part 12 Implementation
        // ==========================================
        static void DisplayNextSession(string[] names, DateTime[] dates)
        {
            DateTime now = DateTime.Now;
            int nearestIndex = -1;
            TimeSpan minDiff = TimeSpan.MaxValue;

            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] > now)
                {
                    TimeSpan diff = dates[i] - now;
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        nearestIndex = i;
                    }
                }
            }

            if (nearestIndex != -1)
            {
                Console.WriteLine("Next Session:");
                Console.WriteLine(names[nearestIndex]);
                Console.WriteLine(dates[nearestIndex].ToString("dd MMMM yyyy"));
                Console.WriteLine(dates[nearestIndex].ToString("hh:mm tt"));
                Console.WriteLine("Time Remaining:");
                Console.WriteLine($"{minDiff.Days} days");
                Console.WriteLine($"{minDiff.Hours} hours");
            }
            else
            {
                Console.WriteLine("No upcoming sessions found.");
            }
        }

        // ==========================================
        // Part 13 Implementation
        // ==========================================
        static void DisplayFormattedDates(DateTime dt)
        {
            Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            Console.WriteLine(dt.ToString("dd/MM/yyyy"));
            Console.WriteLine(dt.ToString("dd MMMM yyyy"));
            Console.WriteLine(dt.ToString("dddd, dd MMMM yyyy"));
            Console.WriteLine(dt.ToString("hh:mm tt"));
        }

        // ==========================================
        // Part 14 Implementation
        // ==========================================
        static DateTime ReadAndValidateDate()
        {
            DateTime result;
            string input;
            while (true)
            {
                Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
                input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid format. Please use exact format: yyyy-MM-dd HH:mm");
            }
        }

        // ==========================================
        // Part 15 Implementation
        // ==========================================
        static int ReadValidMenuOption()
        {
            while (true)
            {
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();
                try
                {
                    return int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
            }
        }

        // ==========================================
        // Part 16 Implementation
        // ==========================================
        static void AccessSessionByIndex(string[] names)
        {
            Console.Write("Enter session index: ");
            string input = Console.ReadLine();
            try
            {
                int idx = int.Parse(input);
                Console.WriteLine($"Session: {names[idx]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The selected session index is out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numeric index.");
            }
        }

        // ==========================================
        // Part 17 & 18 Implementation
        // ==========================================
        static void ValidateSessionDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than zero.");
            }
            Console.WriteLine("Duration accepted.");
        }

        static void ValidateDurationDemo(int duration)
        {
            try
            {
                ValidateSessionDuration(duration);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Input operation finished.");
            }
        }

        // ==========================================
        // Part 19 Implementation
        // ==========================================
        static string BuildScheduleReportString(string[] names, DateTime[] dates, int[] durations)
        {
            string result = "";
            for (int i = 0; i < names.Length; i++)
            {
                result += $"{names[i]} - {dates[i]:dd/MM/yyyy hh:mm tt} - {durations[i]} minutes\n";
            }
            return result;
        }

        // ==========================================
        // Part 20 Implementation
        // ==========================================
        static string BuildScheduleReportStringBuilder(string[] names, DateTime[] dates, int[] durations)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                sb.AppendLine($"{names[i]} - {dates[i]:dd/MM/yyyy hh:mm tt} - {durations[i]} minutes");
            }
            return sb.ToString();
        }

       
    }
}

     