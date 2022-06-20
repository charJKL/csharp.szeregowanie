using System;
using System.Windows.Media;

namespace Szeregowanie.Utility.Factories
{
    class ColorFactory
    {
        private static Color[] List = new Color[]
        {
            Color.FromRgb(255,255,255),
            Color.FromRgb(255,0,0),
            Color.FromRgb(0,255,0),
            Color.FromRgb(0,0,255),
            Color.FromRgb(255,255,0),
            Color.FromRgb(255,0,255),
            Color.FromRgb(0,255,255),
            Color.FromRgb(128,128,128),
            Color.FromRgb(128,0,0),
            Color.FromRgb(0,128,0),
            Color.FromRgb(0,0,128),
            Color.FromRgb(128,128,0),
            Color.FromRgb(128,0,128),
            Color.FromRgb(0,128,128),
            Color.FromRgb(192,192,192),
            Color.FromRgb(192,0,0),
            Color.FromRgb(0,192,0),
            Color.FromRgb(0,0,192),
            Color.FromRgb(192,192,0),
            Color.FromRgb(192,0,192),
            Color.FromRgb(0,192,192),
        };
        private static readonly Random random = new Random();

        public static SolidColorBrush GetColor(int id)
        {
            if (ColorFactory.List.Length - 1 < id)
                return ColorFactory.Generate();
            return new SolidColorBrush(ColorFactory.List[id]);
        }

        private static SolidColorBrush Generate()
        {
            Color randomColor = Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
            return new SolidColorBrush(randomColor);
        }

    }
}