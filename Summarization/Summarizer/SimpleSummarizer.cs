
using System;
using System.Collections;
using System.Text;
using Summarization.Summarizer;
using System.Collections.Generic;

namespace TextAnalysis.Summarizer
{
	public class SimpleSummarizer : ISummarizer, Summarization.Summarizer.ISimpleSummarizer
	{
		private int FindMaxValue(ArrayList input)
		{
			input.Sort();
			return (int)input[0];
		}

		private string[] FindWordsWithFrequency(Hashtable wordFrequencies, int frequency)
		{
			if (wordFrequencies == null || frequency == 0)
				return new string[0];
			else
			{
				ArrayList results = new ArrayList();
				foreach (string word in wordFrequencies.Keys)
				{
					if (frequency == (int)wordFrequencies[word])
						results.Add(word);
				}
				return (string[])results.ToArray(typeof(string));
			}
		}

		protected ArrayList GetMostFrequentWords(int count, Hashtable wordFrequencies)
		{
			ArrayList result = new ArrayList();
			int freq = 0;
			foreach (DictionaryEntry entry in wordFrequencies)
				if ((int)entry.Value > freq)
					freq = (int)entry.Value;
			while (result.Count < count && freq > 0)
			{
				string[] words = FindWordsWithFrequency(wordFrequencies, freq);
                foreach (string word in words)
					result.Add(word);
				freq--;
			}
			return result;
		}

		public string Summarize(string input, int numberOfSentences)
		{
			// get the frequency of each word in the input
			Hashtable wordFrequencies = Utilities.GetWordFrequency(input);

			// now create a set of the X most frequent words
			ArrayList mostFrequentWords = GetMostFrequentWords(100, wordFrequencies);

			// break the input up into sentences
			string[] workingSentences = Utilities.GetSentences(input.ToLower());
			string[] actualSentences = Utilities.GetSentences(input);

			// iterate over the most frequent words, and add the first sentence
			// that includes each word to the result.
			ArrayList outputSentences = new ArrayList();

            ArrayList similer = new ArrayList();
            ArrayList wigiht = new ArrayList();
            for (int i = 0; i < workingSentences.Length; i++)
            {
                SumWeight s = new SumWeight();
                s.weight = 0;
                s.index = i;
                wigiht.Add(s);
            }
            foreach (string word in mostFrequentWords)
			{
				for (int i = 0; i < workingSentences.Length; i++)
				{
					if (workingSentences[i].IndexOf(word) >= 0)
                    {
                        SumWeight s = (SumWeight)wigiht[i];

                        s.weight += Convert.ToInt32(wordFrequencies[word].ToString());
                    }
				 
				}
                //if (outputSentences.Count >= numberOfSentences)
                //    break;
			}

            ArrayList sortweight = wigiht;
            SumWeight.op = 0;
            sortweight.Sort();
            for (int i = sortweight.Count-1; i >= 0; i--)
            {
                
                
                if (i >= numberOfSentences)
                {
                    sortweight.RemoveAt(i);
                }
            }
            SumWeight.op = 1;
            sortweight.Sort();
            for (int i = 0; i < sortweight.Count; i++)
            {
                SumWeight s = (SumWeight)sortweight[i];
                
                outputSentences.Add(actualSentences[s.index]);
            }

			ArrayList reorderedOutputSentences = ReorderSentences(outputSentences, input);

			StringBuilder result = new StringBuilder();
			foreach (string sentence in reorderedOutputSentences)
			{
				if (result.Length > 0)
					result.Append(" ");
				result.Append(sentence);
				result.Append("."); // this isn't correct - it should be whatever symbol the sentence finished with
			}

			return result.ToString();
		}

		private ArrayList ReorderSentences(ArrayList outputSentences, string input)
		{
			ArrayList result = new ArrayList(outputSentences);
			result.Sort(new SimpleSummarizerComparer(input));
			return result;
		}
	}

	public class SimpleSummarizerComparer : IComparer
	{
		string _input = string.Empty;

		public SimpleSummarizerComparer(string input)
		{
			_input = input;
		}

		#region IComparer Members
		public int Compare(object x, object y)
		{
			string sentence1 = (string)x;
			string sentence2 = (string)y;

			int indexOfSentence1 = _input.IndexOf(sentence1.Trim());
			int indexOfSentence2 = _input.IndexOf(sentence2.Trim());
			int result = indexOfSentence1 - indexOfSentence2;

			return result;
		}
		#endregion

	}
}