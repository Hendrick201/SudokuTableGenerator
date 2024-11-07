int?[,] matrix = new int?[9, 9];
int sudokuWidth = 9;
Random random = new Random();
Main();

void Main()
{
    Console.WriteLine("** S U D O K U **");
    GenerateTableLine();   // << Call the Main method to generate a valid Sudoku table
}

void GenerateTableLine()
{
    ///////////// Run all the matrix and generate the numbers///////////// 
    for (int i = 0; i < sudokuWidth; i++)
    {
        for (int j = 0; j < sudokuWidth; j++)
        {
            List<int> numbersAble = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (!GenerateNumber(i, j, numbersAble))
            {
                i = 0;
                j = -1;
                matrix = new int?[9, 9];
            }
        }
    }
    ///////////////////

    //////// Show the table on Console/////
    for (int i = 0; i < sudokuWidth; i++)
    {
        for (int j = 0; j < sudokuWidth; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    /////////////////// 
}

bool GenerateNumber(int i, int j, List<int> numbersAble)
{
    //// Remove the number if they are present on the rolls or colums // 
    for (int k = 0; k < sudokuWidth; k++)
    {
        if (matrix[i, k].HasValue)
            numbersAble.Remove(matrix[i, k]!.Value);
        if (matrix[k, j].HasValue)
            numbersAble.Remove(matrix[k, j]!.Value);
    }
    ///////////////////

    /////////// Calculate the block 3x3 and remove the current preset numbers on the block //////////////
    int blockRow = (i / 3) * 3;
    int blockCol = (j / 3) * 3;
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (matrix[blockRow + row, blockCol + col].HasValue)
                numbersAble.Remove(matrix[blockRow + row, blockCol + col]!.Value);  /// << !.value 
        }
    }
    ///////////////////

    //// Return false if dont have numbersAble///
    if (numbersAble.Count == 0)
        return false;
    ///////////////////

    //// Random a number ////
    int index = random.Next(0, numbersAble.Count);
    matrix[i, j] = numbersAble[index];
    return true;
    ///////////////////
}

 



