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

namespace Szeregowanie.View
{
    /// <summary>
    /// Interaction logic for Node.xaml
    /// </summary>
    public partial class Node : UserControl
    {
        public Node ParentNode { get; set;}
        public int Names { get; set; }
        public Stack<int> Available { get; set; }

        public Node(int width, int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            ParentNode = null;
            Names = 55;
        }

        public void setPosition(int left, int top)
        {
            Canvas.SetLeft(this, left - Math.Floor(Width / 2));
            Canvas.SetTop(this, top - Math.Floor(Height / 2));
        }
        
        public void setName(int name)
        {
            Names = name;

            //((Label) labelName).Content = name;
            // //node.SetValue(FrameworkElement.NameProperty, "");
        }

        public double Left()
        {
            return Canvas.GetLeft(this) + Math.Floor(Width / 2);
        }

        public void initName()
        {
            var name = Name;
        }

        public void setParent(Node node)
        {
            ParentNode = node;
        }

    }
}
