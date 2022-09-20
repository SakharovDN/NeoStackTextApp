namespace NeoStackTextApp.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

public class InternalFunction : INotifyPropertyChanged
{
    #region Fields

    private double? _coefficientA;
    private double? _coefficientB;
    private double? _coefficientC;

    #endregion

    #region Properties

    public int Degree { get; }

    public double? CoefficientA
    {
        get => _coefficientA;
        set
        {
            _coefficientA = value;
            OnPropertyChanged();
        }
    }

    public double? CoefficientB
    {
        get => _coefficientB;
        set
        {
            _coefficientB = value;
            OnPropertyChanged();
        }
    }

    public double? CoefficientC
    {
        get => _coefficientC;
        set
        {
            _coefficientC = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Arguments> ArgumentsList { get; set; }

    public List<double> AvailableCoefficientsC { get; }

    #endregion

    #region Events

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Constructors

    public InternalFunction(int degree)
    {
        ArgumentsList = new ObservableCollection<Arguments>();
        ArgumentsList.CollectionChanged += OnArgumentsListChanged;
        Degree = degree;
        AvailableCoefficientsC = new List<double>();

        for (int i = 1; i <= 5; i++)
        {
            AvailableCoefficientsC.Add(i * Math.Pow(10, Degree - 1));
        }

        CoefficientC = AvailableCoefficientsC.FirstOrDefault();
    }

    #endregion

    #region Methods

    public bool AreCoefficientsSet()
    {
        return CoefficientA.HasValue && CoefficientB.HasValue && CoefficientC.HasValue;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnArgumentsListChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems == null)
                {
                    break;
                }

                foreach (object item in e.NewItems)
                {
                    if (item is Arguments arguments)
                    {
                        arguments.PropertyChanged += OnArgumentsChanged;
                    }
                }

                break;

            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems == null)
                {
                    break;
                }

                foreach (object item in e.OldItems)
                {
                    if (item is Arguments arguments)
                    {
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
