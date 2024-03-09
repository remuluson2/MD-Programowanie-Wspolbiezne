using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LogicLayer;

namespace PresentationLayer.ViewModel
{
    public class BallViewModel
    {
        IBallHolder BallHolder { get; set; }
        public StartCommand StartCommand { get; set; }
        public EndCommand EndCommand { get; set; }
        public int ballnumber;

        public BallViewModel() 
        { 
            StartCommand = new StartCommand(this);
            EndCommand = new EndCommand(this);
            BallHolder = new BallHolder();
        }

        public void OnStartCommand()
        {

        }

        public void OnEndCommand()
        {
            
        }
    }
}
