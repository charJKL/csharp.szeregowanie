
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Szeregowanie.Model;
using Szeregowanie.Utility.Factories;
namespace Szeregowanie.View.Chart
{
    class ChartBuilder
    {
        public static int OX_SCALE = 40;
        public static int OY_SCALE = 40;

        List<TaskWrapper> Tasks { get; set; }

        public ChartBuilder(List<TaskWrapper> tasksList)
        {
            Tasks = tasksList;
        }

        public Canvas Draw(int[] solution)
        {
            // Set up canvas
            Canvas Canvas = new Canvas();
            Canvas.Margin = new Thickness(80, 20, 30, 10);
            
            TaskWrapper task;
            Block block;
            int line;
            int start;
            int width;
            int height;
            int[] machines = new int[2] { 0, 0 };
            
            for (int j=0; j < solution.Length; ++j)
            {
                task = Tasks.Where(x => x.Number == solution[j]).Single();
                for (int k=0; k < machines.Length; ++k)
                {
                    block = new Block(task.Number);
                    block.SetBackground(task.Color);
                    if ( k == 0)
                    {
                        start = machines[k];
                        machines[k] += task.Time[k];
                    }
                    else
                    {
                        start = Math.Max(machines[k - 1], machines[k]);
                        machines[k] = start + task.Time[k];
                    }
                    start = start * ChartBuilder.OX_SCALE;
                    line = k * ChartBuilder.OY_SCALE;
                    width = task.Time[k] * ChartBuilder.OX_SCALE;
                    height = ChartBuilder.OY_SCALE;
                    block.SetPosition(line, start, width, height);
                    Canvas.Children.Add(block);
                }
            }

            Canvas.Height = machines.Length * ChartBuilder.OY_SCALE;
            Canvas.Width = machines.Max() * ChartBuilder.OX_SCALE;
            DrawAxis(Canvas);
            DrawLabels(Canvas,2);
            return Canvas;
        }

        private void DrawAxis(Canvas canvas)
        {
            Line ox = new Line();
            ox.X1 = 0;
            ox.Y1 = canvas.Height;
            ox.X2 = canvas.Width + 10;
            ox.Y2 = canvas.Height;

            ox.StrokeThickness = 1;
            ox.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            ox.StrokeEndLineCap = PenLineCap.Triangle;
            canvas.Children.Add(ox);

            Line oy = new Line();
            oy.X1 = 0;
            oy.Y1 = canvas.Height;
            oy.X2 = 0;
            oy.Y2 = -10;
            oy.StrokeThickness = 1;
            oy.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            oy.StrokeEndLineCap = PenLineCap.Triangle;
            canvas.Children.Add(oy);
        }

        private void DrawLabels(Canvas canvas, int machines)
        {
            Label label;
            for (int j = 0; j < machines; ++j)
            {
                label = new Label(j + 1, ChartBuilder.OY_SCALE);
                Canvas.SetLeft(label, 0);
                Canvas.SetTop(label, j * ChartBuilder.OY_SCALE);
                canvas.Children.Add(label);
            }

            Scale scale;
            for (int j = 0; j * ChartBuilder.OX_SCALE <= canvas.Width; ++j)
            {
                scale = new Scale(j,ChartBuilder.OX_SCALE,ChartBuilder.OY_SCALE);
                Canvas.SetLeft(scale, j * ChartBuilder.OX_SCALE);
                Canvas.SetTop(scale, canvas.Height);
                canvas.Children.Add(scale);
            }
        }
    }
}
