using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModel
{
    public class StopCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;
        BallViewModel _ballViewModel;

        public StopCommand(BallViewModel viewModel) 
        { 
            _ballViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _ballViewModel.OnEndCommand();
        }
    }
}
