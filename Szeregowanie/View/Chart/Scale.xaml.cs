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
    /// Interaction logic for Scale.xaml
    /// </summary>
    public partial class Scale : UserControl
    {
        public Scale(int value, int width, int height)
        {
            InitializeComponent();
            Value.Text = value.ToString();
            Width = width;
            Height = height;
            Margin = new Thickness((int)(Width / -2), 0, 0, 0);
        }
    }
}