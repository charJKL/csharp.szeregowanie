using System;
using System.Windows.Media;
using Szeregowanie.Utility.Factories;

namespace Szeregowanie.Model
{
    class TaskWrapper
    {
        public int[] Time { get; set; }
        public SolidColorBrush Color { get; set; }
        public int Number { get; set; }

        public TaskWrapper()
        {
            Time = new int[2] { 0, 0 };
            Number = NumerFactory.GetNumber();
            Color = ColorFactory.GetColor(Number);
        }

        public bool isValid()
        {
            for(int j=0; j < Time.Length; ++j)
            {
                if (Time[j] < 0)
                    return false;
            }
            return true;
        }

    }
}