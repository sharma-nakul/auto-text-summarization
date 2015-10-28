
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Defines an interface for the classification of strings.
	/// </summary>
	public interface IClassifier
	{
		/// <summary>
		/// Sets the cutoff below which the input is not considered a match.
		/// </summary>
		double MatchCutoff { get; set; }

		/// <summary>
		/// Determines the probability of a string matching the criteria.
		/// </summary>
		/// <param name="input">The string to classify.</param>
		/// <returns>The likelyhood that this string is a match.  1 means 100% likely.</returns>
		double Classify(string input);

		/// <summary>
		/// Determines if a string matches a criteria.
		/// </summary>
		/// <param name="input">The string to classify.</param>
		/// <returns>Returns true if the input string has a probability >= the cutoff probability of matching.</returns>
		bool IsMatch(string input);

		/// <summary>
		/// Convenience method which takes a match probability and checks if it would be classified as a match.
		/// </summary>
		/// <param name="matchProbability">The match probability to check.</param>
		/// <returns>True if match, false otherwise.</returns>
		bool IsMatch(double matchProbability);
        
        
	}
}
