using System;

namespace SS.Interview.BettingPlatform.MarketGeneration.Generators
{
    internal static class ProbabilityGenerator
    {
        private static readonly Random Random;

        static ProbabilityGenerator()
        {
            Random = new Random();
        }

        internal static double[] Generate(int count)
        {
            var result = new double[count];

            result[0] = Random.NextDouble();
            var runningTotal = result[0];

            for (var i = 1; i < count; i++)
            {
                var last = i == (count - 1);
                result[i] = (1 - runningTotal) * (last ? 1 : Random.NextDouble());
                runningTotal += result[i];
            }

            return result;
        }
    }
}