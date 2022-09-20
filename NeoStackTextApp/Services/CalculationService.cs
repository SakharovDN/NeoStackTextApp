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

        foreach (Arguments arguments in function.ArgumentsList)
        {
            if (arguments.X.HasValue && arguments.Y.HasValue)
            {
                arguments.Result = function.CoefficientA * Math.Pow(arguments.X.Value, function.Degree) +
                                   function.CoefficientB * Math.Pow(arguments.Y.Value, function.Degree - 1) +
                                   function.CoefficientC;
            }
            else
            {
                arguments.Result = null;
            }
        }
    }

    #endregion
}
