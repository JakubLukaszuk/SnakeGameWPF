using System.Windows.Input;
using SnakeGameWPF.Common;
using SnakeGameWPF.Game;
using SnakeGameWPF.Game.Constant.Enum;
using SnakeGameWPF.Data.Service;
using SnakeGameWPF.Model;
using System.Windows.Media.Imaging;

namespace SnakeGameWPF.ViewModel
{
    class GameWindowViewModel : ViewModelBase
    {
        private ImageService _imageService;

        public GameWindowViewModel()
        {
            _imageService = new ImageService();
            SnakeGameLogic = new GameLogic();

            StartButtonPressedCommand = new DelegateCommand(OnStartNewGame);
            RestartButtonPressedCommand = new DelegateCommand(OnRestartGame);

            UpArrowKeyPressedCommand = new DelegateCommand(OnUpArrowKeyPressed);
            DownArrowKeyPressedCommand = new DelegateCommand(OnDownArrowKeyPressed);
            RightArrowKeyPressedCommand = new DelegateCommand(OnRightArrowKeyPressed);
            LeftKeyArrrowPressedCommand = new DelegateCommand(OnLeftArrowKeyPressed);

        }

        private void OnUpArrowKeyPressed(object arg)
        {
            if (SnakeGameLogic.IsGameRunning)
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

        private void OnStartNewGame(object arg)
        {
            SnakeGameLogic.StartNewGame();
        }

        private void OnRestartGame(object arg)
        {
            SnakeGameLogic.RestartGame();
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
        public ICommand StartButtonPressedCommand
        {
            get;
            private set;
        }

        public ICommand RestartButtonPressedCommand
        {
            get;
            private set;
        }

        public GameLogic SnakeGameLogic { get; }



    }
}
