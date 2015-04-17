using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HighScan
{
    class ClipboardParser
    {

        private List<string> _buySellInfo = new List<string>();
        private string _volume = string.Empty;
        private string _url = string.Empty;
        private bool _success = false;

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

                    if (!string.IsNullOrWhiteSpace(_volume))
                        _success = true;

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

        public string Url
        {
            get
            {
                return _url;
            }
        }

        public string Volume
        {
            get
            {
                return _volume;
            }
        }

        public bool Success
        {
            get
            {
                return _success;
            }
        }

        #endregion

        private ParseResults makeResults()
        {
            return new ParseResults(BuyValue, SellValue, Url, Volume, Success);
        }

        private void reset(){
            _buySellInfo = new List<string>();
            _volume = string.Empty;
            _url = string.Empty;
            _success = false;
        }

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
            _volume = s;
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
            _url = result;
        }
    }
}
