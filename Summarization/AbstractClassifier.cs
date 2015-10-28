
using System;

namespace TextAnalysis
{
	public abstract class AbstractClassifier : IClassifier
	{
		protected double cutoff = IClassifierConstants.DEFAULT_CUTOFF;

		/// <summary>
		/// Gets or sets the value which determines the minimum probability that should be classified as a match.
		/// </summary>
		/// <remarks>
		/// Throws an ArgumentOutOfRangeException if the cutoff is not equal to or greater than 0 or less than or equal to 1.
		/// </remarks>
		public double MatchCutoff 
		{
			get
			{
				return cutoff; 
			}
			set 
			{ 
				if (cutoff > 1 || cutoff < 0)
					throw new ArgumentOutOfRangeException("Cutoff must be equal to or greater than 0 and less than or equal to 1.");
				cutoff = value;
			}
		}

		public abstract double Classify(string input);

		public bool IsMatch(string input)
		{
			try
			{
				double matchProbability = Classify(input);
				return IsMatch(matchProbability);
			}
			catch (Exception ex)
			{
				throw new ClassifierException("AbstractClassifier.IsMatch(string input)", ex);
			}
		}

		public bool IsMatch(double matchProbability)
		{
			return (matchProbability >= cutoff);
		}
	}
}