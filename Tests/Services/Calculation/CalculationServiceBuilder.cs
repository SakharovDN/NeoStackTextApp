namespace Tests.Services.Calculation;

using NeoStackTextApp.Services;

/// <summary>
/// Calculation service builder
/// </summary>
internal class CalculationServiceBuilder
{
    #region Fields

    private readonly Lazy<CalculationService> _lazyCalculationServiceInitializer;

    #endregion

    #region Constructors

    public CalculationServiceBuilder()
    {
        _lazyCalculationServiceInitializer = new Lazy<CalculationService>(() => new CalculationService());
    }

    #endregion

    #region Methods

    /// <summary>
    /// Build calculation service
    /// </summary>
    /// <returns><see cref="CalculationService"/> value</returns>
    public CalculationService Build()
    {
        return _lazyCalculationServiceInitializer.Value;
    }

    #endregion
}
