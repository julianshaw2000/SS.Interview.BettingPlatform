namespace SS.Interview.BettingPlatform.MarketGeneration.Models
{
    /// <summary>
    /// Represents a market that consumers can bet on
    /// </summary>
    public class Market
    {
        /// <summary>
        /// The market identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The selections available within this market
        /// </summary>
        public Selection[] Selections { get; set; }
    }
}
