namespace Spider
{
    partial class Form1
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
            this.startButton = new System.Windows.Forms.Button();
            this.startUrlLabel = new System.Windows.Forms.Label();
            this.searchTextLabel = new System.Windows.Forms.Label();
            this.startUrlTextBox = new System.Windows.Forms.TextBox();
            this.searchTextTextBox = new System.Windows.Forms.TextBox();
            this.nThreadsLabel = new System.Windows.Forms.Label();
            this.nUrlsLabel = new System.Windows.Forms.Label();
            this.nThreadsTextBox = new System.Windows.Forms.TextBox();
            this.nUrlsTextBox = new System.Windows.Forms.TextBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.completedLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 431);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_click);
            // 
            // startUrlLabel
            // 
            this.startUrlLabel.Location = new System.Drawing.Point(163, 3);
            this.startUrlLabel.Name = "startUrlLabel";
            this.startUrlLabel.Size = new System.Drawing.Size(127, 20);
            this.startUrlLabel.TabIndex = 1;
            this.startUrlLabel.Text = "Start URL:";
            this.startUrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchTextLabel
            // 
            this.searchTextLabel.Location = new System.Drawing.Point(163, 27);
            this.searchTextLabel.Name = "searchTextLabel";
            this.searchTextLabel.Size = new System.Drawing.Size(127, 20);
            this.searchTextLabel.TabIndex = 2;
            this.searchTextLabel.Text = "Text to search for:";
            this.searchTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startUrlTextBox
            // 
            this.startUrlTextBox.Location = new System.Drawing.Point(296, 3);
            this.startUrlTextBox.Name = "startUrlTextBox";
            this.startUrlTextBox.Size = new System.Drawing.Size(420, 20);
            this.startUrlTextBox.TabIndex = 3;
            this.startUrlTextBox.Text = "Enter start Url";
            this.startUrlTextBox.Enter += new System.EventHandler(this.startUrlTextBox_Enter);
            this.startUrlTextBox.Leave += new System.EventHandler(this.startUrlTextBox_Leave);
            this.startUrlTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.startUrlTextBox_MouseUp);
            // 
            // searchTextTextBox
            // 
            this.searchTextTextBox.Location = new System.Drawing.Point(296, 27);
            this.searchTextTextBox.Name = "searchTextTextBox";
            this.searchTextTextBox.Size = new System.Drawing.Size(420, 20);
            this.searchTextTextBox.TabIndex = 4;
            this.searchTextTextBox.Text = "Enter text to search for";
            this.searchTextTextBox.Enter += new System.EventHandler(this.searchTextTextBox_Enter);
            this.searchTextTextBox.Leave += new System.EventHandler(this.searchTextTextBox_Leave);
            this.searchTextTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.searchTextTextBox_MouseUp);
            // 
            // nThreadsLabel
            // 
            this.nThreadsLabel.Location = new System.Drawing.Point(163, 50);
            this.nThreadsLabel.Name = "nThreadsLabel";
            this.nThreadsLabel.Size = new System.Drawing.Size(127, 31);
            this.nThreadsLabel.TabIndex = 5;
            this.nThreadsLabel.Text = "Maximum number of threads:";
            this.nThreadsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUrlsLabel
            // 
            this.nUrlsLabel.Location = new System.Drawing.Point(163, 81);
            this.nUrlsLabel.Name = "nUrlsLabel";
            this.nUrlsLabel.Size = new System.Drawing.Size(127, 20);
            this.nUrlsLabel.TabIndex = 6;
            this.nUrlsLabel.Text = "Maximum number of urls:";
            this.nUrlsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nThreadsTextBox
            // 
            this.nThreadsTextBox.Location = new System.Drawing.Point(296, 56);
            this.nThreadsTextBox.Name = "nThreadsTextBox";
            this.nThreadsTextBox.Size = new System.Drawing.Size(420, 20);
            this.nThreadsTextBox.TabIndex = 7;
            this.nThreadsTextBox.Text = "Enter maximum number of threads to load content";
            this.nThreadsTextBox.Enter += new System.EventHandler(this.nThreadsTextBox_Enter);
            this.nThreadsTextBox.Leave += new System.EventHandler(this.nThreadsTextBox_Leave);
            this.nThreadsTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nThreadsTextBox_MouseUp);
            // 
            // nUrlsTextBox
            // 
            this.nUrlsTextBox.Location = new System.Drawing.Point(296, 81);
            this.nUrlsTextBox.Name = "nUrlsTextBox";
            this.nUrlsTextBox.Size = new System.Drawing.Size(420, 20);
            this.nUrlsTextBox.TabIndex = 8;
            this.nUrlsTextBox.Text = "Enter maximum number of URLs to scan";
            this.nUrlsTextBox.Enter += new System.EventHandler(this.nUrlsTextBox_Enter);
            this.nUrlsTextBox.Leave += new System.EventHandler(this.nUrlsTextBox_Leave);
            this.nUrlsTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nUrlsTextBox_MouseUp);
            // 
            // progressLabel
            // 
            this.progressLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressLabel.Location = new System.Drawing.Point(153, 108);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(137, 32);
            this.progressLabel.TabIndex = 9;
            this.progressLabel.Text = "Progress";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressTextBox
            // 
            this.progressTextBox.Location = new System.Drawing.Point(15, 143);
            this.progressTextBox.Multiline = true;
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.progressTextBox.Size = new System.Drawing.Size(444, 282);
            this.progressTextBox.TabIndex = 10;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(96, 431);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(177, 431);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 12;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(780, 431);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resultsLabel
            // 
            this.resultsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultsLabel.Location = new System.Drawing.Point(608, 108);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(108, 32);
            this.resultsLabel.TabIndex = 14;
            this.resultsLabel.Text = "Results";
            this.resultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(465, 143);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTextBox.Size = new System.Drawing.Size(390, 282);
            this.resultsTextBox.TabIndex = 15;
            // 
            // completedLabel
            // 
            this.completedLabel.AutoSize = true;
            this.completedLabel.Location = new System.Drawing.Point(468, 435);
            this.completedLabel.Name = "completedLabel";
            this.completedLabel.Size = new System.Drawing.Size(0, 13);
            this.completedLabel.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(465, 432);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(309, 23);
            this.progressBar.TabIndex = 17;
            // 
            // progressBarBackgroundWorker
            // 
            this.progressBarBackgroundWorker.WorkerReportsProgress = true;
            this.progressBarBackgroundWorker.WorkerSupportsCancellation = true;
            this.progressBarBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.progressBarBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 466);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.completedLabel);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.progressTextBox);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.nUrlsTextBox);
            this.Controls.Add(this.nThreadsTextBox);
            this.Controls.Add(this.nUrlsLabel);
            this.Controls.Add(this.nThreadsLabel);
            this.Controls.Add(this.searchTextTextBox);
            this.Controls.Add(this.startUrlTextBox);
            this.Controls.Add(this.searchTextLabel);
            this.Controls.Add(this.startUrlLabel);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Spider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label startUrlLabel;
        private System.Windows.Forms.Label searchTextLabel;
        private System.Windows.Forms.TextBox startUrlTextBox;
        private System.Windows.Forms.TextBox searchTextTextBox;
        private System.Windows.Forms.Label nThreadsLabel;
        private System.Windows.Forms.Label nUrlsLabel;
        private System.Windows.Forms.TextBox nThreadsTextBox;
        private System.Windows.Forms.TextBox nUrlsTextBox;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.TextBox progressTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.Label completedLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker progressBarBackgroundWorker;
    }
}

