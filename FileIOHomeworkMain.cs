namespace Homework2
{
    class FileIOHomework
    {
        private static void Main()
        {
            const string path = "NFL-2018-Standings.csv";
            int LineCount = GetLineCount(path);

            Standings[] standings = new Standings[LineCount - 1];

            try
            {
                using StreamReader reader = new StreamReader(path);

                reader.ReadLine();

                for (int i = 0; i < LineCount - 1; i++)
                {
                    string Line = reader.ReadLine();
                    string[] cols = Line.Split(",");

                    string team = cols[0];
                    int wins = int.Parse(cols[1]);
                    int losses = int.Parse(cols[2]);
                    int ties = int.Parse(cols[3]);
                    double winLossPercentage = double.Parse(cols[4]);
                    int pointsFor = int.Parse(cols[5]);
                    int pointsAgainst = int.Parse(cols[6]);
                    int pointsDiff = int.Parse(cols[7]);
                    double marginOfVictoy = double.Parse(cols[8]);
                    bool wonDivision = bool.Parse(cols[9]);
                    bool wildCard = bool.Parse(cols[10]);

                    standings[i] = new Standings(team, wins, losses, ties, winLossPercentage, pointsFor, pointsAgainst, pointsDiff, marginOfVictoy, wonDivision, wildCard);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading from file: {e.Message}");
            }

            SortData(standings);

            Console.WriteLine("Reading from CVS file...");
            Console.WriteLine("Done!");
            Console.WriteLine();
            Console.WriteLine("Sorting data...");
            Console.WriteLine("Done!");
            Console.WriteLine();

            WriteToConsole(standings);

            Console.WriteLine();
            Console.WriteLine("Writing data to CSV file...");
            Console.WriteLine("Done!");

            WriteToCSVFile(standings, LineCount);
        }
        private static int GetLineCount(string path)
        {
            using StreamReader reader = new StreamReader(path);

            int lines = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                lines++;
            }
            return lines;
        }
        private static void SortData(Standings[] standings)
        {
            Standings temp;

            for (int i = 1; i < standings.Length; i++)
            {
                int j = i;
                temp = standings[j];

                while (j > 0 && temp.Wins > standings[j - 1].Wins)
                {
                    standings[j] = standings[j - 1];
                    j--;
                }
                standings[j] = temp;
            }
        }
        private static void WriteToCSVFile(Standings[] standings, int linecount)
        {
            string FilePath = @"2018-NFL-Standings-Sorted.csv";
            using StreamWriter Writer = new StreamWriter(FilePath);
            try
            {
                Writer.WriteLine("Team, Wins, Losses, Ties, Win/Loss Percentage, Points For, Points Against, Points Differencial, Margin of Victory, Won Division, Wildcard");
                for (int i = 0; i < linecount - 1; i++)
                {
                    Writer.WriteLine(standings[i].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void WriteToConsole(Standings[] standings)
        {
            for (int i = 0; i < standings.Length; i++)
            {
                Console.WriteLine(standings[i].ConsoleToString());
            }
        }
    }
}