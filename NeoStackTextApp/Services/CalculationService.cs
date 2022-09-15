namespace NeoStackTextApp.Services;

using System;

using Models;

public class CalculationService
{
    #region Methods

    public void Calculate(InternalFunction function)
    {
        if (!function.AreCoefficientsSet())
        {
            return;
        }

        foreach (Arguments arguments in function.CoordinatesList)
        {
            if (arguments.X.HasValue && arguments.Y.HasValue)
            {
                arguments.Result = function.A * Math.Pow(arguments.X.Value, function.Degree) +
                                   function.B * Math.Pow(arguments.Y.Value, function.Degree - 1) +
                                   function.C;
            }
            else
            {
                arguments.Result = null;
            }
        }
    }

    #endregion
}
