using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScan
{
    class ParseResults
    {
        private string _buyValue;
        private string _sellValue;
        private string _url;
        private string _volume;
        private bool _success;

        public ParseResults(string buyValue, string sellValue, string url, string volume, bool success)
        {
            _buyValue = buyValue;
            _sellValue = sellValue;
            _url = url;
            _volume = volume;
            _success = success;
        }

        public ParseResults()
        {
            _buyValue = string.Empty;
            _sellValue = string.Empty;
            _url = string.Empty;
            _volume = string.Empty;
            _success = false;
        }

        public string BuyValue
        {
            get { return _buyValue; }
            set { _buyValue = value; }
        }

        public string SellValue
        {
            get { return _sellValue; }
            set { _sellValue = value; }
        }

        public string Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }


    }
}
