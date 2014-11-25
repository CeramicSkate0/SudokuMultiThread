using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamesGarrardThreadsProject
{
    class Program
    {
        public static bool OverallBoardStatus = false;
        public static bool[,] BoardStatus = new bool[9, 9];
        public static int[,] Board = new int [9,9]
          { {9 ,4 ,3 ,2 ,6 ,7 ,1 ,5 ,8},
            {5, 7, 6, 3, 1, 8, 2, 4, 9},
            {8, 1, 2, 4, 5, 9, 7, 6, 3},
            {7, 6, 5, 1, 8, 3, 9, 2, 4},
            {1, 3, 4, 7, 9, 2, 5, 8, 6},
            {2, 9, 8, 5, 4, 6, 3, 7, 1},
            {3, 5, 1, 6, 2, 4, 8, 9, 7},
            {6, 2, 9, 8, 7, 1, 4, 3, 5},
            {4, 8, 7, 9, 3, 5, 6, 1, 2} };
        
        public static void Main(string[] args)
        {
            Console.WriteLine("----------Start Program----------");
            //TODO put readin method and store in Board
            Console.WriteLine("----------BUILD Row Threads----------");
            Thread r1Thread = new Thread(new ThreadStart(CheckRow1));
            Thread r2Thread = new Thread(new ThreadStart(CheckRow2));
            Thread r3Thread = new Thread(new ThreadStart(CheckRow3));
            Thread r4Thread = new Thread(new ThreadStart(CheckRow4));
            Thread r5Thread = new Thread(new ThreadStart(CheckRow5));
            Thread r6Thread = new Thread(new ThreadStart(CheckRow6));
            Thread r7Thread = new Thread(new ThreadStart(CheckRow7));
            Thread r8Thread = new Thread(new ThreadStart(CheckRow8));
            Thread r9Thread = new Thread(new ThreadStart(CheckRow9));
            Console.WriteLine("----------BUILD Col Threads----------");
            Thread c1Thread = new Thread(new ThreadStart(CheckCol1));
            Thread c2Thread = new Thread(new ThreadStart(CheckCol2));
            Thread c3Thread = new Thread(new ThreadStart(CheckCol3));
            Thread c4Thread = new Thread(new ThreadStart(CheckCol4));
            Thread c5Thread = new Thread(new ThreadStart(CheckCol5));
            Thread c6Thread = new Thread(new ThreadStart(CheckCol6));
            Thread c7Thread = new Thread(new ThreadStart(CheckCol7));
            Thread c8Thread = new Thread(new ThreadStart(CheckCol8));
            Thread c9Thread = new Thread(new ThreadStart(CheckCol9));
            Console.WriteLine("----------BUILD SQR Threads----------");
            Thread CheckSqrsThread = new Thread(new ThreadStart(CheckSqrs));
            try
            {
                Console.WriteLine("----------START Row Threads----------");
                r1Thread.Start();
                r2Thread.Start();
                r3Thread.Start();
                r4Thread.Start();
                r5Thread.Start(); 
                r6Thread.Start();
                r7Thread.Start();
                r8Thread.Start();
                r9Thread.Start();
                Console.WriteLine("----------START Col Threads----------");
                c1Thread.Start();
                c2Thread.Start();
                c3Thread.Start();
                c4Thread.Start();
                c5Thread.Start();
                c6Thread.Start();
                c7Thread.Start();
                c8Thread.Start();
                c9Thread.Start();
                Console.WriteLine("----------START SQR Thread----------");
                CheckSqrsThread.Start();
                Console.WriteLine("----------WAIT Thread----------");
                Thread.Sleep(10);
                Console.WriteLine("----------ABORT row Threads----------");
                r1Thread.Abort();
                r2Thread.Abort();
                r3Thread.Abort();
                r4Thread.Abort();
                r5Thread.Abort();
                r6Thread.Abort();
                r7Thread.Abort();
                r8Thread.Abort();
                r9Thread.Abort();
                Console.WriteLine("----------ABORT Col Threads----------");
                c1Thread.Abort();
                c2Thread.Abort();
                c3Thread.Abort();
                c4Thread.Abort();
                c5Thread.Abort();
                c6Thread.Abort();
                c7Thread.Abort();
                c8Thread.Abort();
                c9Thread.Abort();
                Console.WriteLine("----------ABORT CheckSqrsThread----------");
                CheckSqrsThread.Abort();
                Console.WriteLine("----------JOIN Row Threads----------");
                r1Thread.Join();
                r2Thread.Join();
                r3Thread.Join();
                r4Thread.Join();
                r5Thread.Join();
                r6Thread.Join();
                r7Thread.Join();
                r8Thread.Join();
                r9Thread.Join();
                Console.WriteLine("----------JOIN Col Threads----------");
                c1Thread.Join();
                c2Thread.Join();
                c3Thread.Join();
                c4Thread.Join();
                c5Thread.Join();
                c6Thread.Join();
                c7Thread.Join();
                c8Thread.Join();
                c9Thread.Join();
                Console.WriteLine("----------JOIN CheckSqrsThread----------");
                CheckSqrsThread.Join();
                Console.WriteLine("\n----------Program has Finished Successfully!!!----------\n");
                FinalCheck();
                Console.WriteLine("\n\nStatus of Complete Board is: " + OverallBoardStatus);
                Console.Write("TRUE=Passed\nFALSE=Failed\n");
            }
            catch (ThreadStateException)
            {
                Console.Write("----ERROR WITH THE THREADS----");
            }
            Console.Write("\n\nPress any key to exit");
            Console.Read();
        }
        //Col Checks
        public static void CheckCol1()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 0] > 0 && Board[y, 0] < 10)
                { 
                    check += Board[y, 0];
                    BoardStatus[y, 0] = true;
                }
                else
                {
                    BoardStatus[y, 0] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 1 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 1 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol2()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 1] > 0 && Board[y, 1] < 10)
                {
                    check += Board[y, 1];
                    BoardStatus[y, 1] = true;
                }
                else
                {
                    BoardStatus[y, 1] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 2 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 2 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol3()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 2] > 0 && Board[y,2] < 10)
                {
                    check += Board[y, 2];
                    BoardStatus[y, 2] = true;
                }
                else
                {
                    BoardStatus[y, 2] = false;
                }
            }
            if (check == 45)
            {
                Console.WriteLine("Col 3 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 3 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol4()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 3] > 0 && Board[y, 3] < 10)
                {
                    check += Board[y, 3];
                    BoardStatus[y, 3] = true;
                }
                else
                {
                    BoardStatus[y, 3] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 4 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 4 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol5()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 4] > 0 && Board[y, 4] < 10)
                {
                    check += Board[y, 4];
                    BoardStatus[y, 4] = true;
                }
                else
                {
                    BoardStatus[y, 4] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 5 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 5 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol6()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 5] > 0 && Board[y, 5] < 10)
                {
                    check += Board[y, 5];
                    BoardStatus[y, 5] = true;
                }
                else
                {
                    BoardStatus[y, 5] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 6 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 6 Failed");
                BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol7()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 6] > 0 && Board[y, 6] < 10)
                {
                    check += Board[y, 6];
                    BoardStatus[y, 6] = true;
                }
                else
                {
                    BoardStatus[y, 6] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 7 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 7 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol8()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 7] > 0 && Board[y, 7] < 10)
                {
                    check += Board[y, 7];
                    BoardStatus[y, 7] = true;
                }
                else
                {
                    BoardStatus[y, 7] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 8 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 8 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckCol9()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[y, 8] > 0 && Board[y, 8] < 10)
                {
                    check += Board[y, 8];
                    BoardStatus[y, 8] = true;
                }
                else
                {
                    BoardStatus[y,8] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Col 9 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Col 9 Failed"); BoardStatus[0, 0] = false;
            }
        }
        //Rows Check
        public static void CheckRow1()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[0, y] > 0 && Board[0, y] < 10)
                {
                    check += Board[0, y];
                    BoardStatus[0, y] = true;
                }
                else
                {
                    BoardStatus[0, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 1 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 1 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow2()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[1, y] > 0 && Board[1, y] < 10)
                {
                    check += Board[ 1, y];
                    BoardStatus[1, y] = true;
                }
                else
                {
                    BoardStatus[1, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 2 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 2 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow3()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[2, y] > 0 && Board[2, y] < 10)
                {
                    check += Board[2, y];
                    BoardStatus[2, y] = true;
                }
                else
                {
                    BoardStatus[2, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 3 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 3 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow4()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[3, y] > 0 && Board[3, y] < 10)
                {
                    check += Board[3, y];
                    BoardStatus[3, y] = true;
                }
                else
                {
                    BoardStatus[3, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 4 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 4 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow5()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[4, y] > 0 && Board[4, y] < 10)
                {
                    check += Board[4, y];
                    BoardStatus[4, y] = true;
                }
                else
                {
                    BoardStatus[4, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 5 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 5 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow6()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[5, y] > 0 && Board[5, y] < 10)
                {
                    check += Board[5, y];
                    BoardStatus[5, y] = true;
                }
                else
                {
                    BoardStatus[5, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 6 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 6 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow7()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[6, y] > 0 && Board[6, y] < 10)
                {
                    check += Board[6, y];
                    BoardStatus[6, y] = true;
                }
                else
                {
                    BoardStatus[6, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 7 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 7 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow8()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[7, y] > 0 && Board[7, y] < 10)
                {
                    check += Board[7, y];
                    BoardStatus[7, y] = true;
                }
                else
                {
                    BoardStatus[7, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 8 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 8 Failed"); BoardStatus[0, 0] = false;
            }
        }
        public static void CheckRow9()
        {
            int check = 0;
            for (int y = 0; y < 9; ++y)
            {
                if (Board[8, y] > 0 && Board[8, y] < 10)
                {
                    check += Board[8, y];
                    BoardStatus[8, y] = true;
                }
                else
                {
                    BoardStatus[8, y] = false;
                }

            }
            if (check == 45)
            {
                Console.WriteLine("Row 9 Completed successfully with check of " + check);
            }
            else
            {
                Console.WriteLine("Row 9 Failed"); BoardStatus[0, 0] = false;
            }
        }
        //Check Squares
        public static void CheckSqrs()
        {
            for (int x = 0; x <= 2; ++x)
            {
                for (int y = 0; y <= 2; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }

            for (int x = 0; x <= 2; ++x)
            {
                for (int y = 3; y <= 5; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 0; x <= 2; ++x)
            {
                for (int y = 6; y <= 8; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 3; x <= 5; ++x)
            {
                for (int y = 0; y <= 2; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 3; x <= 5; ++x)
            {
                for (int y = 3; y <= 5; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 3; x <= 5; ++x)
            {
                for (int y = 6; y <= 8; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 6; x <= 8; ++x)
            {
                for (int y = 0; y <= 2; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 6; x <= 8; ++x)
            {
                for (int y = 3; y <= 5; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }
            for (int x = 6; x <= 8; ++x)
            {
                for (int y = 6; y <= 8; ++y)
                {
                    if (Board[x, y] > 0 && Board[x, y] < 10)
                    {
                        OverallBoardStatus = true;
                    }
                    else
                    {
                        OverallBoardStatus = false;
                    }
                }
            }

        }
        //Do final check on board bool matrix
        public static void FinalCheck()
        {
            for (int x = 0; x < 9; ++x)
            {
                for (int y = 0; y < 9; ++y)
                {
                    if (BoardStatus[x, y] == false)
                    {
                        OverallBoardStatus = BoardStatus[x, y];
                        break;
                    }
                    else
                    {
                        OverallBoardStatus = true;
                    }
                }
                if (OverallBoardStatus == false)
                {
                    OverallBoardStatus = false;
                    break;
                }
                else
                {
                    OverallBoardStatus = true;
                }
            }
        }
    }
}
