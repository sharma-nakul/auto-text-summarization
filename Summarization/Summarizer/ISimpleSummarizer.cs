using System;
namespace Summarization.Summarizer
{
    interface ISimpleSummarizer
    {
        string Summarize(string input, int numberOfSentences);
    }
}
