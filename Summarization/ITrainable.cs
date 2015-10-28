
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Defines an interface for making a classifier trainable.
	/// </summary>
	public interface ITrainable
	{
		void TeachMatch(string input);
		void TeachMatch(string category, string input);
		void TeachNonMatch(string input);
		void TeachNonMatch(string category, string input);
	}
}
