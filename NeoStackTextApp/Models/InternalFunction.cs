namespace NeoStackTextApp.Models;

using System.Collections.Generic;

public class InternalFunction
{
    #region Properties

    public int Degree { get; }

    public double A { get; set; }

    public double B { get; set; }

    public double C { get; set; }

    public List<Coordinates> CoordinatesList { get; set; }

    #endregion

    #region Constructors

    public InternalFunction(FunctionDegree degree)
    {
        CoordinatesList = new List<Coordinates>();
        Degree = (int)degree;
    }

    #endregion
}
