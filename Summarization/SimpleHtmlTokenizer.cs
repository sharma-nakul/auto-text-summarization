
using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
	/// <summary>
	/// Simple HTML tokenizer.  Its goal is to tokenize words that would be displayed in a normal
	/// web browser.
	/// </summary>
	/// <remarks>
	/// It does not handle meta tags, alt or text attributes, but it does remove CSS style
	/// definitions and javascript code.
	/// 
	/// It handles entity reference by replacing them with a space. This can be overridden.
	/// </remarks>
	public class SimpleHtmlTokenizer : DefaultTokenizer
	{
		/// <summary>
		/// Constructor uses BREAK_ON_WORD_BREAKS tokenizer config by default.
		/// </summary>
		public SimpleHtmlTokenizer() : base() {}

		public SimpleHtmlTokenizer(int tokenizerConfig) : base(tokenizerConfig) {}

		public SimpleHtmlTokenizer(string regularExpression) : base(regularExpression) {}

		/// <summary>
		/// Replaces entity references with spaces.
		/// </summary>
		/// <param name="contentsWithUnresolvedEntityReferences">The contents with the entity references.</param>
		/// <returns>The contents with the entities replaced with spaces.</returns>
		public string ResolveEntities(string contentsWithUnresolvedEntityReferences)
		{
			if (contentsWithUnresolvedEntityReferences == null)
				throw new ArgumentException("Cannot pass null.", "contentsWithUnresolvedEntityReferences");
			return Regex.Replace(contentsWithUnresolvedEntityReferences, "&.{2,8};", " ");
		}

		public override string[] Tokenize(string input)
		{
			Stack stack = new Stack();
			Stack tagStack = new Stack();

			// iterate over the input string and parse find text that would be displayed
			char[] chars = input.ToCharArray();

            StringBuilder result = new StringBuilder();
			StringBuilder currentTagName = new StringBuilder();
			for (int i = 0; i < chars.Length; i++)
			{
				switch (chars[i])
				{
					case '<' : 
						stack.Push(true);
						currentTagName = new StringBuilder();
						break;
					case '>' :
						stack.Pop();
						if (currentTagName != null)
						{
							string currentTag = currentTagName.ToString();
							if (currentTag.StartsWith("/"))
								tagStack.Pop();
							else
								tagStack.Push(currentTag.ToLower());
						}
						break;
					default :
						if (stack.Count == 0)
						{
							string currentTag = (string)tagStack.Peek();
							// ignore everything inside <script></script> or <style></style>
							if (currentTag != null)
							{
								if (!(currentTag.StartsWith("script") || currentTag.StartsWith("style")))
									result.Append(chars[i]);
							}
							else
								result.Append(chars[i]);
						}
						else
							currentTagName.Append(chars[i]);
						break;
				}
			}
			return base.Tokenize(ResolveEntities(result.ToString()).Trim());
		}
	}
}