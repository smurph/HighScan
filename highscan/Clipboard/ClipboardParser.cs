using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HighScan
{
    internal class ClipboardParser
    {
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

                    List<string> buySell = parseBuySell(responseString);

                    string volume = parseVolume(responseString);

                    string url = parseUrl(responseString);

                    int stacks = parseStacks(clip);

                    bool success = false; 
                    if (!string.IsNullOrWhiteSpace(volume))
                        success = true;

                    LastParseResult = new ParseResults(buySell[0], buySell[1], url, volume, stacks, success);

                    return LastParseResult;
                }
            }
            return new ParseResults();
        }

        #region Public Properties

        public ParseResults LastParseResult { get; private set; }

        #endregion Public Properties

        private void reset()
        {
            LastParseResult = new ParseResults();
        }

        #region Parsers
        private List<string> parseBuySell(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(\d+(?:\.\d+ )?.* ISK)");
            List<string> result = new List<string>();
            if (!m.Success)
            {
                result.Add("0 ISK");
                result.Add("0 ISK");
            }
            while (m.Success)
            {
                result.Add(m.Value);
                m = m.NextMatch();
            }
            return result;
        }

        private string parseVolume(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(>.*m<sup>3)");
            string s = string.Empty;
            if (m.Success)
            {
                s = m.Value.Substring(1, m.Value.Length - 8);
            }
            return s;
        }

        private string parseUrl(string response)
        {
            // Regex pattern courtesy of Noah Johansen
            Match m = Regex.Match(response, @"(http://www\.evepraisal\.com/e/\d+)");
            string result = string.Empty;
            if (m.Success)
            {
                result = m.Value;
            }
            return result;
        }

        private int parseStacks(string input)
        {
            return input.Split('\n').Length;
        }

        #endregion
    }
}