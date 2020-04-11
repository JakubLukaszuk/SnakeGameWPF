using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Game.Constant.Enum;

namespace SnakeGameWPF.Game.Snake
{
    internal class SnakeBoadySegment : SnakeSegment
    {
        public SnakeBoadySegment(Snake theSnake)
        {

            _width = Dimensions.SnakeBoadyWidth;
            _height = Dimensions.SnakeBoadyHieght;

            SnakeSegment currentLastSnakePart;
            if(theSnake.SnakeBody.Count != 0)
            {
                currentLastSnakePart = theSnake.SnakeBody.Last();

            }
            else
            {
                currentLastSnakePart = theSnake.SnakeHead;
            }

            switch(currentLastSnakePart.TravelDirection)
            {
                case SnakeDirection.Up:
                    _xPosition = currentLastSnakePart.XPosition;
                    _yPosition = currentLastSnakePart.YPosition + _height;
                    _travelDirection = SnakeDirection.Up;
                    break;
                case SnakeDirection.Down:
                    _xPosition = currentLastSnakePart.XPosition;
                    _yPosition = currentLastSnakePart.YPosition - _height;
                    _travelDirection = SnakeDirection.Down;
                    break;
                case SnakeDirection.Right:
                    _xPosition = currentLastSnakePart.XPosition - _width;
                    _yPosition = currentLastSnakePart.YPosition;
                    _travelDirection = SnakeDirection.Right;
                    break;
                case SnakeDirection.Left:
                    _xPosition = currentLastSnakePart.XPosition + _width;
                    _yPosition = currentLastSnakePart.YPosition;
                    _travelDirection = SnakeDirection.Left;
                    break;
            }
        }

        public SnakeBoadySegment(SnakeHead snakeHead)
        {
            _width = snakeHead.Width;
            _height = snakeHead.Height;
            _travelDirection = snakeHead.TravelDirection;

            switch(_travelDirection)
            {
                case SnakeDirection.Up:
                    _xPosition = snakeHead.XPosition;
                    _yPosition = snakeHead.YPosition + _height;
                    break;
                case SnakeDirection.Down:
                    _xPosition = snakeHead.XPosition;
                    _yPosition = snakeHead.YPosition - _height;
                    break;
                case SnakeDirection.Right:
                    _xPosition = snakeHead.XPosition - _width;
                    _yPosition = snakeHead.YPosition;
                    break;
                case SnakeDirection.Left:
                    _xPosition = snakeHead.XPosition + _width;
                    _yPosition = snakeHead.YPosition;
                    break;
            }
            UpdatePosition();
        }

        public SnakeBoadySegment(SnakeBoadySegment snakeBodyPart)
        {
            _xPosition = snakeBodyPart.XPosition;
            _yPosition = snakeBodyPart.YPosition;
            _width = snakeBodyPart.WidthPixels;
            _height = snakeBodyPart.HeightPixels;
            _travelDirection = snakeBodyPart.TravelDirection;
        }

    }
}
