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


namespace SnakeGameWPF.Game
{
    class GameLogic : NotificationBase
    {
        private int _gameStepMilliSeconds;
        private DispatcherTimer _gameTimer;


        public GameLogic()
        {

            StartNewGame();

            WholeSnake.OnHitBoundary += new HitBoundary(HitBoundaryEventHandler);
            WholeSnake.OnHitSnake += new HitSnake(HitSnakeEventHandler);
            WholeSnake.OnHitSnakeFood += new HitSnakeFoood(HitSnakeFoodHandler);
        }

        private void StartNewGame()
        {
            WholeSnake = new WholeSnake();
            RaisePropertyChanged("WholeSnake");

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

        public void HitSnakeFoodHandler()
        {
            SnakeFood.Move(WholeSnake);
        }

        private void HitBoundaryEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }

        /// <summary>
        /// The HitSnakeEventHandler is called to process an OnHitSnake event.
        /// </summary>
        private void HitSnakeEventHandler()
        {
            IsGameOver = true;
            RaisePropertyChanged("IsGameOver");
            RaisePropertyChanged("IsGameRunning");
        }


        public void ProcessKeyboardEvent(SnakeDirection direction)
        {
            WholeSnake.SetSnakeDirection(direction);
        }

        public WholeSnake WholeSnake { get; private set; }

        public SnakeFood SnakeFood { get; private set; }


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
