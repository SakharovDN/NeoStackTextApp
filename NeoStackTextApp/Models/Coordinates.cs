namespace NeoStackTextApp.Models;

public class Coordinates
{
    #region Properties

    public double X { get; set; }

    public double Y { get; set; }

    #endregion

    #region Constructors

    public Coordinates(double x, double y)
    {
        X = x;
        Y = y;
    }

    #endregion
}
