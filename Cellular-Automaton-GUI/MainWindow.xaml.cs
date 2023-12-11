﻿using System;
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
using Cellular_Automaton;

namespace Cellular_Automaton_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cell[,] cells;
        private int numRows;
        private int numColumns;

        private CellGrid cellGrid;
        private GridRow[] rows;
        public MainWindow()
        {
            InitializeComponent();
            cellGrid = new CellGrid();
            
            cells = cellGrid.Cells;
            numRows = cells.GetLength(0);
            numColumns = cells.GetLength(1);

            rows = new GridRow[numRows];

            addColumns();
            addRows();
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            List<State> states = cellGrid.generate();
            
        }


        private void addColumns()
        {
            for (int i = 0; i < numColumns; i++)
            {
                var column = new DataGridCheckBoxColumn
                {
                    Header = $"Column {i + 1}",
                    Binding = new Binding($"Column{i}")
                };
                DG1.Columns.Add(column);
            }
        }

        private void addRows()
        {
            for(int i = 0; i < numRows; i++)
            {
                GridRow row = new GridRow(i, cells);
                rows[i] = row;
            }
            DG1.ItemsSource = rows;
        }
    }
}
