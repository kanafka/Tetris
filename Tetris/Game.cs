using Tetris.AllTetrominos;
using System.Threading;

namespace Tetris;

public class Game
{
    private static Point TetrominoCoords = new Point(3, 0);

    private static Tetromino[] AllTetromino =
        { new FigureZ(), new FigureI(), new FigureJ(), new FigureL(), new FigureO(), new FigureS(), new FigureT() };

    private static bool GameContinue = Board.GetMaxY() > 0;
    private static int speed = 200;
    private static Tetromino figure = RandomFigure();

    private static void ShowBoard(Tetromino figure)
    {
        BoardPoint[][] board = Board.GetCopyBoard();
        Point[] FigurePoints = figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords);
        foreach (var point in FigurePoints)
        {
            board[point.Y][point.X] = new BoardPoint(true);
        }

        Console.Clear();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                Console.Write(board[i][j].ToString());
            }

            Console.WriteLine();
        }
    }

    private static void TetrominoAnimationTest<T>(T Figure) where T : Tetromino
    {
        for (int i = 0; i < 4; i++)
        {
            BoardPoint[][] board = Board.GetCopyBoard();
            Point[] FigurePoints = Figure.ShowFigure(i, TetrominoCoords);
            foreach (var point in FigurePoints)
            {
                board[point.Y][point.X] = new BoardPoint(true);
            }

            Thread.Sleep(2000);
        }
    }

    private static Tetromino RandomFigure()
    {
        Random rnd = new Random();
        int randomIndex = rnd.Next(0, AllTetromino.Length);
        return AllTetromino[randomIndex];
    }

    static void Down()
    {
        while (GameContinue)
        {
            figure = RandomFigure();
            TetrominoCondition.ZeroCondition();
            while (Board.CheckForFreeCoords(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords)))
            {
                TetrominoCoords.Y++;
                ShowBoard(figure);
                Thread.Sleep(speed);
            }
            //Thread.Sleep(200);
            Board.AddTetrominoOnBoard(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords));
            Board.CheckLines();
            TetrominoCoords = new Point(3, 0);
        }
    }

    public static void StartGame()
    {
        Thread inputThread = new Thread(Down);
        inputThread.Start();
        Board.InitializationBoard();
        while (GameContinue)
        {
            figure = RandomFigure();
            TetrominoCondition.ZeroCondition();
            while (Board.CheckForFreeCoords(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords)))
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Board.CheckLeftCoords(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords)))
                    {
                        TetrominoCoords.X--;
                        ShowBoard(figure);
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Board.CheckRightCoords(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords)))
                    {
                        TetrominoCoords.X++;
                        ShowBoard(figure);
                    }
                }

                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Board.CheckNextCondition(figure.ShowFigure(TetrominoCondition.GetNextCondition(),
                            TetrominoCoords)))
                    {
                        TetrominoCondition.NextCondition();
                        ShowBoard(figure);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    TetrominoCoords.Y++;
                    ShowBoard(figure);
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    while (Board.CheckForFreeCoords(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords)))
                    {
                        TetrominoCoords.Y++;
                    }
                    ShowBoard(figure);
                    break;
                }
            }
            Board.AddTetrominoOnBoard(figure.ShowFigure(TetrominoCondition.GetCondition(), TetrominoCoords));
            Board.CheckLines();
            TetrominoCoords = new Point(3, 0);
        }
    }
}