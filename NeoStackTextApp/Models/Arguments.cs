namespace NeoStackTextApp.Models;

using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// Arguments of function
/// </summary>
public class Arguments : INotifyPropertyChanged
{
    #region Fields

    private double? _x;
    private double? _y;
    private double? _result;

    #endregion

    #region Properties

    /// <summary>
    /// X coordinate
    /// </summary>
    public double? X
    {
        get => _x;
        set
        {
            _x = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Y coordinate
    /// </summary>
    public double? Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Calculation result
    /// </summary>
    public double? Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Events

    public event PropertyChangedEventHandler? PropertyChanged;

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

    #endregion
}
