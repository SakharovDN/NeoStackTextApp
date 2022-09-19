namespace NeoStackTextApp.Models;

using System;
using System.Collections.Generic;

public class InternalFunction
{
    #region Properties

    public int Degree { get; }

    public double? A { get; set; }

    public double? B { get; set; }

    public double? C { get; set; }

    public List<Arguments> CoordinatesList { get; set; }

    public List<double> AvailableCoefficientsC { get; }

    #endregion

    #region Constructors

    public InternalFunction(FunctionDegree degree)
    {
        CoordinatesList = new List<Arguments>();
        Degree = (int)degree;
        AvailableCoefficientsC = new List<double>
        {
            1 * Math.Pow(10, Degree - 1),
            2 * Math.Pow(10, Degree - 1),
            3 * Math.Pow(10, Degree - 1),
            4 * Math.Pow(10, Degree - 1),
            5 * Math.Pow(10, Degree - 1)
        };
    }

    #endregion

    #region Methods

    public bool AreCoefficientsSet()
    {
        return A.HasValue && B.HasValue && C.HasValue;
    }

    #endregion
}
