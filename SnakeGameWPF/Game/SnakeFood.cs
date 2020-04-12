using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Game.Snake;
namespace SnakeGameWPF.Game
{
    class SnakeFood : BoardItem
    {
        private Random _randomNumber;

        public SnakeFood()
        {
            _randomNumber = new Random((int)DateTime.Now.Ticks);
            _xPosition = _randomNumber.Next(Dimensions.MinFoodPosition, Dimensions.MaxFoodPostion);
            _yPosition = _randomNumber.Next(Dimensions.MinFoodPosition, Dimensions.MaxFoodPostion);
            _width = Dimensions.SnakeFoodHieght;
            _height = Dimensions.SneakHeadHieght;
        }

        public void Move(WholeSnake snake)
        {
            bool foodMoved = false;
            double xDiff;
            double yDiff;

            while (!foodMoved)
            {
                _xPosition = _randomNumber.Next(Dimensions.MinFoodPosition, Dimensions.MaxFoodPostion);
                _yPosition = _randomNumber.Next(Dimensions.MinFoodPosition, Dimensions.MaxFoodPostion);
                xDiff = Math.Abs(_xPosition - snake.SnakeHead.XPosition);
                yDiff = Math.Abs(_yPosition - snake.SnakeHead.YPosition);
                if (xDiff > Dimensions.PlaceingFoodBuffer * _width || yDiff > Dimensions.PlaceingFoodBuffer * _height)
                {
                    foreach (SnakeBoadySegment bodyPart in snake.SnakeBody)
                    {
                        xDiff = Math.Abs(_xPosition - bodyPart.XPosition);
                        yDiff = Math.Abs(_yPosition - bodyPart.YPosition);
                        if (xDiff > Dimensions.PlaceingFoodBuffer * _width || yDiff > Dimensions.PlaceingFoodBuffer * _height)
                        {
                            foodMoved = true;
                        }
                        else
                        {
                            foodMoved = false;
                            break;
                        }
                    }
                }
            }
            RaisePropertyChanged("XPosition");
            RaisePropertyChanged("XPositionPixels");
            RaisePropertyChanged("XPositionPixelsScreen");
            RaisePropertyChanged("YPosition");
            RaisePropertyChanged("YPositionPixels");
            RaisePropertyChanged("YPositionPixelsScreen");
        }
    }
}
