namespace HighScan
{
    internal class ParseResults
    {
        public ParseResults(string buyValue, string sellValue, string url, string volume, int stacks, bool success)
        {
            BuyValue = buyValue;
            SellValue = sellValue;
            Url = url;
            Volume = volume;
            Stacks = stacks;
            Success = success;
        }

        public ParseResults()
        {
            BuyValue = string.Empty;
            SellValue = string.Empty;
            Url = string.Empty;
            Volume = string.Empty;
            Stacks = -1;
            Success = false;
        }

        public string BuyValue { get; set; }

        public string SellValue { get; set; }

        public string Volume { get; set; }

        public string Url { get; set; }

        public int Stacks { get; set; }

        public bool Success { get; set; }
    }
}