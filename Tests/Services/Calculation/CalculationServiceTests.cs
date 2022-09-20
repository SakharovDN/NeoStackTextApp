namespace Tests.Services.Calculation;

using NeoStackTextApp.Models;
using NeoStackTextApp.Services;

using NUnit.Framework;

internal class CalculationServiceTests
{
    #region Constants

    private const int FUNCTION_DEGREE_2 = 2;

    #endregion

    #region Methods

    [Test]
    public void CalculateFunction_WhenAllArgumentsAreSet()
    {
        // Arrange
        var builder = new CalculationServiceBuilder();
        CalculationService calculationService = builder.Build();
        var function = new InternalFunction(FUNCTION_DEGREE_2)
        {
            CoefficientA = 5,
            CoefficientB = 5,
            CoefficientC = 5
        };
        function.ArgumentsList.Add(
            new Arguments
            {
                X = 2,
                Y = 3
            });

        // Act
        calculationService.Calculate(function);

        // Assert
        Assert.That(function.ArgumentsList[0].Result, Is.EqualTo(40));
    }

    [Test]
    public void CalculateFunction_WhenArgumentsAreNotSet()
    {
        // Arrange
        var builder = new CalculationServiceBuilder();
        CalculationService calculationService = builder.Build();
        var function = new InternalFunction(FUNCTION_DEGREE_2)
        {
            CoefficientC = 5
        };
        function.ArgumentsList.Add(
            new Arguments
            {
                X = 2,
                Y = 3
            });

        // Act
        calculationService.Calculate(function);

        // Assert
        Assert.That(function.ArgumentsList[0].Result, Is.EqualTo(null));
    }

    #endregion
}
