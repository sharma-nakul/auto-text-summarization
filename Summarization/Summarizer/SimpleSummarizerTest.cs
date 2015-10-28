
using System;
using TextAnalysis.Summarizer;

namespace TextAnalysis.Tests.Summarizer
{
	public class SimpleSummarizerTest
	{
		SimpleSummarizer summarizer = null;

		public void Setup()
		{
			summarizer = new SimpleSummarizer();
		}

		public void TearDown()
		{
			summarizer = null;
		}

        
        public string TestSummarize(string input,int line)
		{
            Setup();
			//string input = "TextAnalysis is a dotnet assembly for working with text.  TextAnalysis includes a summarizer.";
			//string expected
            //Result = "TextAnalysis is a dotnet assembly for working with text.";
			string result = summarizer.Summarize(input, line);
			//Assert.AreEqual(expectedResult, result);

            //input = "TextAnalysis is a dotnet assembly for working with text. TextAnalysis includes a summarizer. A Summarizer allows the summary of text. A Summarizer is really cool. I don't think there are any other dotnet summarizers.";
            //expectedResult = "TextAnalysis is a dotnet assembly for working with text. TextAnalysis includes a summarizer.";
            //result = summarizer.Summarize(input, 2);
            //Assert.AreEqual(expectedResult, result);
            TearDown();

            return result;
		}
	}
}