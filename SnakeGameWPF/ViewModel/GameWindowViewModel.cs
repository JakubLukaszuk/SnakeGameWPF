using System.Windows.Input;
using SnakeGameWPF.Common; 

namespace SnakeGameWPF.ViewModel
{
    class GameWindowViewModel : ViewModelBase
    {
        public GameWindowViewModel()
        {
            UpArrowKeyPressedCommand = new DelegateCommand(OnUpArrowKeyPressed);
            DownArrowKeyPressedCommand = new DelegateCommand(OnDownArrowKeyPressed);
            RightArrowKeyPressedCommand = new DelegateCommand(OnRightArrowKeyPressed);
            LeftKeyArrrowPressedCommand = new DelegateCommand(OnLeftArrowKeyPressed);
        }

        private void OnUpArrowKeyPressed(object arg)
        {
            System.Console.WriteLine("UP");
        }

        private void OnDownArrowKeyPressed(object arg)
        {
                
        }

        private void OnRightArrowKeyPressed(object arg)
        {

        }

        private void OnLeftArrowKeyPressed(object arg)
        {

        }

        public ICommand UpArrowKeyPressedCommand
        {
            get;
            private set;
        }

        public ICommand DownArrowKeyPressedCommand
        {
            get;
            private set;
        }

        public ICommand RightArrowKeyPressedCommand
        {
            get;
            private set;
        }

        public ICommand LeftKeyArrrowPressedCommand
        {
            get;
            private set;
        }
    }
}
