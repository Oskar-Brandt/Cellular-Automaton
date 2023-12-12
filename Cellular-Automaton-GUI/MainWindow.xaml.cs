using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<State> stateList;
        private State[] states;
        private State currentState;

        private int currentStateIndex;
        private int numRows;
        private int numColumns;

        public MainWindow()
        {
            InitializeComponent();
            cellGrid = new CellGrid();
            stateList = cellGrid.generate();
            
            states = stateList.ToArray();
            State currentState = states[0];
            currentStateIndex = 0;
            cells = currentState.Cells;

            numRows = cells.GetLength(0);
            numColumns = cells.GetLength(1);

            DrawCells();
        }


        private void DrawCells()
        {
            int rectSize = 25; 

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
                    if (cells[row,col] is null || !cells[row, col].Activated)
                    {
                        rect.Fill = Brushes.White;
                    }
                    else
                    {
                        rect.Fill = Brushes.Black;
                    }

                    Canvas.SetLeft(rect, col * rectSize);
                    Canvas.SetTop(rect, row * rectSize);
                    CanvasGrid.Children.Add(rect);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentStateIndex == stateList.Count - 1)
            {
                //If final state has been drawn, button does nothing
            }
            else
            {
                currentStateIndex++;
                currentState = states[currentStateIndex];
                cells = currentState.Cells;
                DrawCells();
            }
            
        }
    }
}
