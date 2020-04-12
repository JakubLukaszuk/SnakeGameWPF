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

                    RaisePropertyChanged("YPosition");
                    RaisePropertyChanged("YPositionPixels");
                    RaisePropertyChanged("YPositionPixelsScreen");
                    break;
                case SnakeDirection.Down:
                    _yPosition = _yPosition + Dimensions.SnakeStep;

                    RaisePropertyChanged("YPosition");
                    RaisePropertyChanged("YPositionPixels");
                    RaisePropertyChanged("YPositionPixelsScreen");
                    break;
                case SnakeDirection.Right:
                    _xPosition = _xPosition + Dimensions.SnakeStep;

                    RaisePropertyChanged("XPosition");
                    RaisePropertyChanged("XPositionPixels");
                    RaisePropertyChanged("XPositionPixelsScreen");
                    break;
                case SnakeDirection.Left:
                    _xPosition = _xPosition - Dimensions.SnakeStep;

                    RaisePropertyChanged("XPosition");
                    RaisePropertyChanged("XPositionPixels");
                    RaisePropertyChanged("XPositionPixelsScreen");
                    break;

            }
        }

    }
}
