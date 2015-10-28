
using System;

namespace TextAnalysis
{
	public sealed class IClassifierConstants
	{
		/// <summary>
		/// Default value to use if the implementation cannot work out how well a string matches.
		/// </summary>
		public static double NEUTRAL_PROBABILITY = .5d;

		/// <summary>
		/// The minimum likelyhood that a string matches.
		/// </summary>
		public static double LOWER_BOUND = .01d;

		/// <summary>
		/// The maximum likelyhood that a string matches.
		/// </summary>
		public static double UPPER_BOUND = .99d;

		/// <summary>
		/// Default cutoff value used by default implementation of IsMatch.
		/// Any match probability greater than or equal to this value
		/// will be classified as a match.
		/// </summary>
		public static double DEFAULT_CUTOFF = .9d;
	}
}