namespace ChewieBot
{
    partial class chewieBot
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
            this.components = new System.ComponentModel.Container();
            this.aLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chatText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aLabel.Location = new System.Drawing.Point(12, 9);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(43, 16);
            this.aLabel.TabIndex = 0;
            this.aLabel.Text = "Chat:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chatText
            // 
            this.chatText.AutoSize = true;
            this.chatText.Location = new System.Drawing.Point(12, 22);
            this.chatText.Name = "chatText";
            this.chatText.Size = new System.Drawing.Size(0, 13);
            this.chatText.TabIndex = 1;
            // 
            // chewieBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 357);
            this.Controls.Add(this.chatText);
            this.Controls.Add(this.aLabel);
            this.Name = "chewieBot";
            this.Text = "chewieBot";
            this.Load += new System.EventHandler(this.ChewieBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label chatText;
    }
}

