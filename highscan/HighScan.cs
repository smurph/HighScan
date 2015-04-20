using System;
using System.Drawing;
using System.Windows.Forms;

namespace HighScan
{
    public partial class HighScan : Form
    {
        private ClipboardParser parser = new ClipboardParser();

        public HighScan()
        {
            InitializeComponent();
            resetLabels();
        }

        private async void clipboardMonitor1_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            ParseResults results = await parser.Parse(Clipboard.GetText());
            updateLabels(results);
        }

        private void updateLabels(ParseResults results)
        {
            if (results.Success)
            {
                updateBuyLabel(results);
                updateSellLabel(results);
                updateVolumeStacksLabel(results);
                updateCopyUrlButton(results);
            }
            else
                resetLabels();
        }

        private void updateCopyUrlButton(ParseResults results)
        {
            if (results.Success)
            {
                copyUrl.Enabled = true;
                copyUrl.BackColor = Color.OrangeRed;
            }
            else
            {
                copyUrl.Enabled = false;
                copyUrl.BackColor = Color.LightGray;
            }
        }

        private void updateVolumeStacksLabel(ParseResults results)
        {
            lblVolumeStacks.Text = String.Format("{0} stacks / {1} m3", results.Stacks, results.Volume);
        }

        private void updateBuyLabel(ParseResults results)
        {
            lblBuy.Text = String.Format("{0} Buy", results.BuyValue);
        }

        private void updateSellLabel(ParseResults results)
        {
            lblSell.Text = String.Format("{0} Sell", results.SellValue);
        }

        private void resetLabels()
        {
            ParseResults results = new ParseResults("0 ISK", "0 ISK", string.Empty, "0", 0, false);
            updateBuyLabel(results);
            updateSellLabel(results);
            updateVolumeStacksLabel(results);
            updateCopyUrlButton(results);
        }

        private void copyUrl_Click(object sender, EventArgs e)
        {
            if (parser.Success)
            {
                Clipboard.SetText(parser.Url);
            }
        }
    }
}