namespace NeoStackTextApp;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Models;

using Services;

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

    public InternalFunction SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged();
        }
    }

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
            function.PropertyChanged += OnArgumentChanged;
            Functions.Add(function);
        }

        _selectedFunction = Functions.First();
    }

    #endregion

    #region Methods

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnArgumentChanged(object? sender, PropertyChangedEventArgs e)
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
