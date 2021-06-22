using System;

namespace Naughts_and_Crosses_YT
{
    class Program
    {
        static void Main(string[] args)
        {
            board board = new board();

            while (true)
            {
                board.render(); // draws current board

                int won = board.whoWon(); // 0 if no-one won, 1 or 2 depending on if/ who won
                if (won != 0) // means someone won
                {
                    Console.WriteLine($"Player {won} won!"); // prints who won
                }

                Console.Write($"Player {board.curPlayer}'s go (Format [x, y]): "); // To instruct players
                board.move(Console.ReadLine()); // actually play move
            }
        }
    }
}
