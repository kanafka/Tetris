namespace Tetris;

public class BoardPoint
{
    public bool IsBrick { get; set; }

    public BoardPoint(bool isBrick)
    {
        IsBrick = isBrick;
    }
    public override string ToString()
    {
        return IsBrick ? "[#]":"[ ]";
    }
}