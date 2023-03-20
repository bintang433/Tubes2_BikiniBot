using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace MazeSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Maze maze = new Maze();
        private bool fileSelected = false;

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DFS(object sender, RoutedEventArgs e)
        {

        }

        private void BFS(object sender, RoutedEventArgs e)
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
                string filePath = openFileDialog.FileName;
                fileSelected = true;
                FileName.Text = filePath;
                FileNotSelected.Text = "";
                mapGrid.Children.Clear();
                maze.createMap(filePath);
                int rows = maze.Height;
                int columns = maze.Width;
                double recWidth = mapGrid.ActualWidth / maze.Width;
                double recHeight = mapGrid.ActualHeight / maze.Height;
                maze.initGrid(rows, columns);

                for (int i = 0; i < rows; i++)
                {
                    RowDefinition rowDef = new RowDefinition();
                    rowDef.Height = new GridLength(recHeight);
                    mapGrid.RowDefinitions.Add(rowDef);

                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            colDef.Width = new GridLength(recWidth);
                            mapGrid.ColumnDefinitions.Add(colDef);
                        }

                        Rectangle rect = new Rectangle();
                        if (maze.Peta[i][j] == "K")
                        {
                            rect.Fill = Brushes.Red;
                            //maze.setGrid(i, j, false, true);
                        }
                        else if (maze.Peta[i][j] == "R")
                        {
                            rect.Fill = Brushes.White;
                            //maze.setGrid(i, j, false, false);
                        }
                        else if (maze.Peta[i][j] == "T")
                        {
                            rect.Fill = Brushes.Gold;
                            //maze.setGrid(i, j, true, false);
                        }
                        else if (maze.Peta[i][j] == "X")
                        {
                            rect.Fill = Brushes.Black;
                        }
                        else
                        {   
                            mapGrid.Children.Clear();
                            throw new Exception("Invalid character / Wrong file format");
                        }
                        rect.Stroke = Brushes.Black;
                        rect.Width = recHeight;
                        rect.Height = recWidth;
                        rect.Margin = new Thickness(-1, 0, -1, 0);
                        Grid.SetRow(rect, i);
                        Grid.SetColumn(rect, j);

                        mapGrid.Children.Add(rect);
                    }
                }
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
                    FileName.Text = bfs.Name;
                    // do bfs
                }
                else if (dfs.IsChecked == true)
                {
                    MethodNotSelected.Text = "";
                    FileName.Text = dfs.Name;
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
