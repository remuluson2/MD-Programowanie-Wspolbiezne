using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BallForm : Form
    {
        IBallManager manager;
        public BallForm()
        {
            InitializeComponent();
            manager = new BallManager();

        }

        private void BallForm_Load(object sender, EventArgs e)
        {
            manager.UpdateSize(this.ClientSize.Width, this.ClientSize.Height);
            manager.AddBall(new Vector2(10, 20));
            TimerSpeedTextBox.Text = SimTimer.Interval.ToString();
            SimTimer.Start();
        }

        private void PaintBalls(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            manager.DrawBalls(e);
        }

        private void SimulationTick(object sender, EventArgs e)
        {
            manager.UpdateBalls();
            this.Refresh();
        }

        private void BallForm_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            manager.UpdateSize(control.ClientSize.Width, control.ClientSize.Height);
        }

        private void TimerSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            SimTimer.Stop();
            int newInterval;
            if(int.TryParse(TimerSpeedTextBox.Text, out newInterval))
            SimTimer.Interval = newInterval;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SimTimer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            SimTimer.Stop();
        }
    }
}
