using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
    public class StartCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        BallViewModel _ballViewModel;

        public StartCommand(BallViewModel viewModel)
        {
            _ballViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            if ( parameter != null)
            {
                return int.TryParse((string)parameter, out _);
            }
            return false;
        }

        public void PokePossibleExecuteChanged() 
        { 
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object? parameter)
        {
            _ballViewModel.OnStartCommand();
        }
    }
}
