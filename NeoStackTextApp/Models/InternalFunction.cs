namespace NeoStackTextApp.Models;

using System.Collections.Generic;

public class InternalFunction
{
    #region Properties

    public int Degree { get; }

    public double? A { get; set; }

    public double? B { get; set; }

    public double? C { get; set; }

    public List<Arguments> CoordinatesList { get; set; }

    #endregion

    #region Constructors

    public InternalFunction(FunctionDegree degree)
    {
        CoordinatesList = new List<Arguments>();
        Degree = (int)degree;
    }

    #endregion

    #region Methods

    public bool AreCoefficientsSet()
    {
        return A.HasValue && B.HasValue && C.HasValue;
    }

    #endregion
}
