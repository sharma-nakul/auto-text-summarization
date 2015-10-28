
using System;
using System.Collections;
using System.IO;

namespace TextAnalysis
{
	public class CustomizableStopWordProvider : IStopWordProvider
	{
		string _path;
		string[] _words;

		public static string DEFAULT_STOPWORD_PROVIDER_FILENAME = "DefaultStopWords.txt";

		/// <param name="filename">
		/// The name of the text file in the app's root that contains a list of stop words, one on each line
		/// </param>
		public CustomizableStopWordProvider(string filename)
		{
			_path = Directory.GetCurrentDirectory() + "\\" + filename;
			Init();
		}

		public CustomizableStopWordProvider() : this(DEFAULT_STOPWORD_PROVIDER_FILENAME) {}

		protected void Init()
		{
			ArrayList wordsList = new ArrayList();
			TextReader reader = File.OpenText(_path);

			string word;
			while ((word = reader.ReadLine()) != null)
				wordsList.Add(word.Trim());

			reader.Close();

			_words = (string[])wordsList.ToArray(typeof(string));

			Array.Sort(_words);
		}

		public bool IsStopWord(string word)
		{
			return (Array.BinarySearch(_words, word) >= 0);
		}
	}
}