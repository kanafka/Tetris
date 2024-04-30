namespace Tetris;

public static class Board
{
    private static BoardPoint[][] GameBoard = new BoardPoint[20][];
    private static BoardPoint _boardPoint = new BoardPoint(true);

    public static void InitializationBoard()
    {
        for (int i = 0; i < GameBoard.Length; i++)
        {
            GameBoard[i] = new BoardPoint[10];
            for (int j = 0; j < GameBoard[i].Length; j++)
            {
                GameBoard[i][j] = new BoardPoint(false);
            }
        }
    }

    public static void AddTetrominoOnBoard(Point[] points)
    {
        foreach (var point in points)
        {
            GameBoard[point.Y][point.X] = _boardPoint;
        }
    }

    public static bool CheckNextCondition(Point[] points)
    {
        foreach (var point in points)
        {
            if (point.X <= -1 || point.X >= GameBoard[0].Length|| GameBoard[point.Y][point.X] == _boardPoint)
            {
                return false;
            }
        }

        return true;
    }
    public static bool CheckRightCoords(Point[] points)
    {
        foreach (var point in points)
        {
            if (point.X == GameBoard[0].Length - 1|| GameBoard[point.Y][point.X + 1] == _boardPoint)
            {
                return false;
            }
        }

        return true;
    }
    public static bool CheckLeftCoords(Point[] points)
    {
        foreach (var point in points)
        {
            if (point.X == 0 || GameBoard[point.Y][point.X - 1] == _boardPoint)
            {
                return false;
            }
        }

        return true;
    }
    public static bool CheckForFreeCoords(Point[] points)
    {
        foreach (var point in points)
        {
            if (point.Y == GameBoard.Length - 1 || GameBoard[point.Y + 1][point.X] == _boardPoint)
            {
                return false;
            }
        }

        return true;
    }
    
    public static void CheckLines()
    {
        for (int i = 0; i < GameBoard.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < GameBoard[i].Length; j++)
            {
                if (GameBoard[i][j] == _boardPoint)
                {
                    count++;
                }
            }

            if (count == GameBoard[i].Length)
            {
                for (int j = i; j > 0; j--)
                {
                    for (int k = 0; k < GameBoard[j].Length; k++)
                    {
                        GameBoard[j][k] = GameBoard[j - 1][k];
                    }
                }
            }
        }
    }

    public static int GetMaxY()
    {
        for (int i = 0; i < GameBoard.Length; i++)
        {
            if (GameBoard[i].Contains(_boardPoint))
            {
                return i;
            }
        }

        return GameBoard.Length;
    }
    
    public static BoardPoint[][] GetCopyBoard()
    {
        BoardPoint[][] copiedArray = new BoardPoint[GameBoard.Length][];
        for (int i = 0; i < copiedArray.Length; i++)
        {
            copiedArray[i] = new BoardPoint[10];
            for (int j = 0; j < copiedArray[i].Length; j++)
            {
                copiedArray[i][j] = new BoardPoint(false);
            }
        }

        for (int i = 0; i < GameBoard.Length; i++)
        {
            for (int j = 0; j < GameBoard[i].Length; j++)
            {
                copiedArray[i][j] = GameBoard[i][j];
            }
        }

        return copiedArray;
    }
}