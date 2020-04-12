using System.Windows.Input;
using SnakeGameWPF.Common;
using SnakeGameWPF.Game;
using SnakeGameWPF.Game.Constant.Enum;

namespace SnakeGameWPF.ViewModel
{
    class GameWindowViewModel : ViewModelBase
    {
    
        public GameWindowViewModel()
        {
            SnakeGameLogic = new GameLogic();

            UpArrowKeyPressedCommand = new DelegateCommand(OnUpArrowKeyPressed);
            DownArrowKeyPressedCommand = new DelegateCommand(OnDownArrowKeyPressed);
            RightArrowKeyPressedCommand = new DelegateCommand(OnRightArrowKeyPressed);
            LeftKeyArrrowPressedCommand = new DelegateCommand(OnLeftArrowKeyPressed);
        }

        private void OnUpArrowKeyPressed(object arg)
        {
            if(SnakeGameLogic.IsGameRunning)
            {
                SnakeGameLogic.ProcessKeyboardEvent(SnakeDirection.Up);
            }
        }

        private void OnDownArrowKeyPressed(object arg)
        {
            if (SnakeGameLogic.IsGameRunning)
            {
                SnakeGameLogic.ProcessKeyboardEvent(SnakeDirection.Down);
            }
        }

        private void OnRightArrowKeyPressed(object arg)
        {
            if (SnakeGameLogic.IsGameRunning)
            {
                SnakeGameLogic.ProcessKeyboardEvent(SnakeDirection.Right);
            }
        }

        private void OnLeftArrowKeyPressed(object arg)
        {
            if (SnakeGameLogic.IsGameRunning)
            {
                SnakeGameLogic.ProcessKeyboardEvent(SnakeDirection.Left);
            }
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

        public GameLogic SnakeGameLogic { get; }

    }
}
