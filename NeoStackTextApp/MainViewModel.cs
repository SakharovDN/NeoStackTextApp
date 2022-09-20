namespace NeoStackTextApp;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Models;

using Services;

/// <summary>
/// Main view model
/// </summary>
public class MainViewModel : INotifyPropertyChanged
{
    #region Constants

    private const int MIN_DEGREE = 1;
    private const int MAX_DEGREE = 5;

    #endregion

    #region Fields

    private readonly CalculationService _calculationService;

    private InternalFunction _selectedFunction;

    #endregion

    #region Properties

    /// <summary>
    /// Selected function in function ListView
    /// </summary>
    public InternalFunction SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Collection of functions
    /// </summary>
    public ObservableCollection<InternalFunction> Functions { get; }
    
    #endregion

    #region Events

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Constructors

    public MainViewModel()
    {
        _calculationService = new CalculationService();
        Functions = new ObservableCollection<InternalFunction>();

        for (int i = MIN_DEGREE; i <= MAX_DEGREE; i++)
        {
            var function = new InternalFunction(i);
            function.PropertyChanged += OnFunctionPropertyChanged;
            Functions.Add(function);
        }

        _selectedFunction = Functions.First();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Triggered on property changed
    /// </summary>
    /// <param name="propertyName">Name of changed property</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Triggered on function property changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFunctionPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not InternalFunction function)
        {
            return;
        }

        if (e.PropertyName == nameof(Arguments.Result))
        {
            return;
        }

        _calculationService.Calculate(function);
        OnPropertyChanged(e.PropertyName);
    }

    #endregion
}
