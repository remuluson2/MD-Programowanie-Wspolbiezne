﻿using BallFormApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BallForm : Form
    {
        IBallManager manager;
        System.Timers.Timer SimTimer;
        public BallForm()
        {
            InitializeComponent();
            manager = new BallManager();
            SimTimer = new System.Timers.Timer();
            SimTimer.Elapsed += SimulationTick;
            SimTimer.Interval = 10;
        }

        private void BallForm_Load(object sender, EventArgs e)
        {
            manager.UpdateSize(this.ClientSize.Width, this.ClientSize.Height);
            for(int i = 0; i < 2; i++)
            manager.AddBall();
            TimerSpeedTextBox.Text = "2";
            SimTimer.Start();
        }

        private void PaintBalls(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            manager.DrawBalls(e);
        }

        private void SimulationTick(object sender, ElapsedEventArgs e)
        {
            manager.UpdateBalls();
            Refresh();
        }

        private void BallForm_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            manager?.UpdateSize(control.ClientSize.Width, control.ClientSize.Height);
        }

        private void TimerSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            SimTimer.Stop();
            int newCount;
            if (int.TryParse(TimerSpeedTextBox.Text, out newCount))
            {
                manager.ClearBalls();
                for(int i = 0;i< newCount; i++)
                {
                    manager.AddBall();
                }
            }
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
