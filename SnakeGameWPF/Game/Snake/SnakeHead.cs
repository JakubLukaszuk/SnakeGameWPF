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
            _xPosition = Dimensions.SpawnSneakXPosPix;
            _yPosition = Dimensions.SpawnSneakYPosPix; 
            _width = Dimensions.SneakHeadHieghtPix;
            _height = Dimensions.SneakHeadWidthPix;
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
    }
}

