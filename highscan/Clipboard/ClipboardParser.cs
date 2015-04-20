using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HighScan
{
    internal class ClipboardParser
    {
        private List<string> _buySellInfo = new List<string>();

        public async Task<ParseResults> Parse(string clip)
        {
            reset();
            if (clip.Contains("\n"))
            {
                using (var client = new HttpClient())
                {
                    var vals = new Dictionary<string, string>
                    {
                        {"raw_paste", clip},
                        {"load_full", "1"},
                        {"market", "30000142"}
                    };
                    HttpResponseMessage response = await client.PostAsync("http://www.evepraisal.com/estimate", new FormUrlEncodedContent(vals));

                    var responseString = await response.Content.ReadAsStringAsync();

                    parseBuySell(responseString);

                    parseVolume(responseString);

                    parseUrl(responseString);

                    parseStacks(clip);

                    if (!string.IsNullOrWhiteSpace(Volume))
                        Success = true;

                    return makeResults();
                }
            }
            return new ParseResults();
        }

        #region Public Properties

        public string BuyValue
        {
            get
            {
                string s = string.Empty;
                try
                {
                    s = _buySellInfo[1];
                }
                catch { }
                return s;
            }
        }

        public string SellValue
        {
            get
            {
                string s = string.Empty;
                try
                {
                    s = _buySellInfo[0];
                }
                catch { }
                return s;
            }
        }

        public string Url { get; private set; }

        public string Volume { get; private set; }

        public bool Success { get; private set; }

        public int Stacks { get; private set; }

        #endregion Public Properties

        private ParseResults makeResults()
        {
            return new ParseResults(BuyValue, SellValue, Url, Volume, Stacks, Success);
        }

        private void reset()
        {
            _buySellInfo = new List<string>();
            Volume = string.Empty;
            Url = string.Empty;
            Success = false;
        }

        #region Parsers
        private void parseBuySell(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(\d+(?:\.\d+ )?.* ISK)");
            List<string> result = new List<string>();
            while (m.Success)
            {
                result.Add(m.Value);
                m = m.NextMatch();
            }
            _buySellInfo = result;
        }

        private void parseVolume(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(>.*m<sup>3)");
            string s = string.Empty;
            if (m.Success)
            {
                s = m.Value.Substring(1, m.Value.Length - 8);
            }
            Volume = s;
        }

        private void parseUrl(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(http://www\.evepraisal\.com/e/\d+)");
            string result = string.Empty;
            if (m.Success)
            {
                result = m.Value;
            }
            Url = result;
        }

        private void parseStacks(string input)
        {
            Stacks = input.Split('\n').Length;
        }

        #endregion
    }
}