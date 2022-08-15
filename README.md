# SS.Interview.BettingPlatform

New Classes
===========
NAMESPACE  SS.Interview.BettingPlatform
 - MarketManagerJS: Class that uses dependency injection with the MarketGenerators
 - MarketGeneratorManager: Definition for all Market Generators
 - MarketManagerSelector: Class to select Game generator and run a request
 - ProbabilityAssigner:  This assigns a probability to the Market collection from the Generators
 - ProbabilityModifier: This performs the probability calculation on a Market Collection,  I seperated the probability calculations for unit testing
 - SportType: This is an Enum for Sport types
 - IGameMarketGenerator: This an interface for the External Market Generators
 
 
NAMESPACE  SS.Interview.BettingPlatform.Xunit
 - Xunit unit test programs
 
NAMESPACE  SS.Interview.BettingPlatform.Runner
 - Console program for testing 
