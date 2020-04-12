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
        public static event HitSnake OnHitSnake;
        private ImageService _imageService;
        private GameImage _snakeModelImage;


        public GameWindowViewModel()
        {
            _snakeModelImage= new GameImage();
            _snakeModelImage.Image = new BitmapImage();
            _imageService = new ImageService();
            SnakeGameLogic = new GameLogic();

            UpArrowKeyPressedCommand = new DelegateCommand(OnUpArrowKeyPressed);
            DownArrowKeyPressedCommand = new DelegateCommand(OnDownArrowKeyPressed);
            RightArrowKeyPressedCommand = new DelegateCommand(OnRightArrowKeyPressed);
            LeftKeyArrrowPressedCommand = new DelegateCommand(OnLeftArrowKeyPressed);

            SnakeGameLogic.WholeSnake.OnHitSnakeFood += OnHitFoodHandler;

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

        public GameImage SnakeModelImage {
            get 
            { 
                return _snakeModelImage; 
            } 
            private set
            { 
                if(_snakeModelImage != value && value != null)
                {
                    _snakeModelImage = value;
                    RaisePropertyChanged("SnakeModelImage");
                    
                }
           
            }
        }

        private void OnHitFoodHandler()
        {
            SnakeModelImage = _imageService.FetchRandomSnakeImage();
        }

    }
}
