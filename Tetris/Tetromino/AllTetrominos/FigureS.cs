namespace Tetris.AllTetrominos;

public class FigureS : Tetromino
{
    public override Point[] ShowFigure(int counter, Point point)
    {
        switch (counter)
        {
            case 0:
                return new[]
                {
                    new Point(1 + point.X, 0 + point.Y), new Point(2 + point.X, 0 + point.Y),
                    new Point(0 + point.X, 1 + point.Y), new Point(1 + point.X, 1 + point.Y)
                };
            case 1:
                return new[]
                {
                    new Point(1 + point.X, 0 + point.Y), new Point(1 + point.X, 1 + point.Y),
                    new Point(2 + point.X, 1 + point.Y), new Point(2 + point.X, 2 + point.Y)
                };
            case 2:
                return new[]
                {
                    new Point(1 + point.X, 0 + point.Y), new Point(2 + point.X, 0 + point.Y),
                    new Point(0 + point.X, 1 + point.Y), new Point(1 + point.X, 1 + point.Y)
                };
            case 3:
                return new[]
                {
                    new Point(1 + point.X, 0 + point.Y), new Point(1 + point.X, 1 + point.Y),
                    new Point(2 + point.X, 1 + point.Y), new Point(2 + point.X, 2 + point.Y)
                };
            default:
                throw new ArgumentException();
        }
    }
}