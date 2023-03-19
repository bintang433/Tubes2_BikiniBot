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
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
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
                FileName.Text = filePath;
                Maze mainMaze = new Maze();
                mainMaze.createMap(filePath);
                int rows = mainMaze.Length;
                int columns = mainMaze.Width;
                int recLen = 400 / mainMaze.Length;
                int recWid = 400 / mainMaze.Width;
                mainMaze.initGrid(rows, columns);

                for (int i = 0; i < rows; i++)
                {
                    RowDefinition rowDef = new RowDefinition();
                    mapGrid.RowDefinitions.Add(rowDef);

                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0)
                        {
                            ColumnDefinition colDef = new ColumnDefinition();
                            mapGrid.ColumnDefinitions.Add(colDef);
                        }

                        Rectangle rect = new Rectangle();
                        if (mainMaze.Peta[i][j] == "K")
                        {
                            rect.Fill = Brushes.Red;
                            //mainMaze.setGrid(i, j, false, true);
                        }
                        else if (mainMaze.Peta[i][j] == "R")
                        {
                            rect.Fill = Brushes.White;
                            //mainMaze.setGrid(i, j, false, false);
                        }
                        else if (mainMaze.Peta[i][j] == "T")
                        {
                            rect.Fill = Brushes.Gold;
                            //mainMaze.setGrid(i, j, true, false);
                        }
                        else if (mainMaze.Peta[i][j] == "X")
                        {
                            rect.Fill = Brushes.Black;
                        }
                        else
                        {
                            rect.Fill = Brushes.Green;
                        }
                        rect.Stroke = Brushes.Black;
                        rect.Width = recWid;
                        rect.Height = recLen;
                        Grid.SetRow(rect, i);
                        Grid.SetColumn(rect, j);

                        mapGrid.Children.Add(rect);
                    }
                }
            }
        }      
    }
}
