
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Defines an interface for the determination of a stop word.
	/// </summary>
	public interface IStopWordProvider
	{
		/// <summary>
		/// Checks to see if the specified word is a stop word.
		/// </summary>
		/// <param name="word">The word to check.</param>
		/// <returns>Returns true if the word is a stop word, false otherwise.</returns>
		bool IsStopWord(string word);
	}
}
