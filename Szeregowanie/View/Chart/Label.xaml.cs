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
    /// Interaction logic for Label.xaml
    /// </summary>
    public partial class Label : UserControl
    {
        public Label(int number, int height)
        {
            InitializeComponent();
            LabelName.Text = "Maszyna " + number.ToString();
            Width = 100;
            Height = height;
            Margin = new Thickness(Width * -1, 0, 0, 0);
        }
    }
}
            
           