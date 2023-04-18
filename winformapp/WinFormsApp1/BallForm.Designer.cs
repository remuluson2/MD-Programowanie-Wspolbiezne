namespace WinFormsApp1
{
    partial class BallForm
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
            components = new System.ComponentModel.Container();
            SimTimer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            StartButton = new Button();
            StopButton = new Button();
            TimerSpeedTextBoxLabel = new Label();
            TimerSpeedTextBox = new TextBox();
            SuspendLayout();
            // 
            // SimTimer
            // 
            SimTimer.Interval = 10;
            SimTimer.Tick += SimulationTick;
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.FromArgb(192, 255, 192);
            StartButton.Location = new Point(6, 9);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(131, 26);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Top;
            StopButton.BackColor = Color.FromArgb(255, 192, 192);
            StopButton.Location = new Point(153, 9);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(131, 26);
            StopButton.TabIndex = 1;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = false;
            StopButton.Click += StopButton_Click;
            // 
            // TimerSpeedTextBoxLabel
            // 
            TimerSpeedTextBoxLabel.AutoSize = true;
            TimerSpeedTextBoxLabel.Location = new Point(305, 15);
            TimerSpeedTextBoxLabel.Name = "TimerSpeedTextBoxLabel";
            TimerSpeedTextBoxLabel.Size = new Size(353, 15);
            TimerSpeedTextBoxLabel.TabIndex = 2;
            TimerSpeedTextBoxLabel.Text = "Current Timer Speed(changing this number will make timer stop):";
            // 
            // TimerSpeedTextBox
            // 
            TimerSpeedTextBox.Location = new Point(664, 12);
            TimerSpeedTextBox.Name = "TimerSpeedTextBox";
            TimerSpeedTextBox.Size = new Size(103, 23);
            TimerSpeedTextBox.TabIndex = 3;
            TimerSpeedTextBox.TextChanged += TimerSpeedTextBox_TextChanged;
            // 
            // BallForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(984, 461);
            Controls.Add(TimerSpeedTextBox);
            Controls.Add(TimerSpeedTextBoxLabel);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Name = "BallForm";
            Text = "BallForm";
            Load += BallForm_Load;
            Paint += PaintBalls;
            Resize += BallForm_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer SimTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button StartButton;
        private Button StopButton;
        private Label TimerSpeedTextBoxLabel;
        private TextBox TimerSpeedTextBox;
    }
}