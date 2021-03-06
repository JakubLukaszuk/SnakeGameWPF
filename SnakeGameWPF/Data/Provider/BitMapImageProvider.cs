﻿using SnakeGameWPF.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace SnakeGameWPF.Data.Provider
{
    public static class BitMapImageProvider
    {
        public static GameImage FetchImageFromInternet(string imageUrl)
        {
            Bitmap bitmap;

            using (WebClient client = new WebClient())
            {
                using (Stream stream = client.OpenRead(imageUrl))
                {
                    bitmap = new Bitmap(stream);
                }
            }

            GameImage bitMapImage = new GameImage();
            bitMapImage.ImageName = Path.GetFileNameWithoutExtension(imageUrl);
            bitMapImage.Image = ToBitmapImage(bitmap);

            return bitMapImage;
        }


        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

    }
}
