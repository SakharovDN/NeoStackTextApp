namespace NeoStackTextApp;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Models;

using Services;

public class MainViewModel : INotifyPropertyChanged
{
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

        for (int i = 1; i < 6; i++)
        {
            Functions.Add(new InternalFunction((FunctionDegree)i));
        }

        _selectedFunction = Functions.First();
    }

    #endregion

    #region Methods

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
