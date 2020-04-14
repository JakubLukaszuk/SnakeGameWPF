using System;
using System.Collections.ObjectModel;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Game.Constant.Enum;

namespace SnakeGameWPF.Game.Snake
{
    internal class SnakeHead : SnakeSegment
    {
        public SnakeHead(SnakeDirection direction)
        : base(direction)
        {
            _xPosition = Dimensions.SpawnSneakXPos;
            _yPosition = Dimensions.SpawnSneakYPos; 
            _width = Dimensions.SneakHeadHieght;
            _height = Dimensions.SneakHeadWidth;
        }



        public bool IsHitSelf(ObservableCollection<SnakeBoadySegment> snakeTail)
        {
            foreach (SnakeBoadySegment snaekTailSegment in snakeTail)
            {
                if (_xPosition == snaekTailSegment.XPosition && _yPosition == snaekTailSegment.YPosition)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsHitBoundary()
        {
            if (_xPosition - (_width / 2.0) < Dimensions.SneakHeadWidth)
            {
                return true;
            }
            else if (_xPosition + (_width / 2.0) > 100 - Dimensions.SneakHeadWidth)
            {
                return true;
            }
            else if (_yPosition - (_height / 2.0) < Dimensions.SneakHeadHieght)
            {
                return true;
            }
            else if (_yPosition + (_height / 2.0) > 100 - Dimensions.SneakHeadHieght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHitFood(SnakeFood food)
        {
            double xDiff = Math.Abs(_xPosition - food.XPosition);
            double yDiff = Math.Abs(_yPosition - food.YPosition);

            if (xDiff < _width && yDiff < _height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

