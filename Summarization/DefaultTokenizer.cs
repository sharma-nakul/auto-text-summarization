
using System;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
	public class DefaultTokenizer : ITokenizer
	{
		/// <summary>
		/// Use a "\W" (non-word character) regex to split the string passed in to classify
		/// </summary>
		public static int BREAK_ON_WORD_BREAKS = 1;

		/// <summary>
		/// Use a "\s" (whitespace) regex to split the string pass in to classify
		/// </summary>
		public static int BREAK_ON_WHITESPACE = 2;

		int _tokenizerConfig = -1;
		string _customTokenizerRegExp = null;

		#region Properties
		public int TokenizerConfig 
		{ 
			get { return _tokenizerConfig; } 
			set 
			{ 
				if (value != BREAK_ON_WORD_BREAKS && value != BREAK_ON_WHITESPACE)
					throw new ArgumentException("TokenizerConfig must be either be BREAK_ON_WORD_BREAKS or BREAK_ON_WHITESPACE");
				_tokenizerConfig = value; 			
			} 
		}

		public string CustomTokenizerRegExp 
		{ 
			get { return _customTokenizerRegExp; } 
			set 
			{ 
				if (value == null)
					throw new ArgumentNullException("Regular expression string must not be null.");
				_customTokenizerRegExp = value; 
			} 
		}
		#endregion

		#region Constructors
		public DefaultTokenizer() : this(BREAK_ON_WORD_BREAKS) {}

		public DefaultTokenizer(int tokenizerConfig)
		{
			TokenizerConfig = tokenizerConfig;
		}

		public DefaultTokenizer(string regularExpression)
		{
			_customTokenizerRegExp = regularExpression;
		}
		#endregion

		public virtual string[] Tokenize(string input)
		{
			string regexp = string.Empty;
			if (_customTokenizerRegExp != null)
				regexp = CustomTokenizerRegExp;
			else if (_tokenizerConfig == BREAK_ON_WORD_BREAKS)
				regexp = @"\W";
			else if (_tokenizerConfig == BREAK_ON_WHITESPACE)
				regexp = @"\s";
			else
				throw new Exception("Illegal tokenizer configuration. CustomTokenizerRegExp = null and TokenizerConfig = " + _tokenizerConfig);

            if (input != null)
            {
                string[] words = Regex.Split(input, regexp, RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
                return words;
            }
            else
                return new string[0];			
		}
	}
}