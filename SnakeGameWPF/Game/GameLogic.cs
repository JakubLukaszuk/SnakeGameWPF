using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using SnakeGameWPF.Common;
using SnakeGameWPF.Game.Constant.Enum;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Game.Snake;
using SnakeGameWPF.Model;
using SnakeGameWPF.Data.Service;


namespace SnakeGameWPF.Game
{
    class GameLogic : NotificationBase
    {
        GameImage _snakeModelImage;
        private int _gameStepMilliSeconds;
        private DispatcherTimer _gameTimer, timeInGameTimer;
        private ImageService _imageService;


        public GameLogic()
        {
            IsGameOver = true;
            _imageService = new ImageService();
        }

        public void StartNewGame()
        {
            GamePoints = new GamePoints();

            WholeSnake = new WholeSnake();
            RaisePropertyChanged("WholeSnake");

            WholeSnake.OnHitBoundary += new HitBoundary(HitBoundaryEventHandler);
            WholeSnake.OnHitSnake += new HitSnake(HitSnakeEventHandler);
            WholeSnake.OnHitSnakeFood += new HitSnakeFoood(HitSnakeFoodHandler);

            SnakeFood = new SnakeFood();
            RaisePropertyChanged("SnakeFood");

            IsGameOver = false;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");


            _gameStepMilliSeconds = GameInfo.DefaultGameStepMilliSeconds;
            _gameTimer = new DispatcherTimer();
            _gameTimer.Interval = TimeSpan.FromMilliseconds(_gameStepMilliSeconds);
            _gameTimer.Tick += new EventHandler(GameTimerEventHandler);
            _gameTimer.Start();

            timeInGameTimer = new DispatcherTimer();
            timeInGameTimer.Interval = TimeSpan.FromSeconds(1);
            timeInGameTimer.Tick += new EventHandler(TimeInGameTimerEventHandler);
            timeInGameTimer.Start();
        }

        public void RestartGame()
        {
            _gameTimer.Stop();
            StartNewGame();
        }

        private void GameTimerEventHandler(object sender, EventArgs e)
        {
            if (IsGameOver)
            {
                if (_gameTimer.IsEnabled)
                {
                    _gameTimer.Stop();  
                }
            }
            else
            {
                WholeSnake.UpdateSnakeStatus(SnakeFood);
            }
        }

        private void TimeInGameTimerEventHandler(object sender, EventArgs e)
        {
            if (IsGameOver)
            {
                if (timeInGameTimer.IsEnabled)
                {
                    timeInGameTimer.Stop();
                }
            }
            else
            {
                RaisePropertyChanged("GamePoints");
                GamePoints.SecondsSurvived++;
            }
        }

        public void HitSnakeFoodHandler()
        {
            SnakeModelImage = _imageService.FetchRandomSnakeImage();
            SnakeFood.Move(WholeSnake);
            GamePoints.Points++;
            RaisePropertyChanged("GamePoints");
        }

        private void HitBoundaryEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }


        private void HitSnakeEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }

        public GameImage SnakeModelImage
        {
            get
            {
                return _snakeModelImage;
            }
            private set
            {
                if (_snakeModelImage != value && value != null)
                {
                    _snakeModelImage = value;
                    RaisePropertyChanged("SnakeModelImage");

                }

            }
        }


        public void ProcessKeyboardEvent(SnakeDirection direction)
        {
            WholeSnake.SetSnakeDirection(direction);
        }

        public WholeSnake WholeSnake { get; private set; }

        public SnakeFood SnakeFood { get; private set; }

        public GamePoints GamePoints { get; private set; }


        public bool IsGameOver { get; private set; }


        public bool IsGameRunning
        {
            get
            {
                return !IsGameOver;
            }
        }

    }
}
