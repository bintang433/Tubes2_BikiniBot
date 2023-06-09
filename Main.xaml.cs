﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Drawing.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace MazeSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int top = 0, left = 0;
        private Maze maze = new Maze();
        private bool fileSelected = false;

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            // create a new instance of the OpenFileDialog class
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // set some properties of the file dialog
            openFileDialog.Title = "Select a file";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // display the file dialog and check if the user clicked the "OK" button
            if (openFileDialog.ShowDialog() == true)
            {
                // get the selected file path
                maze.Rectangles.Clear();
                maze.Peta.Clear();
                maze.Grid.Clear();
                map.Children.Clear();
                maze.TreasureCount = 0;

                string filePath = openFileDialog.FileName;
                fileSelected = true;
                string fileName = System.IO.Path.GetFileName(filePath);
                FileName.Text = fileName;
                FileNotSelected.Text = "";
                bool fileCorrect = true;
                maze.createMap(filePath);
                int rows = maze.Height;
                int columns = maze.Width;
                double width = map.ActualWidth / columns;
                double height = map.ActualHeight / rows;
                double top = 0;
                for (int i = 0; i < rows; i++)
                {
                    maze.Rectangles.Add(new List<Rectangle>());
                    double left = 0;
                    for (int j = 0; j < columns; j++)
                    {
                        Rectangle rect = new Rectangle();
                        
                        rect.Fill = Brushes.White;
                            //maze.setGrid(i, j, false, false);
                        if (maze.Peta[i][j] == "X")
                        {
                            rect.Fill = Brushes.Black;
                        }
                        else if (maze.Peta[i][j] != "X" && maze.Peta[i][j] == "R" && maze.Peta[i][j] == "T" && maze.Peta[i][j] == "K")
                        {
                            maze.Rectangles.Clear();
                            map.Children.Clear();
                            FileNotSelected.Text = "Format file salah!";
                            FileNotSelected.Foreground = Brushes.Red;
                            break;

                        }
                        if (maze.Peta[i][j] == "K")
                        {
                            TextBox text = new TextBox();
                            text.Text = "Krusty Krab";
                            text.Foreground = Brushes.Red;
                            text.HorizontalAlignment = HorizontalAlignment.Center;
                            text.VerticalAlignment = VerticalAlignment.Center;
                            text.TextAlignment = TextAlignment.Center;
                            text.VerticalContentAlignment = VerticalAlignment.Center;
                            text.Width = width;
                            text.Height = height;
                            text.FontSize = width/11*1.5;
                            text.Background = Brushes.Transparent;
                            Panel.SetZIndex(text, 3);
                            map.Children.Add(text);
                            Canvas.SetTop(text, top);
                            Canvas.SetLeft(text, left);
                        }
                        if (maze.Peta[i][j] == "T")
                        {
                            TextBox text = new TextBox();
                            text.Text = "Treasure";
                            text.Foreground = Brushes.DarkGoldenrod;
                            text.HorizontalAlignment = HorizontalAlignment.Center;
                            text.VerticalAlignment = VerticalAlignment.Center;
                            text.TextAlignment = TextAlignment.Center;
                            text.VerticalContentAlignment = VerticalAlignment.Center;
                            text.Width = width;
                            text.Height = height;
                            text.FontSize = width/8*1.5;
                            text.Background = Brushes.Transparent;
                            Panel.SetZIndex(text, 3);
                            map.Children.Add(text);
                            Canvas.SetTop(text, top);
                            Canvas.SetLeft(text, left);
                        }
                        rect.Stroke = Brushes.Black;
                        rect.Width = width;
                        rect.Height = height;
                        Panel.SetZIndex(rect, 2);
                        map.Children.Add(rect);
                        Canvas.SetTop(rect, top);
                        Canvas.SetLeft(rect, left);
                        left += width;
                        maze.Rectangles[i].Add(rect);
                    }
                    top += height;
                    if (!fileCorrect)
                    {
                        break;
                    }
                }

                maze.connectNode();
            }
        }
        private void Visualize_Click(object sender, RoutedEventArgs e)
        {
            if (!fileSelected)
            {
                FileNotSelected.Text = "Pilih File Dahulu!";
                FileNotSelected.Foreground = Brushes.Red;
            }
            else
            {
                if (bfs.IsChecked == true)
                {
                    MethodNotSelected.Text = "";
                    maze.BFS();
                    bool TSP = tsp.IsChecked ?? false;
                    maze.visualize((int)Delay.Value, TSP);
                    Route.Text = maze.Path;
                    RunTime.Text = maze.RunTime.ToString() + " ms";
                    NodeCountText.Text = maze.nodeCount().ToString();
                    StepCountText.Text = (maze.StepCount-1).ToString();

                    
                    // do bfs
                }
                else if (dfs.IsChecked == true)
                {
                    maze.StepCount = 0;
                    maze.Steps.Clear();
                    maze.StraightSteps.Clear();
                    Stopwatch stopwatch = new Stopwatch();
                    MethodNotSelected.Text = "";
                    maze.Path = "";
                    HashSet<Node> visited = new HashSet<Node>();
                    HashSet<Node> visitedT = new HashSet<Node>();
                    stopwatch.Start();
                    maze.DFS(maze.StartNode, visited, visitedT);
                    stopwatch.Stop();
                    maze.RunTime = stopwatch.Elapsed.TotalMilliseconds;
                    bool TSP = tsp.IsChecked ?? false;
                    maze.visualize((int)Delay.Value, TSP);
                    Route.Text = maze.Path;
                    RunTime.Text = maze.RunTime.ToString() + " ms";
                    NodeCountText.Text = maze.nodeCount().ToString();
                    StepCountText.Text = (maze.StepCount - 1).ToString();
                    // do dfs
                }
                else
                {
                    MethodNotSelected.Text = "Pilih metode";
                    MethodNotSelected.Foreground= Brushes.Red;
                }
            }
        }
    }
}
