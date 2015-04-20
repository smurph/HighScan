﻿using System;
using System.Windows.Forms;

namespace HighScan
{
    public partial class HighScan : Form
    {
        private ClipboardParser parser = new ClipboardParser();

        public HighScan()
        {
            InitializeComponent();
        }

        private async void clipboardMonitor1_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            //lblInfo.Text = string.Format("New data: \"{0}\"", Clipboard.GetText());
            ParseResults results = await parser.Parse(Clipboard.GetText());
            updateLabels(results);
        }

        private void updateLabels(ParseResults results)
        {
            if (results.Success)
            {
                lblBuy.Text = String.Format("{0} Buy", results.BuyValue);
                lblSell.Text = String.Format("{0} Sell", results.SellValue);
                lblVolumeStacks.Text = String.Format("{0} stacks / {1} m3", results.Stacks, results.Volume);
            }
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