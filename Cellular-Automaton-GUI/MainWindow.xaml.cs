using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cellular_Automaton;

namespace Cellular_Automaton_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CellGrid cellGrid;

        private Cell[,] cells;

        private State currentState;
        private List<State> states;

        private int numRows;
        private int numColumns;

        public MainWindow()
        {
            InitializeComponent();
            setGrid(25, 25, 75);
            states = new List<State>();

            beginNewState(cellGrid.InitState);
            
        }


        private void DrawCells()
        {
            CanvasGrid.Children.Clear();
            int rectSize = 22; 

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    Rectangle rect = new Rectangle
                    {
                        Width = rectSize,
                        Height = rectSize,
                        Stroke = Brushes.Gray 
                    };
                    if (cells[row, col].Activated)
                    {
                        rect.Fill = Brushes.Black;
                    }
                    else
                    {
                        rect.Fill = Brushes.White;
                    }
                    
                    Canvas.SetLeft(rect, col * rectSize);
                    Canvas.SetTop(rect, row * rectSize);
                    CanvasGrid.Children.Add(rect);
                }
            }
        }

        private void beginNewState(State newState)
        {
            
            currentState = newState;
            cells = newState.Cells;
            states.Add(newState);

            numRows = cells.GetLength(0);
            numColumns = cells.GetLength(1);

            DrawCells();
        }

        private void reset()
        {
            states = new List<State>();
            beginNewState(cellGrid.InitState);
        }

        private void setGrid(int gridHeight, int gridWidth, int initActivations)
        {
            cellGrid = new CellGrid(gridHeight, gridWidth, initActivations);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            State nextState = cellGrid.generateNextState(currentState);

            beginNewState(nextState);

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0;  i < 100; i++)
            {
                Button_Click_1(sender, e);
                await Task.Delay(240);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            setGrid(int.Parse(newHeight.Text), int.Parse(newWidth.Text), int.Parse(newActivations.Text));

            reset();


        }
    }
}
