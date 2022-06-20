using System;
using System.Collections.Generic;
using System.Windows.Controls;

using Szeregowanie.Model;

/*
namespace Szeregowanie.View.Schema
{
    class Layer
    {
        public int Numer { get; set; }
        public int Count { get; set; }
        public int Cluster { get; set; }
        public Node[] Elements { get; set; }
    }

    class Tree
    {
        public const int HEIGHT = 30;
        public const int WIDTH = 30;

        public const int WIDTH_DIFF = 40;
        public const int HEIGHT_DIFF = 110;

        private List<Result> VisitedNodes { get; set; }

        public int Layers;
        public Layer[] Layer;

        public Tree(int variablesCount)
        {
            Layers = variablesCount;
            Layer = new Layer[Layers];
            PrepareTreeSkeleton();
        }

        public Canvas Draw()
        {
            Canvas canvas = new Canvas();
            PrepareCanvasWidth(canvas);
            for (var j = 0; j < Layers; ++j)
            {
                int LAYER_TOP = (Layers - j - 1) * Tree.HEIGHT_DIFF;

                if (j == 0)//for bottom line
                {
                    for (var k = 0; k < Layer[j].Count; ++k)
                    {
                        Node node = new Node(Tree.WIDTH, Tree.HEIGHT);
                        node.setPosition(k * Tree.WIDTH_DIFF, LAYER_TOP);
                        Layer[j].Elements[k] = node;
                        canvas.Children.Add(node);
                    }
                    continue;
                }

                if (Layer[j].Cluster % 2 == 0)//for even clusters
                {
                    for (var k = 0; k < Layer[j].Count; ++k)
                    {
                        Node node = new Node(Tree.WIDTH, Tree.HEIGHT);
                        int x = k * Layer[j].Cluster + (Layer[j].Cluster / 2);
                        Node left_neighbour = Layer[j - 1].Elements[x - 1] as Node;
                        Node neighbour_right = Layer[j - 1].Elements[x] as Node;
                        int NODE_LEFT = (int)(left_neighbour.Left() + neighbour_right.Left()) / 2;
                        node.setPosition(NODE_LEFT, LAYER_TOP);
                        Layer[j].Elements[k] = node;
                        canvas.Children.Add(node);

                        int d = k * Layer[j].Cluster;
                        for (var s = d; s < d + Layer[j].Cluster; ++s)
                            Layer[j - 1].Elements[s].setParent(node);
                    }
                    continue;
                }
                for (var k = 0; k < Layer[j].Count; ++k)
                {
                    Node node = new Node(Tree.WIDTH, Tree.HEIGHT);
                    int x = k * Layer[j].Cluster + (int)(Math.Floor((double)Layer[j].Cluster / 2));
                    Node NODE = Layer[j - 1].Elements[x] as Node;
                    int LEFT = (int)NODE.Left();
                    node.setPosition(LEFT, LAYER_TOP);
                    Layer[j].Elements[k] = node;
                    canvas.Children.Add(node);

                    int d = k * Layer[j].Cluster;
                    for (var s = d; s < d + Layer[j].Cluster; ++s)
                        Layer[j - 1].Elements[s].setParent(node);
                }
            }
            return canvas;
        }

        private void PrepareTreeSkeleton()
        {
            int elementsInCluster = Layers;
            int elementsInLayer = 1;
            for (var j = Layers - 1; j >= 0; --j)
            {
                Layer[j] = new Layer()
                {
                    Numer = j,
                    Cluster = elementsInCluster,
                    Count = elementsInLayer,
                    Elements = new Node[elementsInLayer]
                };
                elementsInLayer = elementsInLayer * elementsInCluster;
                elementsInCluster--;
            }
        }

        private void PrepareCanvasWidth(Canvas canvasForTree)
        {
            canvasForTree.Width = Layer[0].Count * Tree.WIDTH_DIFF - Tree.WIDTH_DIFF;
            canvasForTree.Height = Layers * Tree.HEIGHT_DIFF - Tree.HEIGHT_DIFF;
        }
    }
}
*/
/*
        private void PrepareNodesNames()
        {
            Stack<int> available = new Stack<int>();
            for (var e = Layers; e > 0; --e)
                available.Push(e);

            for (var j = Layers-1; j >= 0; --j)
            {
                for (var k = 0; k < Layer[j].Count; ++k)
                {
                    var node = Layer[j].Elements[k] as Node;
                    if (node.ParentNode == null) {
                        node.Available = available;
                        continue;
                    }

                    node.setName(node.ParentNode.Available.Pop());
                    node.Available = new Stack<int>(node.ParentNode.Available);
                }
            }
        }
   
        private string resolveNameFor(int layer, int index)
        {
            if (layer == Layers-1)
                return "";
            int layerFromTop = Layers - layer;
            string name = "";
            while( layerFromTop > 1)
            {
                var cluster = (int) Math.Floor((double) index / Layer[layerFromTop-2].Cluster );
                name += (cluster +1 ).ToString();
                layerFromTop--;
            }
            return name.ToString();
            
        }
*/