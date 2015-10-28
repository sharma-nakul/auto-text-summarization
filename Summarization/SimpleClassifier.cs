
using System;

namespace TextAnalysis
{
	/// <summary>
	/// Basic implementation of the IClassifier interface.
	/// </summary>
	public class SimpleClassifier : AbstractClassifier, IClassifier
	{
		string _searchWord;

		/// <summary>
		/// The string to look for when matching.
		/// </summary>
		public string SearchWord { get { return _searchWord; } set { _searchWord = value; } }

		public override double Classify(string input)
		{
			if ((input != null) && (input.IndexOf(SearchWord) > 0))
				return 1;
			else
				return 0;
		}
	}
}
