using SnakeGameWPF.Model;
using System;
using SnakeGameWPF.Game.Constant;
using SnakeGameWPF.Data.Provider;

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

            try
            {
              bitMapImage = BitMapImageProvider.FetchImageFromInternet(imagelinks[randomIndex]);
            }
            catch(System.Net.WebException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;            
            }
            return bitMapImage;
        }
    }
}
