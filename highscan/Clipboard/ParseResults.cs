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
            BuyValue = "0 ISK";
            SellValue = "0 ISK";
            Url = string.Empty;
            Volume = "0";
            Stacks = 0;
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