namespace HighScan
{
    partial class HighScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSell = new System.Windows.Forms.Label();
            this.lblBuy = new System.Windows.Forms.Label();
            this.copyUrl = new System.Windows.Forms.Button();
            this.clipboardMonitor1 = new HighScan.ClipboardMonitor();
            this.SuspendLayout();
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSell.Location = new System.Drawing.Point(12, 9);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(167, 39);
            this.lblSell.TabIndex = 3;
            this.lblSell.Text = "0 ISK Sell";
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuy.Location = new System.Drawing.Point(12, 48);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(169, 39);
            this.lblBuy.TabIndex = 4;
            this.lblBuy.Text = "0 ISK Buy";
            // 
            // copyUrl
            // 
            this.copyUrl.BackColor = System.Drawing.Color.OrangeRed;
            this.copyUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyUrl.Location = new System.Drawing.Point(19, 90);
            this.copyUrl.Name = "copyUrl";
            this.copyUrl.Size = new System.Drawing.Size(123, 23);
            this.copyUrl.TabIndex = 5;
            this.copyUrl.Text = "Copy evepraisal URL";
            this.copyUrl.UseVisualStyleBackColor = false;
            this.copyUrl.Click += new System.EventHandler(this.copyUrl_Click);
            // 
            // clipboardMonitor1
            // 
            this.clipboardMonitor1.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor1.Location = new System.Drawing.Point(274, 110);
            this.clipboardMonitor1.Name = "clipboardMonitor1";
            this.clipboardMonitor1.Size = new System.Drawing.Size(75, 23);
            this.clipboardMonitor1.TabIndex = 1;
            this.clipboardMonitor1.Text = "clipboardMonitor1";
            this.clipboardMonitor1.Visible = false;
            this.clipboardMonitor1.ClipboardChanged += new System.EventHandler<HighScan.ClipboardChangedEventArgs>(this.clipboardMonitor1_ClipboardChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 136);
            this.Controls.Add(this.copyUrl);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.lblSell);
            this.Controls.Add(this.clipboardMonitor1);
            this.Name = "Form1";
            this.Text = "High Scan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClipboardMonitor clipboardMonitor1;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.Button copyUrl;
    }
}

