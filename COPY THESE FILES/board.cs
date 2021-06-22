using System;

namespace Naughts_and_Crosses_YT
{
    class board
    {
        public int curPlayer = 1; // pretty self - explanitory

        int[,] boardArray = { 
            { 0, 0, 0 }, 
            { 0, 0, 0 }, 
            { 0, 0, 0 } 
        }; // can be set as a constant, as the array is always 3x3

        public void move(string move)
        {
            // move = '[x], [y]' 
            string[] moveArray = move.Split(','); // so array is: { '[x]', '[y]' }

            int x = int.Parse(moveArray[0])-1; // minus 1 as arrays are 0 indexed (as in the first item is also item[0]), but inputs are 1 indexed
            int y = int.Parse(moveArray[1])-1;

            if (boardArray[y, x] == 0) // if the selected piece has not already been played, then play it
                boardArray[y, x] = curPlayer;
                nextPlayer();
        }

        public void nextPlayer() // changes who is playing
        {
            if (curPlayer == 1)
                curPlayer = 2;
            else
                curPlayer = 1;
        }

        public int whoWon()
        {
            int[,] dirs = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } }; // { Y change, X change }

            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                    // loops through each cell
                    if (boardArray[y, x] != 0) 
                        // if this cell has actually been played. Stops computer checking if
                        // the cell is blank, as no-one can win with 3 blanks in a row
                        for (int i = 0; i < 8; i++) // loops through each possible direction
                            for (int j = 0; j < 3; j++) // As you need 3 in a row
                                try // to prevent program crashing in case of index out of bound errors
                                {
                                    if (boardArray[y + (dirs[i, 0] * j), x + (dirs[i, 1] * j)] != boardArray[y, x]) // means you don't have 3 in a row
                                        break;
                                    else
                                        if (j == 2)
                                            return boardArray[y, x]; // means there are 3 in a row, so someone won
                                } 
                                catch
                                {

                                }
            return 0; // no-one won
        }

        public void render()
        {
            Console.Clear(); // clears what was last on the screen
            Console.WriteLine(" | 1  2  3\n-+------"); // bar along the side, to help players choose moves only
            for (int y = 0; y < 3; y++)
            {
                Console.Write($"{y + 1}|"); // bar along the side, to help players choose moves only
                for (int x = 0; x < 3; x++)
                {
                    Console.Write($" {boardArray[y, x]} ");
                }
                Console.WriteLine(); // newline
            }
        }
    }
}
