
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Defines an interface for a categorized classifier.
	/// </summary>
	public interface ICategorizedClassifier : IClassifier
	{
		/// <summary>
		/// Determines the probability that the specified string matches
		/// a criteria for a given category.
		/// </summary>
		/// <param name="category">The category to check against.</param>
		/// <param name="input">The string to classify.</param>
		/// <returns>The likelihood that this string is a match for this classifier.  1 means 100% likely.</returns>
		double Classify(string category, string input);

		/// <summary>
		/// Determines if a string matches a criteria for a given category.
		/// </summary>
		/// <param name="category">The category to check against.</param>
		/// <param name="input">The string to classify.</param>
		/// <returns>True if the input string has a probability >= the cutoff probability of matching.</returns>
		bool IsMatch(string category, string input);
	}
}
