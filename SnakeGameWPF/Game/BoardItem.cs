using SnakeGameWPF.Common;
using SnakeGameWPF.Game.Constant;

namespace SnakeGameWPF.Game
{
    internal class  BoardItem : NotificationBase
    {

        protected double _xPosition;
        protected double _yPosition;
        protected double _width;
        protected double _height;


        public double XPosition
        {
            get
            {
                return _xPosition;
            }
        }


        public double YPosition
        {
            get
            {
                return _yPosition;
            }
        }


        public double XPositionPixels
        {
            get
            {
                double val;
                val = (_xPosition / 100) * Dimensions.GameBoardHeightPix;
                return val;
            }
        }


        public double YPositionPixels
        {
            get
            {
                double val;
                val = (_yPosition / 100) * Dimensions.GameBoardHeightPix;

                return val;
            }
        }

        /// <summary>
        /// Gets or sets the current x ordinate in pixels, shifted for correct rendering on a screen.
        /// </summary>
        public double XPositionPixelsScreen
        {

            get
            {
                double val;
                val = ((_xPosition - (_width / 2.0)) / 100.0) * Dimensions.GameBoardHeightPix;

                return val;
            }
        }

        /// <summary>
        /// Gets or sets the current y ordinate in pixels, shifted for correct rendering on a screen.
        /// </summary>
        public double YPositionPixelsScreen
        {
            get
            {
                double val;
                val = ((_yPosition - (_height / 2.0)) / 100.0) * Dimensions.GameBoardHeightPix;
;

                return val;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
        }

        public double Height
        {
            get
            {
                return _height;
            }
        }


        public double WidthPixels
        {
            get
            {
                return (_width / 100.0) * Dimensions.GameBoardWidthPix;
            }
        }


        public double HeightPixels
        {
            get
            {
                return (_height / 100.0) * Dimensions.GameBoardHeightPix;
            }
        }
    }
}
