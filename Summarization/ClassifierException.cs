
using System;

namespace TextAnalysis
{
	/// <summary>
	/// A classifier exception.
	/// </summary>
	public class ClassifierException : Exception
	{
		public ClassifierException() {}

		public ClassifierException(string message) : base(message) {}

		public ClassifierException(string message, Exception ex) : base(message, ex) {}
	}
}