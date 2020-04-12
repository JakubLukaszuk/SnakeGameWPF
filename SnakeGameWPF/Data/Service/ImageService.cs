using SnakeGameWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Data.Provider;
using System.Runtime.InteropServices;

namespace SnakeGameWPF.Data.Service
{
    class ImageService
    {
        int pervIndex;

        public GameImage FetchRandomSnakeImage()
        {
            GameImage bitMapImage = new GameImage();

            string[] imagelinks = new string[GameInfo.ImagePath.Length-1];
            Array.Copy(GameInfo.ImagePath, imagelinks, GameInfo.ImagePath.Length-1);
            int randomIndex = new Random().Next(0, imagelinks.Length);
            while(pervIndex== randomIndex)
            {
                randomIndex = new Random().Next(0, imagelinks.Length);
            }
            pervIndex = randomIndex;

            Console.WriteLine(randomIndex);

            try
            {
              bitMapImage = BitMapImageProvider.FetchImageFromInternet(imagelinks[randomIndex]);
            }
            catch (ExternalException)
            {

            }
            catch (ArgumentNullException)
            {
                
            }
            return bitMapImage;
        }
    }
}
