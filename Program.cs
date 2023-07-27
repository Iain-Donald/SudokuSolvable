Console.WriteLine("Hello, World!");

bool solvableSudoku(char[][] board) {
    int x = 1;
    int y = 1;

    Dictionary<int, int> rowAvail = new Dictionary<int, int>();
    Dictionary<int, int> colAvail = new Dictionary<int, int>();
    Dictionary<int, int> boxAvail = new Dictionary<int, int>();
    Dictionary<int, int> numbers = new Dictionary<int, int>();


    for(int i = 1; i <= 9; i++){
        rowAvail.Add(i, 1);
        colAvail.Add(i, 1);
        boxAvail.Add(i, 1);
        numbers.Add(i, 1);
    }

    
    int yIncrement;
    int boxXStart;
    int boxYStart;
    while((x * y < 81)){
        

        for(int i = 1; i < 10; i++){
            rowAvail[i] = 0;
            colAvail[i] = 0;
            boxAvail[i] = 0;
            numbers[i] = 1;
        }


        if(x >= 7) boxXStart = 7;
        else if(x >= 4) boxXStart = 4;
        else boxXStart = 1;

        if(y >= 7) boxYStart = 7;
        else if(y >= 4) boxYStart = 4;
        else boxYStart = 1;


        for(int i = 1; i <= 9; i++){
        
            if(board[(y - 1)][(i - 1)] != '.' && i - 1 != x - 1) rowAvail[(int)Char.GetNumericValue(board[(y - 1)][(i - 1)])]++;

            if(board[(i - 1)][(x - 1)] != '.' && i - 1 != y - 1) colAvail[(int)Char.GetNumericValue(board[(i - 1)][(x - 1)])]++;

            if(i >= 7) yIncrement = 2;
            else if(i >= 4) yIncrement = 1;
            else yIncrement = 0;
        
            if(board[boxYStart + yIncrement - 1][boxXStart + (i % 3) - 1] != '.' && boxYStart + yIncrement - 1 != x - 1 && boxXStart + (i % 3) - 1 != y - 1) boxAvail[(int)Char.GetNumericValue(board[boxYStart + yIncrement - 1][boxXStart + (i % 3) - 1])]++;
        }
    

        foreach(var item in rowAvail.Keys) {
            if(rowAvail[item] == 1) numbers[item] = 0;
            else if(rowAvail[item] > 1) return false;
        }
        foreach(var item in colAvail.Keys){
            if(colAvail[item] == 1) numbers[item] = 0;
            else if(colAvail[item] > 1) return false;
        }
        foreach(var item in boxAvail.Keys){
            if(boxAvail[item] == 1) numbers[item] = 0;
            else if(boxAvail[item] > 1) return false;
        }


        bool tempValid = false;
        foreach(var item in numbers.Keys) {
            if(numbers[item] == 1) {
                tempValid = true;
                break;
            }
        }
        

        if(tempValid == false) return tempValid;


        x ++;
        if(x == 10){
            y ++;
            x = 1;
        }
    }
    return true;
}



// test it
char[][] board1 = new char[8][];
char[] row0 = new[] {'5', '3', '.',/**/ '.', '7', '.',/**/ '.', '.', '.'}; /////
char[] row1 = new[] {'6', '.', '.',/**/ '1', '9', '5',/**/ '.', '.', '.'}; /////
char[] row2 = new[] {'.', '9', '8',/**/ '.', '.', '.',/**/ '.', '6', '.'}; /////
char[] row3 = new[] {'8', '.', '.',/**/ '.', '6', '.',/**/ '.', '.', '3'};      /////
char[] row4 = new[] {'4', '.', '.',/**/ '8', '.', '3',/**/ '.', '.', '1'};      /////
char[] row5 = new[] {'7', '.', '.',/**/ '.', '2', '.',/**/ '.', '.', '6'};      /////
char[] row6 = new[] {'.', '6', '.',/**/ '.', '.', '.',/**/ '2', '8', '.'}; /////
char[] row7 = new[] {'.', '.', '.',/**/ '4', '1', '9',/**/ '.', '.', '5'}; /////
char[] row8 = new[] {'.', '.', '.',/**/ '.', '8', '.',/**/ '.', '7', '9'}; /////

board1 = new[] { row0, row1, row2, row3, row4, row5, row6, row7, row8 };

char[][] board2 = new char[8][];
char[] row01 = new[] {'8','3','.','.','7','.','.','.','.'}; /////
char[] row11 = new[] {'6','.','.','1','9','5','.','.','.'}; /////
char[] row21 = new[] {'.','9','8','.','.','.','.','6','.'}; /////
char[] row31 = new[] {'8','.','.','.','6','.','.','.','3'};      /////
char[] row41 = new[] {'4','.','.','8','.','3','.','.','1'};      /////
char[] row51 = new[] {'7','.','.','.','2','.','.','.','6'};      /////
char[] row61 = new[] {'.','6','.','.','.','.','2','8','.'}; /////
char[] row71 = new[] {'.','.','.','4','1','9','.','.','5'}; /////
char[] row81 = new[] {'.','.','.','.','8','.','.','7','9'}; /////

board2 = new[] { row01, row11, row21, row31, row41, row51, row61, row71, row81 };

char[][] board3 = new char[8][];
char[] row02 = new[] {'.','8','7','6','5','4','3','2','1'}; /////
char[] row12 = new[] {'2','.','.','.','.','.','.','.','.'}; /////
char[] row22 = new[] {'3','.','.','.','.','.','.','.','.'}; /////
char[] row32 = new[] {'4','.','.','.','.','.','.','.','.'};      /////
char[] row42 = new[] {'5','.','.','.','.','.','.','.','.'};      /////
char[] row52 = new[] {'6','.','.','.','.','.','.','.','.'};      /////
char[] row62 = new[] {'7','.','.','.','.','.','.','.','.'}; /////
char[] row72 = new[] {'8','.','.','.','.','.','.','.','.'}; /////
char[] row82 = new[] {'9','.','.','.','.','.','.','.','.'}; /////

board3 = new[] { row02, row12, row22, row32, row42, row52, row62, row72, row82 };

char[][] board4 = new char[8][];
char[] row04 = new[] {'.','.','.','.','.','.','.','.','.'}; /////
char[] row14 = new[] {'3','.','.','.','4','5','6','.','.'}; /////
char[] row24 = new[] {'.','.','5','.','2','.','.','.','.'}; /////
char[] row34 = new[] {'.','.','.','.','.','.','.','.','.'};      /////
char[] row44 = new[] {'.','3','.','.','.','.','.','.','1'};      /////
char[] row54 = new[] {'.','.','.','.','.','.','.','.','.'};      /////
char[] row64 = new[] {'.','.','.','.','.','.','6','.','.'}; /////
char[] row74 = new[] {'.','.','.','.','.','5','.','6','.'}; /////
char[] row84 = new[] {'.','.','.','9','.','.','.','.','.'}; /////

board4 = new[] { row04, row14, row24, row34, row44, row54, row64, row74, row84 };

Console.WriteLine(solvableSudoku(board1));
Console.WriteLine(solvableSudoku(board2));
Console.WriteLine(solvableSudoku(board3));
Console.WriteLine(solvableSudoku(board4));