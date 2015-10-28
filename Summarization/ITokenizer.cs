
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Defines an interface for the splitting up of strings into tokens.
	/// </summary>
	public interface ITokenizer
	{
		/// <summary>
		/// Splits up the input string into tokens which each have individual probabilities.
		/// </summary>
		/// <param name="input">The string to tokenize.</param>
		/// <returns>Returns an array of tokens.  If there are no tokens, returns an empty array, not null.</returns>
		string[] Tokenize(string input);
	}
}
