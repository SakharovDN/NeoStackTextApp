namespace NeoStackTextApp.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class InternalFunction : INotifyPropertyChanged
{
    #region Fields

    private double? _a;
    private double? _b;
    private double? _c;

    #endregion

    #region Properties

    public int Degree { get; }

    public double? A
    {
        get => _a;
        set
        {
            _a = value;
            OnPropertyChanged();
        }
    }

    public double? B
    {
        get => _b;
        set
        {
            _b = value;
            OnPropertyChanged();
        }
    }

    public double? C
    {
        get => _c;
        set
        {
            _c = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Arguments> CoordinatesList { get; set; }

    public List<double> AvailableCoefficientsC { get; }

    #endregion

    #region Events

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Constructors

    public InternalFunction(FunctionDegree degree)
    {
        CoordinatesList = new ObservableCollection<Arguments>();
        CoordinatesList.CollectionChanged += OnCoordinateListChanged;
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

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnCoordinateListChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems != null)
                {
                    foreach (object item in e.NewItems)
                    {
                        if (item is not Arguments arguments)
                        {
                            continue;
                        }

                        arguments.PropertyChanged += OnArgumentsChanged;
                    }
                }

                break;

            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems != null)
                {
                    foreach (object item in e.OldItems)
                    {
                        if (item is not Arguments arguments)
                        {
                            continue;
                        }

                        arguments.PropertyChanged -= OnArgumentsChanged;
                    }
                }

                break;
        }
    }

    private void OnArgumentsChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName);
    }

    #endregion
}
