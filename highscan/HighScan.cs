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
            updateLabels(ref results);
        }

        private void updateLabels(ref ParseResults results)
        {
            if (results.Success)
            {
                updateBuyLabel(ref results);
                updateSellLabel(ref results);
                updateVolumeStacksLabel(ref results);
                updateCopyUrlButton(ref results);
            }
            else
                resetLabels();
        }

        private void updateCopyUrlButton(ref ParseResults results)
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

        private void updateVolumeStacksLabel(ref ParseResults results)
        {
            lblVolumeStacks.Text = String.Format("{0} stacks / {1} m3", results.Stacks, results.Volume);
        }

        private void updateBuyLabel(ref ParseResults results)
        {
            lblBuy.Text = String.Format("{0} Buy", results.BuyValue);
        }

        private void updateSellLabel(ref ParseResults results)
        {
            lblSell.Text = String.Format("{0} Sell", results.SellValue);
        }

        private void resetLabels()
        {
            ParseResults results = new ParseResults();
            updateBuyLabel(ref results);
            updateSellLabel(ref results);
            updateVolumeStacksLabel(ref results);
            updateCopyUrlButton(ref results);
        }

        private void copyUrl_Click(object sender, EventArgs e)
        {
            if (parser.LastParseResult.Success)
            {
                Clipboard.SetText(parser.LastParseResult.Url);
            }
        }
    }
}