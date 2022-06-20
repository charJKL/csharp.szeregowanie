using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szeregowanie.View.Chart
{
    /// <summary>
    /// Interaction logic for Block.xaml
    /// </summary>
    public partial class Block : UserControl
    {
        public Block(int taskNumber)
        {
            InitializeComponent();
            Number.Text = taskNumber.ToString();
        }

        public void SetPosition(int line, int start, int width, int height)
        {
            
            Width = width;
            Height = height;
            Canvas.SetLeft(this, start);
            Canvas.SetTop(this, line);
        }

        public void SetBackground(SolidColorBrush color)
        {
            Background = color;
            Number.Foreground = new SolidColorBrush(ContrastColor(color));
        }

        private Color ContrastColor(SolidColorBrush color)
        {
            byte rgb = 0;
            double x = 1 - (0.299 * color.Color.R + 0.587 * color.Color.G + 0.114 * color.Color.B) / 255;
            if (x > 0.5)
                rgb = 255;

            return Color.FromRgb(rgb, rgb, rgb);
        }

    }
}
