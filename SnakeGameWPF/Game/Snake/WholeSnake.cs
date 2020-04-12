using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SnakeGameWPF.Common;
using SnakeGameWPF.Game.Constant.Enum;

namespace SnakeGameWPF.Game.Snake
{
    internal class WholeSnake : NotificationBase
    {
        private ObservableCollection<SnakeBoadySegment> _snakeBody;
        private static object _itemsLock = new object();


        public WholeSnake()
        {
            SnakeHead = new SnakeHead(SnakeDirection.Left);
            _snakeBody = new ObservableCollection<SnakeBoadySegment>();
            BindingOperations.EnableCollectionSynchronization(_snakeBody, _itemsLock);
        }

        public static event HitBoundary OnHitBoundary;
        public static event HitSnake OnHitSnake;
        public static event HitSnakeFoood OnHitSnakeFood;

        public SnakeHead SnakeHead { get; }

        public ObservableCollection<SnakeBoadySegment> SnakeBody
        {
            get
            {
                if (_snakeBody == null)
                {
                    _snakeBody = new ObservableCollection<SnakeBoadySegment>();
                }
                return _snakeBody;
            }
        }

        public void SetSnakeDirection(SnakeDirection direction)
        {
            SnakeHead.TravelDirection = direction;
        }

        public void UpdateSnakeStatus(SnakeFood snakeFood)
        {
            SnakeHead.UpdatePosition();    
            SnakeDirection previousDirection;
            SnakeDirection nextDirection = SnakeHead.TravelDirection;
            foreach (SnakeBoadySegment bodyPart in _snakeBody)
            {
                bodyPart.UpdatePosition();
                previousDirection = bodyPart.TravelDirection;
                bodyPart.TravelDirection = nextDirection;
                nextDirection = previousDirection;
            }

            if (SnakeHead.IsHitBoundary())
            {
                OnHitBoundary?.Invoke();
            }

            if (SnakeHead.IsHitSelf(_snakeBody))
            {
                OnHitSnake?.Invoke();
            }

            if (SnakeHead.IsHitFood(snakeFood))
            {
                SnakeBoadySegment snakeBodyPart = new SnakeBoadySegment(this);
                _snakeBody.Add(snakeBodyPart);

                OnHitSnakeFood?.Invoke();
            }

        }
    }

}
