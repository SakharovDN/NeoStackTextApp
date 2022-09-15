namespace NeoStackTextApp.Models;

public class Arguments
{
    #region Fields

    private static uint _id;

    #endregion

    #region Properties

    public uint Id { get; }

    public double? X { get; set; }

    public double? Y { get; set; }

    public double? Result { get; set; }

    #endregion

    #region Constructors

    public Arguments(double x, double y)
    {
        Id = _id++;
        X = x;
        Y = y;
    }

    static Arguments()
    {
        _id = 0;
    }

    #endregion
}
