using BallFormsWPFMD.PresentationLayer;
using LogicLayer;
using System;
using System.Timers;

namespace PresentationLayer.ViewModel
{
    public class BallViewModel : ViewModelBase
    {
        public IBallHolder BallsCollection { get; set; }
        public StartCommand StartCommand { get; set; }
        public StopCommand StopCommand { get; set; }

        public double SimAreaWidth { get; set; }
        public double SimAreaHeight { get; set; }

        private string ballNumberInputString;

        public string BallNumberInputString 
        {  
           get
            {
                return ballNumberInputString;
            }

           set 
           { 
                ballNumberInputString = value;
                OnPropertyChanged();
                OnNumberOfBallsChange();
                StartCommand.PokePossibleExecuteChanged();
           }
        }

        private string ballSizeInputString;

        public string BallSizeInputString
        {
            get
            {
                return ballSizeInputString;
            }

            set
            {
                ballSizeInputString = value;
                OnPropertyChanged();
                OnSizeOfBallsChange();
            }
        }

        public BallViewModel()
        {

            StartCommand = new StartCommand(this);
            StopCommand = new StopCommand(this);
            BallsCollection = new BallHolder();


            ballNumberInputString = string.Empty;
            ballSizeInputString = "100";

            SimAreaWidth = 800;
            SimAreaHeight = 340;

        }

        public void OnNumberOfBallsChange()
        {
            BallsCollection.Clear();
            BallsCollection.SetNewArea(SimAreaWidth, SimAreaHeight);
            BallsCollection.InitBalls(int.Parse(BallNumberInputString));
        }

        public void OnSizeOfBallsChange()
        {
            BallsCollection.Clear();
            BallsCollection.SetNewSize(int.Parse(BallSizeInputString));
            BallsCollection.InitBalls(int.Parse(BallNumberInputString));
        }

        public void OnStartCommand()
        {
            BallsCollection.StartTimer();
        }

        public void OnStopCommand()
        {
            BallsCollection.StopTimer();
        }

    }
}
