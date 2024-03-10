using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using BallFormsWPFMD.PresentationLayer;
using LogicLayer;

namespace PresentationLayer.ViewModel
{
    public class BallViewModel : ViewModelBase
    {
        IBallHolder BallHolder { get; set; }
        public StartCommand StartCommand { get; set; }
        public StopCommand StopCommand { get; set; }
        public int ballnumber;

        private string ballInputNumberString;

        public string BallNumberInputString 
        {  
           get
            {
                return ballInputNumberString;
            }

           set 
           { 
                ballInputNumberString = value;
                OnPropertyChanged();
                StartCommand.PokePossibleExecuteChanged();
           }
        }

        private string testText;

        public string TestText
        {
            get
            {
                return testText;
            }

            set
            {
                testText = value;
                OnPropertyChanged();
            }
        }

        public BallViewModel() 
        {
            ballInputNumberString = string.Empty;
            StartCommand = new StartCommand(this);
            StopCommand = new StopCommand(this);
            BallHolder = new BallHolder();
        }

        public void OnStartCommand()
        {
            ballInputNumberString = "Start!";
        }

        public void OnEndCommand()
        {
            MessageBox.Show("END!");
        }

    }
}
