// See https://aka.ms/new-console-template for more information


using Cellular_Automaton;

CellGrid cellGrid = new CellGrid();

List<State> states = cellGrid.generate();

printToConsole();



 void printToConsole()
{
    foreach (State state in states)
    {
        Cell[,] cells = state.Cells;

        Console.WriteLine();
        int i = 0;
        foreach (Cell cell in cells)
        {
            string binary;
            if (cell == null)
            {
                binary = "0";
            }
            else
            {
                binary = cell.ToString();
            }

            Console.Write($"| {binary} |");
            i++;
            if (i == 10)
            {
                Console.WriteLine();
                i = 0;
            }
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}



