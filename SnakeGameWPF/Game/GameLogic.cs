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
        }

        private void StartNewGame()
        {
            Snake = new SnakeGameWPF.Game.Snake.Snake();
            RaisePropertyChanged("TheSnake");

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
                // Game over.
                if (_gameTimer.IsEnabled)
                {
                    _gameTimer.Stop();  // Stop the game timer.
                }
            }
            else
            {
                // Game running.
                Snake.UpdateSnakeStatus();
            }
        }


        public void ProcessKeyboardEvent(SnakeDirection direction)
        {
            Snake.SetSnakeDirection(direction);
        }

        public SnakeGameWPF.Game.Snake.Snake Snake { get; private set; }


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
