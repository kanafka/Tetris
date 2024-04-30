namespace Tetris;

public static class TetrominoCondition
{
    private static int _condition = 0;

    public static int GetCondition()
    {
        int condition = _condition;
        return condition;
    }

    public static void NextCondition()
    {
        if (_condition == 3)
        {
            _condition = 0;
        }
        else
        {
            _condition++;
        }
    }
    public static int GetNextCondition()
    {
        if (_condition == 3)
        {
            return 0;
        }
        else
        {
            return _condition + 1;
        }
    }

    public static void ZeroCondition()
    {
        _condition = 0;
    }
}