namespace Homework2
{
    class Standings
    {
        private string team;
        private int wins;
        private int losses;
        private int ties;
        private double winLossPercentage;
        private int pointsFor;
        private int pointsAgainst;
        private int pointsDiff;
        private double margingOfVictory;
        private bool wonDivision;
        private bool wildcard;

        public Standings(string team , int wins, int losses, int ties, double winLossPercentage, int pointsFor, int pointsAgainst, int pointsDiff, double margingOfVictory, bool wonDivision, bool wildcard)
        {
            Team = team;
            Wins = wins;
            Losses = losses;
            Ties = ties;
            WinLossPercentage = winLossPercentage;
            PointsFor = pointsFor;
            PointsAgainst = pointsAgainst;
            PointsDiff = pointsDiff;
            MarginOfVictory = margingOfVictory;
            WonDivision = wonDivision;
            WildCard = wildcard;
        }

        public override string ToString()
        {
            return $"{team}, {wins}, {losses}, {ties}, {winLossPercentage}, {pointsFor}, {pointsAgainst}, {pointsDiff}, {margingOfVictory}, {wonDivision}, {wildcard}";
        }

        public string ConsoleToString()
        {
            return
                $"{team}, Wins: {wins}, Losses: {losses}, Ties: {ties}, Win/Loss Percentage: {winLossPercentage}, " +
                $"Points For: {pointsFor}, Points Agianst {pointsAgainst}, Point Differencial {pointsDiff}, " +
                $"Margin of Victory: {margingOfVictory}, Won Division: {wonDivision}, Wildcard Appearence: {wildcard}";
        }

        private string Team
        {
            get => team;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Invalid Name");
                }
                team = value;
            }
        }
        //is using public property with private set valid
        public int Wins
        {
            get => wins;
            private set
            {
                if (value > 16 || value < 0)
                {
                    throw new Exception("Invalid number of wins");
                }
                wins = value;
            }
        }
        private int Losses
        {
            get => losses;
            set
            {
                if (value > 16 || value < 0)
                {
                    throw new Exception("Invalid number of losses");
                }
                losses = value;
            }
        }
        private int Ties
        {
            get => ties;
            set
            {
                if (value > 16 || value < 0)
                {
                    throw new Exception("Invalid number of ties");
                }
                ties = value;
            }
        }
        private double WinLossPercentage
        {
            get => winLossPercentage;
            set
            {
                if(value > 1 || value < 0)
                {
                    throw new Exception("Invalid Win/Loss Percentage");
                }
                winLossPercentage = value;
            }
        }
        private int PointsFor
        {
            get => pointsFor;
            set
            {
                if (value > 2000 || value < 0)
                {
                    throw new Exception("Invalid points for value");
                }
                pointsFor = value;
            }
        }
        private int PointsAgainst
        {
            get => pointsAgainst;
            set
            {
                if (value > 2000 || value < 0)
                {
                    throw new Exception("Invalid points against value");
                }
                pointsAgainst = value;
            }
        }
        private int PointsDiff
        {
            get => pointsDiff;
            set
            {
                if(value > 10000 || value < -1000)
                {
                    throw new Exception("Invalid point differencial value");
                }
                pointsDiff = value;
            }
        }
        private double MarginOfVictory
        {
            get => margingOfVictory;
            set
            {
                if (value > 100 || value < -100)
                {
                    throw new Exception("invalid margin of victory value");
                }
                margingOfVictory = value;
            }
        }
        private bool WonDivision { get; set; }

        private bool WildCard { get; set; }
    }
}
