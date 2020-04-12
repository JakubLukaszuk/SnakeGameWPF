using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameWPF.Game.Constant.Enum;
using SnakeGameWPF.Game.Constant;


namespace SnakeGameWPF.Game.Snake
{
    internal class SnakeSegment : BoardItem
    {
        protected SnakeDirection _travelDirection;

        public SnakeSegment()
        {

        }

        public SnakeSegment(SnakeDirection snaketravelDirection)
        {
            _travelDirection = snaketravelDirection;
        }


        public SnakeDirection TravelDirection
        {
            get
            {
                return _travelDirection;
            }
            set
            {
                _travelDirection = value;
                RaisePropertyChanged("DirectionOfTravel");
                RaisePropertyChanged("DirectionOfTravelDegrees");
            }
        }


        public void UpdatePosition()
        {
            switch (_travelDirection)
            {
                case SnakeDirection.Up:
                    _yPosition = _yPosition - Dimensions.SnakeStep;
                    Console.WriteLine("up");
                    Console.WriteLine("x :" + _xPosition + "y: " + _yPosition);

                    RaisePropertyChanged("YPosition");
                    RaisePropertyChanged("YPositionPixels");
                    RaisePropertyChanged("YPositionPixelsScreen");
                    break;
                case SnakeDirection.Down:
                    _yPosition = _yPosition + Dimensions.SnakeStep;
                    Console.WriteLine("dwon");
                    Console.WriteLine("x :" + _xPosition + "y: " + _yPosition);

                    RaisePropertyChanged("YPosition");
                    RaisePropertyChanged("YPositionPixels");
                    RaisePropertyChanged("YPositionPixelsScreen");
                    break;
                case SnakeDirection.Right:
                    _xPosition = _xPosition + Dimensions.SnakeStep;
                    Console.WriteLine("right");
                    Console.WriteLine("x :" + _xPosition + "y: " + _yPosition);

                    RaisePropertyChanged("XPosition");
                    RaisePropertyChanged("XPositionPixels");
                    RaisePropertyChanged("XPositionPixelsScreen");
                    break;
                case SnakeDirection.Left:
                    _xPosition = _xPosition - Dimensions.SnakeStep;
                    Console.WriteLine("left");
                    Console.WriteLine("x :" + _xPosition + "y: " + _yPosition);

                    RaisePropertyChanged("XPosition");
                    RaisePropertyChanged("XPositionPixels");
                    RaisePropertyChanged("XPositionPixelsScreen");
                    break;

            }
        }

    }
}
