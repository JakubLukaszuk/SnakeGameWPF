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
    class Snake : NotificationBase
    {
        private ObservableCollection<SnakeBoadySegment> _snakeBody;
        private static object _itemsLock = new object();


        public Snake()
        {
            SnakeHead = new SnakeHead(SnakeDirection.Left);
            _snakeBody = new ObservableCollection<SnakeBoadySegment>();
            BindingOperations.EnableCollectionSynchronization(_snakeBody, _itemsLock);
        }

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

        public void UpdateSnakeStatus()
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

        }
    }

}
