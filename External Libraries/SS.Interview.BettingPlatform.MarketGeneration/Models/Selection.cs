namespace SS.Interview.BettingPlatform.MarketGeneration.Models
{
    /// <summary>
    /// Represents a selection (betting option) within a market
    /// </summary>
    public class Selection
    {
        /// <summary>
        /// The selection identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The probability of the selection occuring
        /// </summary>
        public double Probability { get; set; }
    }
}
