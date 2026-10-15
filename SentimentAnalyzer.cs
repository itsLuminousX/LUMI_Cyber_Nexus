namespace LUMI_Cyber_Nexus
{
    internal class SentimentAnalyzer
    {
        public string Analyze(string input)
        {
            input = input.ToLower();

            if (input.Contains("happy"))
                return "positive";

            if (input.Contains("excited"))
                return "positive";

            if (input.Contains("sad"))
                return "negative";

            if (input.Contains("angry"))
                return "negative";

            return "neutral";
        }
    }
}