
using System;

namespace TextAnalysis.Summarizer
{
	/// <summary>
	/// An interface for doing text summarization.
	/// </summary>
	public interface ISummarizer
	{
		string Summarize(string input, int numberOfSentences);
	}
}